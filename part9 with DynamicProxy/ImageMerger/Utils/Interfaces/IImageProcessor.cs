using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMerger
{
    public interface IImageProcessor
    {
        void ProcessFile(string file);
        void ProcessFile(string file, Tuple<string, int> fileDescription);
        Tuple<string, int> TryParseFileAsSequence(string file);
        void SaveFileByKey(string key);
        void SaveAllCurrentFiles();
    }
}
