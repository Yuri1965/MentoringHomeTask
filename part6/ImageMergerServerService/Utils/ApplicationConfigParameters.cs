using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;

namespace ImageMergerServerService
{
    public class ApplicationConfigParameters
    {
        private const string CLIENT_NAME = "clientName_";
        private const string MESSAGE_TO_SERVER_QUEUE = "MSMQmessageToServer_";
        private const string MESSAGE_FROM_SERVER_QUEUE = "MSMQmessageFromServer_";
        private const string OUTPUT_FILES_DIRECTORY_QUEUE = "MSMQoutputDirectory_";
        private const string DELAY_TIME_MSMQUEUE_CONNECT = "delayTimeMSMQueueConnect";
        private const string FILE_MESSAGE_PART_SIZE = "fileMessagePartSize";

        private Dictionary<string, string> clientQueueList;
        private Dictionary<string, string> inputQueueList;
        private Dictionary<string, string> outputQueueList;
        private Dictionary<string, string> outputDirectoryQueueList;

        private double delayTimeMSMQueueConnect = 5;
        private int fileMessagePartSize = 1048576;

        private static ApplicationConfigParameters instance;

        private ApplicationConfigParameters()
        {
            clientQueueList = new Dictionary<string, string>();
            inputQueueList = new Dictionary<string, string>();
            outputQueueList = new Dictionary<string, string>();
            outputDirectoryQueueList = new Dictionary<string, string>();

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
            if (inputQueueList == null || inputQueueList.Count == 0 || outputQueueList == null || outputQueueList.Count == 0
                || outputDirectoryQueueList == null || outputDirectoryQueueList.Count == 0
                || clientQueueList == null || clientQueueList.Count == 0)
                return false;

            return true;
        }

        public int GetFileMessagePartSize()
        {
            return fileMessagePartSize;
        }

        public double GetDelayTimeMSMQueueConnect()
        {
            return delayTimeMSMQueueConnect;
        }

        public Dictionary<string, string> GetListParam(QueueUtils.ConfigListParamType listParam)
        {
            if (!IsConfigParamLoaded())
                return null;

            var resultList = new Dictionary<string, string>();

            if (listParam == QueueUtils.ConfigListParamType.ClientQueueList)
                resultList = clientQueueList;

            if (listParam == QueueUtils.ConfigListParamType.InputQueueList)
                resultList = inputQueueList;

            if (listParam == QueueUtils.ConfigListParamType.OutputQueueList)
                resultList = outputQueueList;

            if (listParam == QueueUtils.ConfigListParamType.OutputDirectoryQueueList)
                resultList = outputDirectoryQueueList;

            return resultList;
        }

        public string GetParamValueByClientName(string clientName, QueueUtils.ConfigListParamType paramType)
        {
            string result = "";

            if (!IsConfigParamLoaded())
                return result;

            string paramValue = "";
            string paramName = "";

            if (paramType == QueueUtils.ConfigListParamType.InputQueueList)
            {
                paramName = MESSAGE_TO_SERVER_QUEUE + clientName;
                inputQueueList.TryGetValue(paramName, out paramValue);
                if (paramValue == null)
                    paramValue = "";
            }

            if (paramType == QueueUtils.ConfigListParamType.OutputQueueList)
            {
                paramName = MESSAGE_FROM_SERVER_QUEUE + clientName;
                outputQueueList.TryGetValue(paramName, out paramValue);
                if (paramValue == null)
                    paramValue = "";
            }

            if (paramType == QueueUtils.ConfigListParamType.OutputDirectoryQueueList)
            {
                paramName = OUTPUT_FILES_DIRECTORY_QUEUE + clientName;
                outputDirectoryQueueList.TryGetValue(paramName, out paramValue);
                if (paramValue == null)
                    paramValue = "";
            }

            if (paramValue.Trim() == "")
            {
                LoggerUtil.logger.Error(String.Format("Параметр {0} для указанного клиента {1} не найден в файле настроек приложения!",
                                                      paramName, clientName));
            }
            else { result = paramValue; }

            return result;
        }

        private void FillParams()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    clientQueueList = null;
                    inputQueueList = null;
                    outputQueueList = null;
                    outputDirectoryQueueList = null;

                    return;
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        if (key.Contains(CLIENT_NAME))
                            clientQueueList.Add(key, appSettings[key]);

                        if (key.Contains(MESSAGE_TO_SERVER_QUEUE))
                            inputQueueList.Add(key, appSettings[key]);

                        if (key.Contains(MESSAGE_FROM_SERVER_QUEUE))
                            outputQueueList.Add(key, appSettings[key]);

                        if (key.Contains(OUTPUT_FILES_DIRECTORY_QUEUE))
                            outputDirectoryQueueList.Add(key, appSettings[key]);

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
                clientQueueList = null;
                inputQueueList = null;
                outputQueueList = null;
                outputDirectoryQueueList = null;

                return;
            }
        }
    }
}
