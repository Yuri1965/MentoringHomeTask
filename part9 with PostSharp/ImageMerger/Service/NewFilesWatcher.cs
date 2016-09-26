using System;
using System.IO;

namespace ImageMerger
{
    [LogMethodParams]
    public class NewFilesWatcher : IDisposable
    {
        private readonly Action<string> onCreatedFile;
        private readonly FileSystemWatcher fsWatcher;
        private bool isDisposed;

        public NewFilesWatcher(string inputDirectory, Action<string> onCreatedFile)
        {
            this.onCreatedFile = onCreatedFile;

            fsWatcher = new FileSystemWatcher(inputDirectory);
            fsWatcher.NotifyFilter = NotifyFilters.FileName;
            fsWatcher.Created += (sender, args) =>
            {
                if (args.ChangeType != WatcherChangeTypes.Created)
                    return;

                this.onCreatedFile(args.FullPath);
            };
            fsWatcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            fsWatcher.EnableRaisingEvents = false;
            isDisposed = true;
        }
    }
}