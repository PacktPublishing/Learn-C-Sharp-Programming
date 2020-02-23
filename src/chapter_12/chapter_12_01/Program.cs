using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;


namespace chapter_12_01
{
    class Program
    {
        [DllImport("Kernel32.dll")]
        private static extern int GetCurrentThreadId();

        static void Main(string[] args)
        {
            //PrintIds();
            //UsingFileWatcher1();
            //UsingBlockingPrimes();
            //new CreateThread1().Run();
            //new CreateThread2().Run1();
            //new CreateThread2().Run2();
            //new CreateThread2().Run3();

            Console.ReadKey();
        }

        private static void PrintIds()
        {
            Console.WriteLine($"Current Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Current Native Thread Id: {GetCurrentThreadId()}");
        }

        private static void UsingFileWatcher1()
        {
            var fw = new FileWatcher();
            fw.Run();
        }

        private static void UsingBlockingPrimes()
        {
            Console.WriteLine("Start primes");
            foreach (var n in new Primes(1000000)) {  /* ...  */ }
            Console.WriteLine("End primes"); // the wait is too long!
        }


    }
}
