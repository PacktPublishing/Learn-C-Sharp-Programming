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
    public class AsyncStreams4
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var iterated = new List<int>();
            await foreach (var item in AsyncIterator().ConfigureAwait(false))
            {
                iterated.Add(item);
            }
            Assert.IsTrue(iterated.Count == 10);
        }

        async IAsyncEnumerable<int> AsyncIterator()
        {
            foreach (var item in Enumerable.Range(0, 10))
            {
                await Task.Delay(500);
                yield return item;
            }
        }
    }
}
