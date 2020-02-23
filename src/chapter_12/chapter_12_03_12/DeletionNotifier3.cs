using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_12
{
    public class DeletionNotifier3 : IDisposable
    {
        private CustomAwaiter<FileSystemEventArgs> _tcs;
        private FileSystemWatcher _watcher;
        private ConcurrentQueue<FileSystemEventArgs> _queue;
        private Exception _error;

        public DeletionNotifier3()
        {
            var path = Path.GetFullPath(".");
            Console.WriteLine($"Observing changes in path: {path}");
            _queue = new ConcurrentQueue<FileSystemEventArgs>();
            _watcher = new FileSystemWatcher(path, "*.txt");
            _watcher.Deleted += (s, e) =>
            {
                _queue.Enqueue(e);
                if(_queue.TryDequeue(out FileSystemEventArgs top))
                    _tcs.TrySetResult(top);
            };
            _watcher.Error += (s, e) =>
            {
                _watcher.EnableRaisingEvents = false;
                _error = e.GetException();
                _tcs.TrySetException(_error);
            };
            _watcher.EnableRaisingEvents = true;
        }

        public CustomAwaiter<FileSystemEventArgs> WhenDeleted()
        {
            if (_queue.TryDequeue(out FileSystemEventArgs fsea))
                return _tcs.FromResult(fsea);

            if (_error != null)
                return _tcs.FromException(_error);

            _tcs = new CustomAwaiter<FileSystemEventArgs>();
            return _tcs.Task;
        }

        public void Dispose() => _watcher.Dispose();
    }

    public class CustomAwaiter<T> : INotifyCompletion
    {
        private Exception _error;
        private T _result;
        private Action _continuation;
        public CustomAwaiter<T> GetAwaiter() => this;

        public CustomAwaiter<T> Task => this;
        public bool IsCompleted { get; private set; }

        void INotifyCompletion.OnCompleted(Action continuation)
        {
            _continuation ??= continuation;
        }

        public T GetResult()
        {
            if (_error != null) throw _error;
            return _result;
        }

        public bool TrySetResult(T result)
        {
            if (IsCompleted) return false;
            IsCompleted = true;
            _result = result;
            _continuation?.Invoke();
            return true;
        }

        public bool TrySetException(Exception exception)
        {
            if (IsCompleted) return false;
            IsCompleted = true;
            _error = exception;
            _continuation?.Invoke();
            return true;
        }

        public void Reset()
        {
            IsCompleted = false;
            _result = default(T);
            _error = null;
            _continuation = null;
        }

        public CustomAwaiter<T> FromResult(T result)
        {
            Reset();
            TrySetResult(result);
            return this;
        }

        public CustomAwaiter<T> FromException(Exception exception)
        {
            Reset();
            TrySetException(exception);
            return this;
        }

    }
}
