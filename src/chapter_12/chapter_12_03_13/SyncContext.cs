using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace chapter_12_03_13
{
    class SyncContext
    {
        public async Task AsyncTest1()
        {
            Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(100);
            Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(100);
            Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// Experiment by uncommenting the ConfigureAwait statement
        /// </summary>
        /// <returns></returns>
        public async Task AsyncLoop()
        {
            Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
            byte[] data;
            while((data = await GetNextAsync()
                //.ConfigureAwait(false)
                ).Length > 0)
            {
                Console.WriteLine($"Id: {Thread.CurrentThread.ManagedThreadId}");
                // process data
            }
        }

        private int[] _simulateInt = new[] { 1000, 900, 1000, 1000, 0 };
        private int _index = 0;
        public async Task<byte[]> GetNextAsync()
        {
            byte[] data;
            if (_index < _simulateInt.Length)
            {
                await Task.Delay(100);
                var result = _simulateInt[_index];
                data = Enumerable.Range(0, result).Select(s => (byte)s).ToArray();
                _index++;
                return data;
            }

            data = Array.Empty<byte>();
            return data;
        }

    }
}
