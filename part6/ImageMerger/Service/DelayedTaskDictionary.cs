using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMergerService
{
    public class DelayedTaskDictionary : IDisposable
    {
        private class DelayedAction : IDisposable
        {
            private bool isDisposedAction = false;

            public DelayedAction(Task task, CancellationTokenSource cancellationTokenSource)
            {
                Task = task;
                CancellationTokenSource = cancellationTokenSource;
            }

            public void Dispose()
            {
                if (isDisposedAction)
                    return;
                isDisposedAction = true;

                try
                {
                    Task.Wait();
                }
                catch (AggregateException e)
                {
                    LoggerUtil.LogNonCancellationExceptions(e);
                }
                Task.Dispose();
                CancellationTokenSource.Dispose();
            }

            public Task Task { get; private set; }
            public CancellationTokenSource CancellationTokenSource { get; private set; }
        }
        
        private readonly object lockObject = new object();
        
        private bool isDisposed;
        private readonly Dictionary<string, DelayedAction> tasks = new Dictionary<string, DelayedAction>();

        public void ReNew(string key, TimeSpan delay, Action action)
        {
            lock (lockObject)
            {
                Stop(key);
                
                var delayedTokenSource = new CancellationTokenSource();
                var task = RunDelayedActionAsync(delay, action, delayedTokenSource.Token);
                tasks[key] = new DelayedAction(task, delayedTokenSource);
            }
        }

        public void Stop(string key)
        {
            lock (lockObject)
            {
                DelayedAction oldDelayedAction;
                if (!tasks.TryGetValue(key, out oldDelayedAction))
                    return;

                oldDelayedAction.CancellationTokenSource.Cancel();
                oldDelayedAction.Dispose();

                tasks.Remove(key);
            }
        }

        private static async Task RunDelayedActionAsync(TimeSpan delay, Action action, CancellationToken token)
        {
            await Task.Delay(delay, token);
            action();
        }

        public void Dispose()
        {
            if (isDisposed)
                return;
            isDisposed = true;

            lock (lockObject)
            {
                foreach (var task in tasks.Keys.ToList())
                    Stop(task);
            }
        }
    }
}