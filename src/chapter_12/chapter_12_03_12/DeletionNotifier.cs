using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace chapter_12_03_12
{
    public class DeletionNotifier : IDisposable
    {
        private TaskCompletionSource<FileSystemEventArgs> _tcs;
        private FileSystemWatcher _watcher;

        public DeletionNotifier()
        {
            var path = Path.GetFullPath(".");
            Console.WriteLine($"Observing changes in path: {path}");
            _watcher = new FileSystemWatcher(path, "*.txt");
            _watcher.Deleted += (s, e) =>
            {
                _watcher.EnableRaisingEvents = false;
                _tcs.SetResult(e);
            };

            _watcher.Error += (s, e) =>
            {
                _watcher.EnableRaisingEvents = false;
                _tcs.SetException(e.GetException());
            };
        }

        public Task<FileSystemEventArgs> WhenDeleted()
        {
            _tcs = new TaskCompletionSource<FileSystemEventArgs>();
            _watcher.EnableRaisingEvents = true;
            return _tcs.Task;
        }

        public void Dispose() => _watcher.Dispose();
    }
}
