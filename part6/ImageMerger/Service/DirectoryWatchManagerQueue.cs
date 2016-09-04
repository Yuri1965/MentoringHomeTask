using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMergerService
{
    public class DirectoryWatchManagerQueue : IDisposable
    {
        private string messageToServerQueue;
        private string messageFromServerQueue;
        private string clientName;
        private double delayTimeMSMQueueConnect;

        private bool isDisposed = false;
        private ServiceTask taskDirectoryQueue;
        private ServiceTask taskSystemQueue;

        public DirectoryWatchManagerQueue(string inputDirectory)
        {
            messageToServerQueue = ApplicationConfigParameters.GetInstance().GetMessageToServerQueue();
            messageFromServerQueue = ApplicationConfigParameters.GetInstance().GetMessageFromServerQueue();
            clientName = ApplicationConfigParameters.GetInstance().GetClientName();
            delayTimeMSMQueueConnect = ApplicationConfigParameters.GetInstance().GetDelayTimeMSMQueueConnect();

            this.taskSystemQueue = DoSystemQueue();
            this.taskDirectoryQueue = DoWatchInputDirectory(inputDirectory);
        }

        private ServiceTask DoSystemQueue()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var task = DoSystemQueueAsync(cancellationTokenSource.Token);
            return new ServiceTask(task, cancellationTokenSource);
        }

        private async Task DoSystemQueueAsync(CancellationToken token)
        {
            try
            {
                await Task.Factory.StartNew(async () =>
                {
                    MessageQueue clientQueue;
                    while (true)
                    {
                        try
                        {
                            token.ThrowIfCancellationRequested();

                            //если нет доступа к очереди, то будем ждать пока он не появится
                            while (!QueueUtils.IsMSMQueueConnected(messageFromServerQueue))
                                await Task.Delay(TimeSpan.FromSeconds((int)delayTimeMSMQueueConnect), token);

                            //используем очередь в которой сервер посылает сообщения клиенту
                            using (clientQueue = new MessageQueue(messageFromServerQueue, QueueAccessMode.Receive))
                            {
                                clientQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(QueueUtils.QueueSystemMessage) });
                            }

                            using (var messages = clientQueue.GetMessageEnumerator2())
                            while (messages.MoveNext())
                            {
                                using (var trans = new MessageQueueTransaction())
                                {
                                    try
                                    {
                                        trans.Begin();

                                        var message = clientQueue.PeekById(messages.Current.Id);

                                        QueueUtils.QueueSystemMessage receiveMessage = (QueueUtils.QueueSystemMessage)message.Body;
                                        if (receiveMessage.clientName == clientName && 
                                            (receiveMessage.commandType == QueueUtils.CommandType.StopWorkQueue ||
                                            receiveMessage.commandType == QueueUtils.CommandType.StartWorkQueue))
                                        {
                                            if (receiveMessage.commandType == QueueUtils.CommandType.StartWorkQueue)
                                            {
                                                ApplicationConfigParameters.GetInstance().isWorkQueue = true;
                                                LoggerUtil.logger.Info(String.Format("Команда с сервера => Старт очереди для отправки сообщений {0} ", DateTime.Now.ToString()));
                                            }

                                            if (receiveMessage.commandType == QueueUtils.CommandType.StopWorkQueue)
                                            {
                                                ApplicationConfigParameters.GetInstance().isWorkQueue = false;
                                                LoggerUtil.logger.Info(String.Format("Команда с сервера => Остановка очереди для отправки сообщений {0} ", DateTime.Now.ToString()));
                                            }

                                            //удаляем текущее сообщение из очереди
                                            clientQueue.ReceiveById(message.Id);
                                        }

                                        trans.Commit();
                                    }
                                    catch (Exception e)
                                    {
                                        LoggerUtil.LogException(e);

                                        trans.Abort();
                                    }
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // Это ожидаемо, пробрасываем дальше
                            throw;
                        }
                        catch (Exception e)
                        {
                            LoggerUtil.LogException(e);
                        }

                        //делаем паузу перед следующим сканированием очереди сообщений
                        await Task.Delay(TimeSpan.FromSeconds((int)delayTimeMSMQueueConnect), token);
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
                // Это ожидаемо, пробрасываем дальше
                throw;
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
            }
        }

        private ServiceTask DoWatchInputDirectory(string inputDirectory)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var task = DoWatchInputDirectoryAsync(inputDirectory, cancellationTokenSource.Token);
            return new ServiceTask(task, cancellationTokenSource);
        }

        private async Task DoWatchInputDirectoryAsync(string inputDirectory, CancellationToken token)
        {
            try
            {
                //Класс для отправки файлов в MSMQ очередь
                var queueProcessor = new FileQueueProcessor(inputDirectory);

                // Сначала обработаем существующие файлы
                await Task.Factory.StartNew(async () =>
                {
                    var files = Directory.GetFiles(inputDirectory);
                    Array.Sort(files);

                    foreach (var file in files)
                    {
                        if (!Path.GetExtension(file).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            continue;

                        //если нет доступа к очереди, то будем ждать пока он не появится
                        while (!QueueUtils.IsMSMQueueConnected(messageToServerQueue, messageFromServerQueue) || !QueueUtils.IsWorkQueue())
                            await Task.Delay(TimeSpan.FromSeconds((int)delayTimeMSMQueueConnect), token);

                        token.ThrowIfCancellationRequested();
                        queueProcessor.ProcessFile(file, token);
                    }
                }, token);

                // Очередь, чтобы обмениваться именами новых файлов между потоком FileWatcher'а и потоком нашего Task
                AsyncQueue<string> queue = new AsyncQueue<string>(token);

                // Обработчик для новых файлов. Эту функцию будем вызывать в отдельном потоке, поэтому она должна быть потокобезопасной
                Action<string> newFileHandler = newFile => { queue.Enqueue(newFile); };
                // Теперь будем следить за появлением новых файлов
                using (new NewFilesWatcher(inputDirectory, newFileHandler))
                {
                    while (true)
                    {
                        var file = await queue.Dequeue();

                        if (!Path.GetExtension(file).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                            continue;

                        queueProcessor.ProcessFile(file, token);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Это ожидаемо, пробрасываем дальше
                throw;
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
            }
        }

        public void StopTask()
        {
            try
            {
                taskDirectoryQueue.CancellationTokenSource.Cancel();
                taskSystemQueue.CancellationTokenSource.Cancel();
            }
            catch (AggregateException e)
            {
                LoggerUtil.LogException(e);
            }

            try
            {
                Task.WaitAll(taskDirectoryQueue.CurrentTask);
                Task.WaitAll(taskSystemQueue.CurrentTask);
            }
            catch (AggregateException e)
            {
                LoggerUtil.LogNonCancellationExceptions(e);
            }
            finally
            {
                taskDirectoryQueue.Dispose();
                taskSystemQueue.Dispose();
            }
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            isDisposed = true;
            taskDirectoryQueue.Dispose();
            taskSystemQueue.Dispose();
        }
    }
}
