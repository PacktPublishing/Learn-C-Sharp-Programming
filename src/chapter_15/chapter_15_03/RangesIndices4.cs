using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_03.RangesIndices4
{
    [TestClass]
    public class RangesIndices4
    {
        [TestMethod]
        public void TestMethod1()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" }
                        .ToList();
            var expected = new[] { "Romania", "Switzerland", "Germany", "France" };

            //var sliced = countries[1..^1];    // not supported by List<T>
            var sliced = countries.Slice(1..^1);
            Assert.IsTrue(expected.SequenceEqual(sliced));
        }

    }

    public static class CollectionExtensions
    {
        public static IEnumerable<T> Slice<T>(this ICollection<T> items, Range range)
        {
            (var offset, var count) = range.GetOffsetAndLength(items.Count);
            return items.Skip(offset).Take(count);
        }
    }
}
