using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMerger
{
    public interface IDirectoryWatchManager
    {
        void AddWatch(string inputDirectory, string outputDirectory);
        void StopAllTasks();
        void Dispose();

    }
}
