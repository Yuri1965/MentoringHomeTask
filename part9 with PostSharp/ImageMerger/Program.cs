﻿using System;
using Topshelf;

namespace ImageMerger
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
                    x.SetDisplayName("ImageMergerService");
                    x.SetServiceName("ImageMergerService");
                });
            }
            else 
            {
                LoggerUtil.logger.Error("Не удалось определить настройки приложения для обработки файлов! Возможно отсутствуют ключевые параметры в файле конфигурации.");
            }
        }
    }

    [LogMethodParams]
    public class ImageWatcherService : IDisposable
    {
        private readonly DirectoryWatchManager watcher;
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
            //Получаем список директорий парами List<KeyValuePair<string, string>>: Key=inputDir, Value=outputDir
            var inputAndOutputDirs = ApplicationConfigParameters.GetInstance().GetListInputOutputDirectoriesPair();

            LoggerUtil.logger.Info(String.Format("Service started {0} ", DateTime.Now.ToString()));

            foreach (var inputAndOutputDirectory in inputAndOutputDirs)
                watcher.AddWatch(inputAndOutputDirectory.Key, inputAndOutputDirectory.Value);
        }

        public void Stop()
        {
            watcher.StopAllTasks();
            LoggerUtil.logger.Info(String.Format("Service stopped {0} ", DateTime.Now.ToString()));
        }

        public void Dispose()
        {
            if (isDisposed)
                return;
            isDisposed = true;
            watcher.Dispose();
        }
    }
}
