using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;


namespace chapter_12_01
{
    public class FileWatcher
    {
        private FileSystemWatcher _watcher;
        public void Run()
        {
            var path = Path.GetFullPath(".");
            Console.WriteLine($"Observing changes in path: {path}");
            _watcher = new FileSystemWatcher(path, "*.txt");
            _watcher.Created += Watcher_Created;
            _watcher.Deleted += Watcher_Deleted;
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}");
            _watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted occurred in TID: {Thread.CurrentThread.ManagedThreadId}");
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Created occurred in TID: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
