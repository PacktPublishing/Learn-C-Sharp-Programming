using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace chapter_12_02
{
    public class KernelVsUserMode
    {
        private ManualResetEvent kernelMode = new ManualResetEvent(false);
        private ManualResetEventSlim userMode = new ManualResetEventSlim(false);

        [Benchmark]
        public void KernelModeEvent()
        {
            kernelMode.Set();
            kernelMode.Reset();
        }

        [Benchmark]
        public void UserModeEvent()
        {
            userMode.Set();
            userMode.Reset();
        }
    }
}
