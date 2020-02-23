using System;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace chapter_12_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary;

            //new SyncPingPong().PingPong();
            //summary = BenchmarkRunner.Run<KernelVsUserMode>();
            //new SyncWaitMultiple().WaitMultiple();
            //new SyncShared().Run();

            Console.ReadKey();
        }
    }
}
