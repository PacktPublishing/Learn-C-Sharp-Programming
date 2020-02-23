using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_08
{
    [TestClass]
    public class AsyncStreams1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var iterated = new List<int>();
            foreach (var item in SyncIterator())
            {
                iterated.Add(item);
            }
            Assert.IsTrue(iterated.Count == 10);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var iterated = new List<int>();
            foreach (var item in new SyncSequence())
            {
                iterated.Add(item);
            }
            Assert.IsTrue(iterated.Count == 10);
        }

        static IEnumerable<int> SyncIterator()
        {
            foreach (var item in Enumerable.Range(0, 10))
            {
                Thread.Sleep(500);
                yield return item;
            }
        }

        public class SyncSequence : IEnumerable<int>
        {
            private int[] _data = Enumerable.Range(0, 10).ToArray();

            public IEnumerator<int> GetEnumerator() => new SyncSequenceEnumerator<int>(_data);
            IEnumerator IEnumerable.GetEnumerator() => new SyncSequenceEnumerator<int>(_data);

            private class SyncSequenceEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
            {
                private T[] _sequence;
                private int _index;

                public SyncSequenceEnumerator(T[] sequence)
                {
                    _sequence = sequence;
                    _index = -1;
                }

                object IEnumerator.Current => _sequence[_index];
                public T Current => _sequence[_index];
                public void Dispose() { }
                public void Reset() => _index = -1;

                public bool MoveNext()
                {
                    Thread.Sleep(100);
                    _index++;
                    if (_sequence.Length <= _index) return false;
                    return true;
                }

            }
        }

    }
}
