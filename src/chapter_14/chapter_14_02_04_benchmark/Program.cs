using System;

using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;


namespace chapter_14_02_04_benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary;
            summary = BenchmarkRunner.Run<ThrowingPerf>();
        }
    }
}
