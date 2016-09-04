using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMergerService
{
    public class ServiceTask : IDisposable
    {
            private bool isDisposed = false;

            public Task CurrentTask { get; private set; }
            public CancellationTokenSource CancellationTokenSource { get; private set; }

            public ServiceTask(Task task, CancellationTokenSource cancellationTokenSource)
            {
                CurrentTask = task;
                CancellationTokenSource = cancellationTokenSource;
            }

            public void Dispose()
            {
                if (isDisposed)
                    return;
                isDisposed = true;

                try
                {
                    CurrentTask.Wait();
                }
                catch (AggregateException e)
                {
                    LoggerUtil.LogNonCancellationExceptions(e);
                }
                CurrentTask.Dispose();
                CancellationTokenSource.Dispose();
            }
    }
}
