using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace chapter_12_01
{
    public class CreateThread2
    {
        [DllImport("Kernel32.dll")]
        private static extern int GetCurrentThreadId();
        private bool _useAffinity = false;

        public void Run1()
        {
            Console.WriteLine("Start primes");
            PrintThreadInfo(Thread.CurrentThread);
            var t1 = new Thread(Worker);
            t1.IsBackground = true;
            t1.Start();
            Console.WriteLine("Primes calculation is happening in background");
        }

        public void Run2()
        {
            Console.WriteLine("Start primes");
            PrintThreadInfo(Thread.CurrentThread);
            _useAffinity = false;
            ThreadPool.QueueUserWorkItem(Worker);
            Console.WriteLine("Primes calculation is happening in background");
        }

        public void Run3()
        {
            Console.WriteLine("Start primes");
            PrintThreadInfo(Thread.CurrentThread);
            ConsoleKeyInfo k;
            AutoResetEvent evt = null;
            var isFirstTime = true;
            do
            {
                if (isFirstTime)
                {
                    isFirstTime = false;
                    _useAffinity = true;
                    evt = new AutoResetEvent(false);
                }
                else
                {
                    _useAffinity = false;
                    evt.Set();
                    evt = new AutoResetEvent(false);
                }
                ThreadPool.QueueUserWorkItem(Worker, evt);
                
            }
            while ((k = Console.ReadKey()).Key != ConsoleKey.Q);
            Console.WriteLine("Primes calculation is happening in background");
        }

        private void Worker(object param)
        {
            AutoResetEvent evt = param as AutoResetEvent;
            if (_useAffinity)
            {
                Console.WriteLine("Running with affinity on");
                var threads = System.Diagnostics.Process.GetCurrentProcess().Threads;
                var processThread = threads
                    .OfType<System.Diagnostics.ProcessThread>()
                    .Where(pt => pt.Id == GetCurrentThreadId())
                    .Single();
                processThread.ProcessorAffinity = (IntPtr)2;
            }
            else
            {
                Console.WriteLine("Running with affinity off");
            }

            PrintThreadInfo(Thread.CurrentThread);
            foreach (var n in new Primes(1000000))
            {
                if (evt != null && evt.WaitOne(0))
                {
                    Console.WriteLine($"Id:{Thread.CurrentThread.ManagedThreadId} terminated");
                    return;
                }
                //Thread.Sleep(100);
            }
            Console.WriteLine("Computation ended!");
        }

        private void PrintThreadInfo(Thread t)
        {
            var sb = new StringBuilder();
            var state = t.ThreadState;
            sb.Append($"Id:{t.ManagedThreadId} Name:{t.Name} State:{state} ");
            if ((state & (ThreadState.Stopped | ThreadState.Unstarted)) == 0)
            {
                sb.Append($"Priority:{t.Priority} IsBackground:{t.IsBackground}");
            }

            Console.WriteLine(sb.ToString());
        }

    }
}
