using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMerger
{
    public interface IImageWatcherService
    {
        void Start();
        void Stop();
        void Dispose();
    }
}
