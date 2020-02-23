using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_08
{
    [TestClass]
    public class AsyncStreams3
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var iterated = new List<int>();
            var sequence = new AsyncSequence();
            await foreach (var item in sequence)
            {
                iterated.Add(item);
            }
            Assert.IsTrue(iterated.Count == 10);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            var iterated = new List<int>();
            var sequence = new AsyncSequence();
            IAsyncEnumerator<int> enumerator = sequence.GetAsyncEnumerator();
            try
            {
                while (await enumerator.MoveNextAsync())
                {
                    iterated.Add(enumerator.Current);
                }
            }
            finally { await enumerator.DisposeAsync(); }
            Assert.IsTrue(iterated.Count == 10);
        }

        public class AsyncSequence : IAsyncEnumerable<int>
        {
            private int[] _data = Enumerable.Range(0, 10).ToArray();
            public IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            {
                return new MyAsyncEnumerator<int>(_data);
            }

            private class MyAsyncEnumerator<T> : IAsyncEnumerator<T>
            {
                private T[] _sequence;
                private int _index;
                public MyAsyncEnumerator(T[] sequence)
                {
                    _sequence = sequence;
                    _index = -1;
                }

                public T Current => _sequence[_index];
                public ValueTask DisposeAsync() => default(ValueTask);
                public async ValueTask<bool> MoveNextAsync()
                {
                    await Task.Delay(500);
                    _index++;
                    if (_sequence.Length <= _index) return false;
                    return true;
                }
            }
        }
    }
}
