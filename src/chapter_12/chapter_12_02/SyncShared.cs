using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace chapter_12_02
{
    public class SyncShared
    {
        public void Run()
        {
            for (int i = 0; i < 15; i++)
            {
                SharedResource();
            }
        }

        int _shared;
        int Shared
        {
            get => _shared;
            set { Thread.Sleep(1); _shared = value; }
        }
        ManualResetEvent evt = new ManualResetEvent(false);
        object sync = new object();

        private void SharedResource()
        {
            Shared = 0;
            var loop = 100;
            var threads = new List<Thread>();
            for (int i = 0; i < loop; i++)
            {
                var t = new Thread(() =>
                {
                    evt.WaitOne();

                    /*
                    There are two ways to protect the shared resource:
                    - using the lock statement
                    - using the Interlocked class
                    Experiment with one of the two or without any to see the problem
                    */

                    //lock (sync)
                    {
                        Shared++;
                    }

                    //Interlocked.Increment(ref _shared);
                });
                t.Start();
                threads.Add(t);
            }

            evt.Set(); // make all threads start together
            foreach (var t in threads)
                t.Join();   // wait for the thread to finish
            Console.WriteLine($"actual:{Shared}, expected:{loop}");
        }


    }
}
