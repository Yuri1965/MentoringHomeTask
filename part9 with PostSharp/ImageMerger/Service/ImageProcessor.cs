using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ImageMerger
{
    [LogMethodParams]
    public class ImageProcessor
    {
        private readonly string outputDirectory;
        private readonly Dictionary<string, Tuple<ImageToPdfFileMerger, int>> prefixToState;

        public ImageProcessor(string outputDirectory)
        {
            this.outputDirectory = outputDirectory;
            prefixToState = new Dictionary<string, Tuple<ImageToPdfFileMerger, int>>();
        }

        public void ProcessFile(string file)
        {
            ProcessFile(file, TryParseFileAsSequence(file));
        }

        public void ProcessFile(string file, Tuple<string, int> fileDescription)
        {
            if (fileDescription == null)
                return;

            var prefix = fileDescription.Item1;
            var fileSeqNumber = fileDescription.Item2;

            Tuple<ImageToPdfFileMerger, int> mergerAndLastSeqNumber;
            if (!prefixToState.TryGetValue(prefix, out mergerAndLastSeqNumber))
            {
                var newMerger = new ImageToPdfFileMerger(outputDirectory, prefix + fileSeqNumber.ToString() + ".pdf");
                mergerAndLastSeqNumber = new Tuple<ImageToPdfFileMerger, int>(newMerger, fileSeqNumber - 1);
            }

            var merger = mergerAndLastSeqNumber.Item1;
            var lastSeqNumber = mergerAndLastSeqNumber.Item2;
            if (lastSeqNumber != fileSeqNumber - 1)
            {
                SaveResult(prefix, merger);
                merger = new ImageToPdfFileMerger(outputDirectory, prefix + fileSeqNumber.ToString() + ".pdf");
            }

            if (merger.AddImageFile(file))
                prefixToState[prefix] = new Tuple<ImageToPdfFileMerger, int>(merger, fileSeqNumber);
        }

        private void SaveResult(string prefix, ImageToPdfFileMerger merger)
        {
            merger.SavePdfFile();
        }

        public Tuple<string, int> TryParseFileAsSequence(string file)
        {
            var extension = Path.GetExtension(file);
            file = Path.GetFileNameWithoutExtension(file);

            if (file == null || extension == null ||
                   (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase)
                    && !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
                    && !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)))
                return null;

            var underscorePos = file.IndexOf("_", StringComparison.Ordinal);
            if (underscorePos == -1)
                return null;

            var prefix = file.Substring(0, underscorePos);
            if (prefix == "")
                return null;

            int seqNumber;
            if (!int.TryParse(file.Substring(underscorePos + 1), out seqNumber))
                return null;

            return new Tuple<string, int>(prefix, seqNumber);
        }

        public void SaveFileByKey(string key)
        {
            var merger = prefixToState[key].Item1;
            try
            {
                merger.SavePdfFile();
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
            }
            finally
            {
                prefixToState.Remove(key);
            }
        }

        public void SaveAllCurrentFiles()
        {
            foreach (var value in prefixToState.Values)
            {
                try
                {
                    var merger = value.Item1;
                    merger.SavePdfFile();
                }
                catch (Exception e)
                {
                    LoggerUtil.LogException(e);
                }
            }
            prefixToState.Clear();
        }
    }
}