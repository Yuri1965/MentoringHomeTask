using System;
using System.Messaging;
using Topshelf;

namespace ImageMergerServerService
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //если что-то не так с настройкой в файле конфигурации пишем в лог и завершаем работу приложения иначе запускаем сервис
            if (ApplicationConfigParameters.GetInstance().IsConfigParamLoaded())
            {
                //перед запуском проверим наличие MSMQueue, и создадим очереди для клиентов, если их нет
                //Получаем список клиентов List<KeyValuePair<string, string>>: Key = configParamName, Value = clientName
                try
                {
                    var clientsList = ApplicationConfigParameters.GetInstance().GetListParam(QueueUtils.ConfigListParamType.ClientQueueList);

                    bool IsQueueFound = false;
                    foreach (var client in clientsList)
                    {
                        if (QueueUtils.MSMQueueCreate(ApplicationConfigParameters.GetInstance().
                                GetParamValueByClientName(client.Value, QueueUtils.ConfigListParamType.InputQueueList))
                            && QueueUtils.MSMQueueCreate(ApplicationConfigParameters.GetInstance().
                                GetParamValueByClientName(client.Value, QueueUtils.ConfigListParamType.OutputQueueList)))
                            IsQueueFound = true;
                    }

                    if (IsQueueFound)
                    {
                        HostFactory.Run(x =>
                        {
                            x.Service<QueueWatcherService>(s =>
                            {
                                s.ConstructUsing(() => new QueueWatcherService());
                                s.WhenStarted(service => service.Start());
                                s.WhenStopped(service => service.Stop());
                                s.WhenCustomCommandReceived((service, hc, command) => service.ExecuteCustomCommand(command));
                            });

                            x.UseNLog();
                            x.RunAsLocalService();

                            //эти параметры регулируют запуск сервиса при инсталяции StartManually - вручную, StartAutomatically - автостарт
                            x.StartManually();
                            //x.StartAutomatically();

                            x.SetDescription("Server for more clients (ImageMergerService)");
                            x.SetDisplayName("Server for more clients (ImageMergerService)");
                        });
                    }
                    else
                    {
                        LoggerUtil.logger.Error("Не удалось создать список очередей для клиентов на MSMQueue!");
                    }

                }
                catch (Exception e)
                {
                    LoggerUtil.LogException(e);
                }
            }
            else
            {
                LoggerUtil.logger.Error("Не удалось определить настройки приложения для обработки файлов! Возможно отсутствуют ключевые параметры в файле конфигурации.");
            }
        }

        public class QueueWatcherService : IDisposable
        {
            private bool isDisposed = false;
            private readonly QueueWatchManager watcherQueue;

            public QueueWatcherService()
            {
                watcherQueue = new QueueWatchManager();
            }

            public void Start()
            {
                //Получаем список клиентов List<KeyValuePair<string, string>>: Key = configParamName, Value = clientName
                var clientsList = ApplicationConfigParameters.GetInstance().GetListParam(QueueUtils.ConfigListParamType.ClientQueueList);

                LoggerUtil.logger.Info(String.Format("Service started {0} ", DateTime.Now.ToString()));

                //запускаем Task's по сканированию очередей для получения файлов
                foreach (var client in clientsList)
                {
                    watcherQueue.AddWatch(client.Value,
                        ApplicationConfigParameters.GetInstance().GetParamValueByClientName(client.Value, QueueUtils.ConfigListParamType.InputQueueList),
                        ApplicationConfigParameters.GetInstance().GetParamValueByClientName(client.Value, QueueUtils.ConfigListParamType.OutputDirectoryQueueList));
                }
            }

            public void Stop()
            {
                watcherQueue.StopAllTasks();

                LoggerUtil.logger.Info(String.Format("Service stopped {0} ", DateTime.Now.ToString()));
            }

            public void Dispose()
            {
                if (isDisposed)
                    return;

                isDisposed = true;

                watcherQueue.Dispose();
            }

            public void ExecuteCustomCommand(int command)
            {
                switch (command)
                {
                    //послать сообщения клиентам, чтобы они ОСТАНОВИЛИ рассылку в очереди для сервера
                    case 128:
                        SendSystemMessagesForClients(QueueUtils.CommandType.StopWorkQueue);
                        break;

                    //послать сообщения клиентам, чтобы они ЗАПУСТИЛИ рассылку в очереди для сервера
                    case 129:
                        SendSystemMessagesForClients(QueueUtils.CommandType.StartWorkQueue);
                        break;

                    default: break;
                }
            }

            private void SendSystemMessagesForClients(QueueUtils.CommandType command)
            {
                MessageQueue serverQueue;
                QueueUtils.QueueSystemMessage message;
                string messageFromServerQueue = "";

                string label = "";
                if (command == QueueUtils.CommandType.StopWorkQueue)
                    label = " STOP_QUEUE";
                if (command == QueueUtils.CommandType.StartWorkQueue)
                    label = " START_QUEUE";

                //Получаем список клиентов List<KeyValuePair<string, string>>: Key = configParamName, Value = clientName
                var clientsList = ApplicationConfigParameters.GetInstance().GetListParam(QueueUtils.ConfigListParamType.ClientQueueList);
                try
                {
                    foreach (var client in clientsList)
                    {
                        messageFromServerQueue = ApplicationConfigParameters.GetInstance().GetParamValueByClientName(client.Value, QueueUtils.ConfigListParamType.OutputQueueList);

                        using (serverQueue = new MessageQueue(messageFromServerQueue, QueueAccessMode.Send))
                        {
                            using (var trans = new MessageQueueTransaction())
                            {
                                try
                                {
                                    //открываем транзакцию, чтобы отправить сообщение клиенту
                                    trans.Begin();

                                    //формируем сообщение и отправляем его в очередь на сервер
                                    message = new QueueUtils.QueueSystemMessage(client.Value, command);

                                    serverQueue.Send(message, client.Value + label, trans);

                                    trans.Commit();

                                }
                                catch (Exception e)
                                {
                                    LoggerUtil.LogException(e);

                                    //откат транзакции если ошибка
                                    trans.Abort();
                                }
                            }
                        }
                    }

                    LoggerUtil.logger.Info(String.Format("Service send command {0} for all clients", label.Trim()));
                }
                catch (Exception e)
                {
                    LoggerUtil.LogException(e);
                }
            }
        }
    }
}
