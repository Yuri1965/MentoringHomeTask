﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMergerService
{
    public class DirectoryWatchManager : IDisposable
    {
        private bool isDisposed = false;
        private readonly List<ServiceTask> tasks = new List<ServiceTask>();
        private readonly TimeSpan delayBeforeSave;

        public DirectoryWatchManager(TimeSpan delayBeforeSave)
        {
            this.delayBeforeSave = delayBeforeSave;
        }

        public void AddWatch(string inputDirectory, string outputDirectory, string outputDirectoryQueue)
        {
            var task = DoWatchInputDirectory(inputDirectory, outputDirectory, outputDirectoryQueue);
            tasks.Add(task);
        }

        public void StopAllTasks()
        {
            foreach (var dirWatchTask in tasks)
            {
                try
                {
                    dirWatchTask.CancellationTokenSource.Cancel();
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

        private ServiceTask DoWatchInputDirectory(string inputDirectory, string outputDirectory, string outputDirectoryQueue)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var task = DoWatchInputDirectoryAsync(inputDirectory, outputDirectory, outputDirectoryQueue, cancellationTokenSource.Token);
            return new ServiceTask(task, cancellationTokenSource);
        }

        private async Task DoWatchInputDirectoryAsync(string inputDirectory, string outputDirectory, string outputDirectoryQueue, CancellationToken token)
        {
            try
            {
                // Очередь, чтобы обмениваться именами новых файлов между потоком FileWatcher'а и потоком наших Task'ов
                AsyncQueue<string> queue = new AsyncQueue<string>(token);

                // Класс для обработки полученных изображений
                var imageProcessor = new ImageProcessor(outputDirectory, outputDirectoryQueue);

                try
                {
                    // Сначала обработаем существующие файлы
                    await Task.Factory.StartNew(() =>
                    {
                        var files = Directory.GetFiles(inputDirectory);
                        Array.Sort(files);

                        foreach (var file in files)
                        {
                            token.ThrowIfCancellationRequested();
                            imageProcessor.ProcessFile(file);
                        }
                    }, token);
                    imageProcessor.SaveAllCurrentFiles();

                    // Обработчик для новых файлов. Эту функцию будем вызывать в отдельном потоке, поэтому она должна быть потокобезопасной
                    Action<string> newFileHandler = newFile => { queue.Enqueue(newFile); };
                    // Теперь будем следить за появлением новых файлов
                    using (var prefixSavers = new DelayedTaskDictionary())
                    using (new NewFilesWatcher(inputDirectory, newFileHandler))
                    {
                        while (true)
                        {
                            var file = await queue.Dequeue();

                            var fileDescription = imageProcessor.TryParseFileAsSequence(file);
                            if (fileDescription == null)
                                continue;

                            var prefix = fileDescription.Item1;

                            prefixSavers.Stop(prefix);
                            imageProcessor.ProcessFile(file, fileDescription);
                            prefixSavers.ReNew(prefix, delayBeforeSave, () =>
                            {
                                imageProcessor.SaveFileByKey(prefix);
                            });
                        }
                    }
                }
                finally
                {
                    imageProcessor.SaveAllCurrentFiles();
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

        public void Dispose()
        {
            if (isDisposed)
                return;
            isDisposed = true;
            DisposeTasks();
        }
    }
}