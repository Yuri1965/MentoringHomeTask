using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ImageMerger
{
    [LogMethodParams]
    public class AsyncQueue<T>
    {
        private readonly object lockObject = new object();
        private bool wasCancelled = false;
        private readonly Queue<T> items = new Queue<T>();
        private readonly Queue<TaskCompletionSource<T>> awaiters = new Queue<TaskCompletionSource<T>>();

        public AsyncQueue(CancellationToken token)
        {
            token.Register(() =>
            {
                CancelAllAwaiters();
            });
        }

        public void Enqueue(T item)
        {
            lock (lockObject)
            {
                if (awaiters.Count == 0)
                {
                    items.Enqueue(item);
                    return;
                }

                var completionSource = awaiters.Dequeue();
                completionSource.SetResult(item);
            }
        }

        public Task<T> Dequeue()
        {
            lock (lockObject)
            {
                var completionSource = new TaskCompletionSource<T>();
                if (wasCancelled)
                {
                    completionSource.SetCanceled();
                    return completionSource.Task;
                }
                if (items.Count > 0)
                {
                    var item = items.Dequeue();
                    completionSource.SetResult(item);
                }
                else
                {
                    awaiters.Enqueue(completionSource);
                }
                return completionSource.Task;
            }
        }

        private void CancelAllAwaiters()
        {
            lock (lockObject)
            {
                wasCancelled = true;
                foreach (var taskCompletionSource in awaiters)
                    taskCompletionSource.SetCanceled();
                awaiters.Clear();
            }
        }
    }
}