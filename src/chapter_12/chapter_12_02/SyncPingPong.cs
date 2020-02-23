using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace chapter_12_02
{
    public class SyncPingPong
    {
        public void PingPong()
        {
            bool quit = false;
            var ping = new ManualResetEventSlim(false);
            var pong = new ManualResetEventSlim(false);
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"Ping thread: {Thread.CurrentThread.ManagedThreadId}");
                while (!quit)
                {
                    pong.Wait();
                    pong.Reset();
                    Console.WriteLine("Ping");
                    Thread.Sleep(1000);
                    ping.Set();
                }
            });
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"Pong thread: {Thread.CurrentThread.ManagedThreadId}");
                while (!quit)
                {
                    ping.Wait();
                    ping.Reset();
                    Console.WriteLine("Pong");
                    Thread.Sleep(1000);
                    pong.Set();
                }
            });

            pong.Set();
            Console.ReadKey();
            quit = true;
        }

    }
}
