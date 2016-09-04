using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ImageMergerServerService
{
    public sealed class QueueUtils
    {
        public enum CommandType
        {
            Unknown = 0,
            StartWorkQueue = 1,
            StopWorkQueue = 2
        }

        public enum ConfigListParamType
        {
            Unknown = 0,
            ClientQueueList = 1,
            InputQueueList = 2,
            OutputQueueList = 3,
            OutputDirectoryQueueList = 4
        }

        public class QueueSystemMessage
        {
            public string clientName = "";
            public CommandType commandType = 0;

            public QueueSystemMessage()
            {
            }

            public QueueSystemMessage(string clientName, CommandType commandType)
            {
                this.clientName = clientName;
                this.commandType = commandType;
            }
        }

        public class QueueMessage
        {
            public string clientName = "";
            public int partNumber = 0;
            public long partSize = 0;
            public Byte[] partFile;

            public string fileName = "";
            public int partsCount = 0;

            public QueueMessage()
            {
            }

            public QueueMessage(string clientName, int partNumber, long partSize, Byte[] partFile, string fileName, int partsCount)
            {
                this.clientName = clientName;
                this.partNumber = partNumber;
                this.partSize = partSize;
                this.partFile = partFile;
                this.fileName = fileName;
                this.partsCount = partsCount;
            }
        }

        public static bool MSMQueueCreate(string messageQueue)
        {
            try
            {
                if (!MessageQueue.Exists(messageQueue))
                    MessageQueue.Create(messageQueue, true);

                return true;
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
                return false;
            }
        }

        public static bool IsMSMQueueConnected(string messageToServerQueue, string messageFromServerQueue)
        {
            bool result = false;
            try
            {
                if (!MessageQueue.Exists(messageToServerQueue) || !MessageQueue.Exists(messageFromServerQueue))
                    LoggerUtil.logger.Error(String.Format("Не верно указаны параметры подключения к очередям для сервера MSMQueue:\n" +
                        "Очередь для исходящих сообщений = {0}\n или \n" + "Очередь для входящих сообщений = {1}\n" +
                        "не найдены на сервере MSMQueue!", messageFromServerQueue, messageToServerQueue));
                else result = true;
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
            }

            return result;
        }

        public static bool IsMSMQueueConnected(string messageQueue)
        {
            bool result = false;
            try
            {
                if (!MessageQueue.Exists(messageQueue))
                    LoggerUtil.logger.Error(String.Format("Не верно указан параметр подключения к очереди на сервере MSMQueue:\n" +
                        "Очередь сообщений = {0} не найдена на сервере MSMQueue!", messageQueue));
                else result = true;
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
            }

            return result;
        }
    }
}
