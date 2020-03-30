using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using BenchmarkDotNet.Attributes;


namespace chapter_14_02_04_benchmark
{
    [MemoryDiagnoser]
    public class ThrowingPerf
    {
        public int Loop { get; } = 1000;

        [Benchmark]
        public void LoopNop()
        {
            for (var i = 0; i < Loop; i++)
            {
                try
                {
                    Nop(i);
                }
                catch (Exception) { }
            }
        }

        [Benchmark]
        public void LoopEx()
        {
            for (var i = 0; i < Loop; i++)
            {
                try
                {
                    Crash(i);
                }
                catch (Exception) { }
            }
        }


        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void Nop(int i)
        {
        }

        [MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
        private void Crash(int i)
        {
            throw new InvalidOperationException();
        }


    }
}
