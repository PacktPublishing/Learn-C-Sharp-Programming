using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace chapter_12_02
{
    public class SyncWaitMultiple
    {
        public void WaitMultiple()
        {
            var one = new ManualResetEvent(false);
            var two = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(3000);
                one.Set();
            });
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(2000);
                two.Set();
            });

            // change the wait time above 2000 and 300 to see a different result
            int signaled = WaitHandle.WaitAny(
                new WaitHandle[] { one, two }, 500);
            switch (signaled)
            {
                case 0:
                    Console.WriteLine("One was set");
                    break;
                case 1:
                    Console.WriteLine("Two was set");
                    break;
                case WaitHandle.WaitTimeout:
                    Console.WriteLine("Time expired");
                    break;
            }
        }

    }
}
