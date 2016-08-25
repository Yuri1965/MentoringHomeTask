using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ImageMerger
{
    public class ApplicationConfigParameters
    {
        private const string INPUT_DIR_NAME_NONUMBER = "inputDirectory_";
        private const string OUTPUT_DIR_NAME_NONUMBER = "outputDirectory_";
        private const string DELAY_TIME_NAME = "delayTimeNewFile";

        private Dictionary<string, string> inputDirectoryList;
        private Dictionary<string, string> outputDirectoryList;
        private double delayTime = 30;

        private static ApplicationConfigParameters instance;

        private ApplicationConfigParameters()
        {
            inputDirectoryList = new Dictionary<string, string>();
            outputDirectoryList = new Dictionary<string, string>();

            FillParams();
        }

        public static ApplicationConfigParameters GetInstance()
        {
            if (instance == null)
            {
                instance = new ApplicationConfigParameters();
            }

            return instance;
        }

        public bool IsConfigParamLoaded()
        {
            if (inputDirectoryList == null || inputDirectoryList.Count == 0 || outputDirectoryList == null || outputDirectoryList.Count == 0)
                return false;

            return true;
        }
        
        public double GetDelayTime()
        {
            return delayTime;
        }

        public List<KeyValuePair<string, string>> GetListInputOutputDirectoriesPair()
        {
            if (!IsConfigParamLoaded())
                return null;

            var inputAndOutputDirs = new List<KeyValuePair<string, string>>();

            var inputDirNumbers = (from n in inputDirectoryList select n.Key.Substring(n.Key.IndexOf("_", StringComparison.Ordinal) + 1));

            foreach (var numberDir in inputDirNumbers)
            {
                KeyValuePair<string, string> dirPair = GetInputOutputDirectoriesPairByNumberValue(numberDir);

                if (!dirPair.Key.Trim().Equals("") || !dirPair.Value.Trim().Equals(""))
                    inputAndOutputDirs.Add(GetInputOutputDirectoriesPairByNumberValue(numberDir));
            }

            return inputAndOutputDirs;
        }

        private KeyValuePair<string, string> GetInputOutputDirectoriesPairByNumberValue(string numberDir)
        {
            string inputDirName = "";
            string outputDirName = "";

            inputDirectoryList.TryGetValue(INPUT_DIR_NAME_NONUMBER + numberDir, out inputDirName);
            if (inputDirName == null)
                inputDirName = "";

            outputDirectoryList.TryGetValue(OUTPUT_DIR_NAME_NONUMBER + numberDir, out outputDirName);
            if (outputDirName == null)
                outputDirName = "";

            if (inputDirName.Trim() == "" || outputDirName.Trim() == "")
            {
                LoggerUtil.logger.Error(String.Format("Директории для указанного номера {0} не найдены в файле настроек приложения! " +
                    "У каждого номера входящей директории должна быть исходящая директория с таким же номером.", numberDir));

                return new KeyValuePair<string, string>("", "");
            }

            KeyValuePair<string, string> inputAndOutputDirs = new KeyValuePair<string, string>(inputDirName, outputDirName);

            return inputAndOutputDirs;
        }

        private void FillParams()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    inputDirectoryList = null;
                    outputDirectoryList = null;

                    return;
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        if (key.Contains(INPUT_DIR_NAME_NONUMBER))
                            inputDirectoryList.Add(key, appSettings[key]);

                        if (key.Contains(OUTPUT_DIR_NAME_NONUMBER))
                            outputDirectoryList.Add(key, appSettings[key]);

                        if (key.Equals(DELAY_TIME_NAME, StringComparison.OrdinalIgnoreCase))
                        {
                            double delay;
                            if (double.TryParse(appSettings[key], out delay))
                                delayTime = delay;
                        }
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                inputDirectoryList = null;
                outputDirectoryList = null;
                return;
            }
        }
    }
}