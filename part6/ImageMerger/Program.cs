using System;
using Topshelf;

namespace ImageMergerService
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            //если что-то не так с настройкой в файле конфигурации пишем в лог и завершаем работу приложения иначе запускаем сервис
            if (ApplicationConfigParameters.GetInstance().IsConfigParamLoaded())
            {
                //имя клиента(экземпляра службы) из файла конфигурации будем подставлять в наименование службы (сервиса SetServiceName(..) и SetDisplayName(..)), 
                //под этим именем она будет запускаться и видна в процессах на рабочей станции,
                //также ее можно будет инсталлировать с разных директорий n раз на одной рабочей станции и запускать как службу под разными именами
                string clientName = ApplicationConfigParameters.GetInstance().GetClientName();

                HostFactory.Run(x =>
                {
                    x.Service<ImageWatcherService>(s =>
                    {
                        s.ConstructUsing(() => new ImageWatcherService());
                        s.WhenStarted(service => service.Start());
                        s.WhenStopped(service => service.Stop());
                    });

                    x.UseNLog();
                    x.RunAsLocalService();

                    //эти параметры регулируют запуск сервиса при инсталяции StartManually - вручную, StartAutomatically - автостарт
                    x.StartManually();
                    //x.StartAutomatically();

                    x.SetDescription("Image to PDF format processing service");
                    x.SetDisplayName("ImageMergerService_" + clientName.Trim());
                    x.SetServiceName("ImageMergerService_" + clientName.Trim());
                });
            }
            else 
            {
                LoggerUtil.logger.Error("Не удалось определить настройки приложения для обработки файлов! Возможно отсутствуют ключевые параметры в файле конфигурации.");
            }
        }
    }

    public class ImageWatcherService : IDisposable
    {
        private readonly DirectoryWatchManager watcher;
        private DirectoryWatchManagerQueue watcherQueue;
        private bool isDisposed = false;

        public ImageWatcherService()
        {
            //получим таймаут ожидания(в секундах) появления новых файлов в директориях из конфигурационного файла
            //это для того чтобы сохранить все что в памяти в виде книги и завершить поток (task), а не висеть постоянно и ждать
            var delay = TimeSpan.FromSeconds(ApplicationConfigParameters.GetInstance().GetDelayTime());

            watcher = new DirectoryWatchManager(delay);
        }

        public void Start()
        {
            //Получаем список директорий для сканирования файлов - парами List<KeyValuePair<string, string>>: Key=inputDir, Value=outputDir
            var inputAndOutputDirs = ApplicationConfigParameters.GetInstance().GetListInputOutputDirectoriesPair();
            //Получаем директорию для прослушки и отправки файлов в очередь MSMQ
            string outputDirectoryQueue = ApplicationConfigParameters.GetInstance().GetOutputFilesDirectoryQueue(); 

            LoggerUtil.logger.Info(String.Format("Service started {0} ", DateTime.Now.ToString()));

            //запускаем Task's по сканированию директорий
            foreach (var inputAndOutputDirectory in inputAndOutputDirs)
                watcher.AddWatch(inputAndOutputDirectory.Key, inputAndOutputDirectory.Value, outputDirectoryQueue);

            //запускаем Task по сканированию директории для отправки файлов в MSMQ очередь
            watcherQueue = new DirectoryWatchManagerQueue(outputDirectoryQueue);
        }

        public void Stop()
        {
            watcher.StopAllTasks();
            watcherQueue.StopTask();
        }

        public void Dispose()
        {
            if (isDisposed)
                return;
            isDisposed = true;

            watcher.Dispose();
            watcherQueue.Dispose();
        }
    }
}
