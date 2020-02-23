using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_03.RangesIndices3
{
    [TestClass]
    public class RangesIndices3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var countries = new MyList<string>(new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" });
            var expected = new[] { "Romania", "Switzerland", "Germany", "France" };

            MyList<string> sliced = countries[1..^1];
            Assert.IsTrue(expected.SequenceEqual(sliced));
        }

    }

    public class MyList<T> : List<T>
    {
        public MyList() { }
        public MyList(IEnumerable<T> items) : base(items) { }

        public MyList<T> Slice(int offset, int count)
        {
            return new MyList<T>(this.GetRange(offset, count));
        }
    }

}
