using System;

namespace ImageMergerService
{
    public static class LoggerUtil
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void LogException(Exception e)
        {
            logger.Error(e.GetType() + ": " + e.Message);
            logger.Error(e.StackTrace);
        }

        public static void LogNonCancellationExceptions(AggregateException e)
        {
            foreach (var innerException in e.InnerExceptions)
            {
                if (innerException is OperationCanceledException)
                    continue;

                LogException(innerException);
            }
        }
    }
}