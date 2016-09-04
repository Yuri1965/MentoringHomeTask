using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;

namespace ImageMergerService
{
    public class ApplicationConfigParameters
    {
        private const string INPUT_DIR_NAME_NONUMBER = "inputDirectory_";
        private const string OUTPUT_DIR_NAME_NONUMBER = "outputDirectory_";
        private const string DELAY_TIME_NEW_FILE = "delayTimeNewFile";
        private Dictionary<string, string> inputDirectoryList;
        private Dictionary<string, string> outputDirectoryList;
        private double delayTime = 30;

        private const string CLIENT_NAME = "clientName";
        private const string MESSAGE_TO_SERVER_QUEUE = "MSMQ_messageToServer";
        private const string MESSAGE_FROM_SERVER_QUEUE = "MSMQ_messageFromServer";
        private const string OUTPUT_FILES_DIRECTORY_QUEUE = "MSMQ_OutputFilesDirectory";
        private const string DELAY_TIME_MSMQUEUE_CONNECT = "delayTimeMSMQueueConnect";
        private const string FILE_MESSAGE_PART_SIZE = "fileMessagePartSize";

        private string clientName;
        private string messageToServerQueue;
        private string messageFromServerQueue;
        private string outputFilesDirectoryQueue;
        private double delayTimeMSMQueueConnect = 5;
        private int fileMessagePartSize = 1048576;

        public bool isWorkQueue = true;

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
            if (inputDirectoryList == null || inputDirectoryList.Count == 0 || outputDirectoryList == null || outputDirectoryList.Count == 0
                || messageToServerQueue.Trim() == "" || messageFromServerQueue.Trim() == ""
                || clientName.Trim() == "" || outputFilesDirectoryQueue.Trim() == "")
                return false;

            try
            {
                if (!MessageQueue.Exists(messageToServerQueue) || !MessageQueue.Exists(messageFromServerQueue))
                {
                    LoggerUtil.logger.Error(String.Format("Не верно указаны параметры подключения к очередям для сервера MSMQueue:\n" +
                        "Очередь для исходящих сообщений = {0}\n" + "Очередь для входящих сообщений = {1}", messageToServerQueue, messageFromServerQueue));
                    return false;
                }
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
                return false;
            }

            return true;
        }
        
        public double GetDelayTime()
        {
            return delayTime;
        }

        public int GetFileMessagePartSize()
        {
            return fileMessagePartSize;
        }

        public double GetDelayTimeMSMQueueConnect()
        {
            return delayTimeMSMQueueConnect;
        }

        public string GetClientName()
        {
            if (!IsConfigParamLoaded())
                return null;

            return clientName;
        }

        public string GetMessageToServerQueue()
        {
            if (!IsConfigParamLoaded())
                return null;
            
            return messageToServerQueue;
        }

        public string GetMessageFromServerQueue()
        {
            if (!IsConfigParamLoaded())
                return null;
            
            return messageFromServerQueue;
        }

        public string GetOutputFilesDirectoryQueue()
        {
            if (!IsConfigParamLoaded())
                return null;

            return outputFilesDirectoryQueue;
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

                    clientName = null;
                    messageToServerQueue = null;
                    messageFromServerQueue = null;
                    outputFilesDirectoryQueue = null;

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

                        if (key.Equals(DELAY_TIME_NEW_FILE, StringComparison.OrdinalIgnoreCase))
                        {
                            double delay;
                            if (double.TryParse(appSettings[key], out delay))
                                delayTime = delay;
                        }

                        if (key.Contains(CLIENT_NAME))
                            clientName = appSettings[key];

                        if (key.Contains(MESSAGE_TO_SERVER_QUEUE))
                            messageToServerQueue = appSettings[key];

                        if (key.Contains(MESSAGE_FROM_SERVER_QUEUE))
                            messageFromServerQueue = appSettings[key];

                        if (key.Contains(OUTPUT_FILES_DIRECTORY_QUEUE))
                            outputFilesDirectoryQueue = appSettings[key];

                        if (key.Equals(DELAY_TIME_MSMQUEUE_CONNECT, StringComparison.OrdinalIgnoreCase))
                        {
                            double delay;
                            if (double.TryParse(appSettings[key], out delay))
                                delayTimeMSMQueueConnect = delay;
                        }

                        if (key.Equals(FILE_MESSAGE_PART_SIZE, StringComparison.OrdinalIgnoreCase))
                        {
                            int partSize;
                            if (int.TryParse(appSettings[key], out partSize))
                                fileMessagePartSize = partSize;
                        }
                    }
                }
            }
            catch (ConfigurationErrorsException)
            {
                inputDirectoryList = null;
                outputDirectoryList = null;

                clientName = null;
                messageToServerQueue = null;
                messageFromServerQueue = null;
                outputFilesDirectoryQueue = null;

                return;
            }
        }
    }
}