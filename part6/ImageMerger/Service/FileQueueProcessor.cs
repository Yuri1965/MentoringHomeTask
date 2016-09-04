using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMergerService
{
    public class FileQueueProcessor
    {
        private readonly string inputDirectory;
        private string messageToServerQueue;
        private string clientName;
        private double delayTimeMSMQueueConnect;
        private int fileMessagePartSize;

        private Dictionary<int, Byte[]> partsFile = new Dictionary<int, Byte[]>();

        public FileQueueProcessor(string inputDirectory)
        {
            this.inputDirectory = inputDirectory;

            messageToServerQueue = ApplicationConfigParameters.GetInstance().GetMessageToServerQueue();
            clientName = ApplicationConfigParameters.GetInstance().GetClientName();
            delayTimeMSMQueueConnect = ApplicationConfigParameters.GetInstance().GetDelayTimeMSMQueueConnect();
            fileMessagePartSize = ApplicationConfigParameters.GetInstance().GetFileMessagePartSize();
        }

        public async void ProcessFile(string file, CancellationToken token)
        {
            SplitFile(file);

            if (partsFile.Count == 0)
            {
                LoggerUtil.logger.Error(String.Format("Не удалось разбить файл {0} на части для передачи на сервер MSMQueue!", file));
                return;
            }

            QueueUtils.QueueMessage message;
            Byte[] partFile;

            //используем очередь в которой клиент посылает сообщения серверу
            using (MessageQueue serverQueue = new MessageQueue(messageToServerQueue, QueueAccessMode.Send))
            {
                //если нет доступа к очереди, то будем ждать пока он не появится
                while (!QueueUtils.IsMSMQueueConnected(messageToServerQueue) || !QueueUtils.IsWorkQueue())
                    await Task.Delay(TimeSpan.FromSeconds((int)delayTimeMSMQueueConnect), token);

                using (var trans = new MessageQueueTransaction())
                {
                    try
                    {
                        //открываем транзакцию, чтобы отправить все части файла разом
                        trans.Begin();

                        //формируем сообщения и отправляем их в очередь на сервер
                        int countParts = partsFile.Count;
                        for (int i = 1; i <= countParts; i++)
                        {
                            if (partsFile.TryGetValue(i, out partFile))
                            {
                                message = new QueueUtils.QueueMessage(clientName, i, partFile.LongLength, partFile, Path.GetFileNameWithoutExtension(file), countParts);
                                string label = Path.GetFileNameWithoutExtension(file) + "_part" + i.ToString();

                                serverQueue.Send(message, label, trans);
                            }
                        }
                        
                        trans.Commit();

                        //если все отправили, то удаляем файл
                        File.Delete(file);
                    }
                    catch (Exception e)
                    {
                        LoggerUtil.LogException(e);
                        
                        //откат транзакции если ошибка
                        trans.Abort();
                    }
                }
            }
        }

        /// <summary>
        /// Split file (разбиение файла на части для отправки на сервер)
        /// </summary>
        /// <param name="file">full file name (include path)</param>
        private void SplitFile(string file)
        {
            try
            {
                partsFile.Clear();

                if (!File.Exists(file))
                {
                    LoggerUtil.logger.Error(String.Format("Файл {0} не найден!", file));
                    return;
                }

                //ожидаем если вдруг файл занят другим процессом
                if (ImageToPdfFileMerger.TryOpenFile(file))
                {
                    Byte[] byteSource = File.ReadAllBytes(file);
                    Byte[] partSource;

                    int countParts = (int)Math.Ceiling((double)(byteSource.LongLength / fileMessagePartSize));
                    if (byteSource.LongLength > (long)(countParts * fileMessagePartSize))
                        countParts++;

                    long fileOffset = 0;

                    long sizeRemaining = 0;
                    long partSize = fileMessagePartSize;

                    for (int i = 0; i < countParts; i++)
                    {
                        sizeRemaining = byteSource.LongLength - (i * partSize);
                        if (sizeRemaining < partSize)
                        {
                            partSize = sizeRemaining;
                        }

                        partSource = new byte[partSize];
                        Array.Copy(byteSource, fileOffset, partSource, 0, partSize);
                        partsFile.Add(i + 1, partSource);

                        fileOffset += partSize;
                    }
                }
            }
            catch (Exception e)
            {
                LoggerUtil.LogException(e);
            }
        }

    }
}
