using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMergerServerService
{
    public class QueueWatchManager
    {
        private bool isDisposed = false;
        private readonly List<ServiceTask> tasks = new List<ServiceTask>();
        private double delayTimeMSMQueueConnect;

        public QueueWatchManager()
        {
            delayTimeMSMQueueConnect = ApplicationConfigParameters.GetInstance().GetDelayTimeMSMQueueConnect();
        }

        public void AddWatch(string clientName, string clientQueue, string outputDirectoryQueue)
        {
            var task = DoWatchInputQueue(clientName, clientQueue, outputDirectoryQueue);
            tasks.Add(task);
        }

        private ServiceTask DoWatchInputQueue(string clientName, string clientQueue, string outputDirectoryQueue)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var task = DoWatchInputQueueAsync(clientName, clientQueue, outputDirectoryQueue, cancellationTokenSource.Token);
            return new ServiceTask(task, cancellationTokenSource);
        }

        private async Task DoWatchInputQueueAsync(string clientName, string toServerQueue, string outputDirectoryQueue, CancellationToken token)
        {
            try
            {
                await Task.Factory.StartNew(async () =>
                {
                    token.ThrowIfCancellationRequested();

                    MessageQueue clientQueue;
                    SortedDictionary<string, Message> listFiles = new SortedDictionary<string, Message>();
                    SortedDictionary<string, bool> listMessages = new SortedDictionary<string, bool>();
                    Message message;
                    QueueUtils.QueueMessage receiveMessage;
                    MessageQueueTransaction trans;
                    MessageEnumerator messages;

                    while (true)
                    {
                        //если нет доступа к очереди, то будем ждать пока он не появится
                        while (!QueueUtils.IsMSMQueueConnected(toServerQueue))
                            await Task.Delay(TimeSpan.FromSeconds((int)delayTimeMSMQueueConnect), token);

                        //используем очередь в которой клиент посылает сообщения серверу
                        using (clientQueue = new MessageQueue(toServerQueue, QueueAccessMode.Receive))
                        {
                            clientQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(QueueUtils.QueueMessage) });
                        }

                        listFiles.Clear();
                        listMessages.Clear();

                        using (trans = new MessageQueueTransaction())
                        {
                            try
                            {
                                trans.Begin();

                                //читаем сообщения из очереди в транзакции и формируем список, из которого потом будем собирать файлы
                                messages = clientQueue.GetMessageEnumerator2();
                                while (messages.MoveNext(TimeSpan.FromSeconds(1)))
                                {
                                    //читаем сообщение
                                    message = clientQueue.PeekById(messages.Current.Id);
                                    receiveMessage = (QueueUtils.QueueMessage)message.Body;

                                    //здесь получаем наименование части файла по message.Label, и если имя уже есть в коллекции
                                    //то не будем его обрабатывать еще раз, а просто удалим сообщение потом(и если клиент не наш в сообщении, то тоже), 
                                    //иначе добавим его в коллекцию для обработки
                                    if (!listFiles.ContainsKey(message.Label) && receiveMessage.clientName == clientName)
                                    {
                                        listFiles.Add(message.Label, message);
                                        listMessages.Add(message.Id, false);
                                    }
                                    else { listMessages.Add(message.Id, true); }
                                }

                                //если есть что сохранить то вызываем метод склейки файлов из частей
                                if (listFiles.Count > 0)
                                    MergeFiles(ref listFiles, ref listMessages, outputDirectoryQueue);

                                foreach (var mes in listMessages)
                                {
                                    //удаляем сообщение
                                    try
                                    {
                                        if (mes.Value)
                                            clientQueue.ReceiveById(mes.Key);
                                    }
                                    catch
                                    {
                                    }
                                }

                                trans.Commit();
                            }
                            catch (Exception e)
                            {
                                LoggerUtil.LogException(e);

                                trans.Abort();
                            }
                        }

                        //делаем паузу до следующего сканирования очереди
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

        private void MergeFiles(ref SortedDictionary<string, Message> listFiles, ref SortedDictionary<string, bool> listMessages, string outputDirectoryQueue)
        {
            SortedDictionary<int, Message> listPartsFile = new SortedDictionary<int, Message>();
            SortedDictionary<string, int> listNameFiles = new SortedDictionary<string, int>();

            QueueUtils.QueueMessage msgBody;
            //сначала соберем имена файлов с количеством частей
            foreach (var file in listFiles)
            {
                msgBody = (QueueUtils.QueueMessage)file.Value.Body;
                if (!listNameFiles.ContainsKey(msgBody.fileName))
                {
                    listNameFiles.Add(msgBody.fileName, msgBody.partsCount);
                }
            }

            string fileName = "";
            int partsCount = 0;
            FileStream fsSource;

            foreach (var file in listNameFiles)
            {
                listPartsFile.Clear();

                fileName = file.Key;
                partsCount = file.Value;

                foreach (var partFile in listFiles)
                {
                    msgBody = (QueueUtils.QueueMessage)partFile.Value.Body;
                    if (msgBody.fileName == fileName && msgBody.partNumber <= partsCount)
                        listPartsFile.Add(msgBody.partNumber, partFile.Value);
                }

                //если получены все части файла, то будем сохранять
                if (listPartsFile.Count > 0 && listPartsFile.Count == partsCount)
                {
                    try
                    {
                        fsSource = new FileStream(outputDirectoryQueue + fileName + ".pdf", FileMode.Create);
                        foreach (var partFile in listPartsFile)
                        {
                            msgBody = (QueueUtils.QueueMessage)partFile.Value.Body;
                            Byte[] bytePart = msgBody.partFile;
                            fsSource.Write(bytePart, 0, bytePart.Length);
                        }
                        fsSource.Close();

                        //файл сохранили, поэтому отметим что сообщение можно удалить
                        foreach (var partFile in listPartsFile)
                        {
                            listMessages[partFile.Value.Id] = true;
                        }
                    }
                    catch (Exception e)
                    {
                        LoggerUtil.LogException(e);
                    }
                }
            }
        }

        public void StopAllTasks()
        {
            foreach (var queueWatchTask in tasks)
            {
                try
                {
                    queueWatchTask.CancellationTokenSource.Cancel();
                }
                catch (AggregateException e)
                {
                    LoggerUtil.LogException(e);
                }
            }

            try
            {
                Task.WaitAll(tasks.Select(x => x.CurrentTask).ToArray());
            }
            catch (AggregateException e)
            {
                LoggerUtil.LogNonCancellationExceptions(e);
            }
            finally
            {
                DisposeTasks();
            }
        }

        private void DisposeTasks()
        {
            foreach (var task in tasks)
                task.Dispose();
            tasks.Clear();
        }

        public void Dispose()
        {
            if (isDisposed)
                return;
            isDisposed = true;
            DisposeTasks();
        }
    }
}
