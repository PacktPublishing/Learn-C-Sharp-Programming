using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_12
{
    public class DeletionNotifier2 : IDisposable
    {
        private TaskCompletionSource<FileSystemEventArgs> _tcs;
        private FileSystemWatcher _watcher;
        private ConcurrentQueue<FileSystemEventArgs> _queue;
        private Exception _error;

        public DeletionNotifier2()
        {
            var path = Path.GetFullPath(".");
            Console.WriteLine($"Observing changes in path: {path}");
            _queue = new ConcurrentQueue<FileSystemEventArgs>();
            _watcher = new FileSystemWatcher(path, "*.txt");
            _watcher.Deleted += (s, e) =>
            {
                _queue.Enqueue(e);
                _tcs.TrySetResult(e);
            };
            _watcher.Error += (s, e) =>
            {
                _watcher.EnableRaisingEvents = false;
                _error = e.GetException();
                _tcs.TrySetException(_error);
            };
            _watcher.EnableRaisingEvents = true;
        }

        public Task<FileSystemEventArgs> WhenDeleted()
        {
            if (_queue.TryDequeue(out FileSystemEventArgs fsea))
                return Task.FromResult(fsea);

            if (_error != null)
                return Task.FromException<FileSystemEventArgs>(_error);

            _tcs = new TaskCompletionSource<FileSystemEventArgs>();
            return _tcs.Task;
        }

        public void Dispose() => _watcher.Dispose();
    }
}
