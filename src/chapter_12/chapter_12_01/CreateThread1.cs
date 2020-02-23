using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace chapter_12_01
{
    public class CreateThread1
    {
        public void Run()
        {
            Console.WriteLine("Start primes");
            PrintThreadInfo(Thread.CurrentThread);
            var t1 = new Thread(Worker);
            //t1.IsBackground = true; // try with/without this line
            t1.Start();
            Console.WriteLine("Primes calculation is happening in background");
        }

        private void Worker(object param)
        {
            PrintThreadInfo(Thread.CurrentThread);
            foreach (var n in new Primes(1000000))
            {
                Thread.Sleep(100);
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
