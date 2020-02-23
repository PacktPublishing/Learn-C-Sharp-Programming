using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_03.RangesIndices1
{
    [TestClass]
    public class RangesIndices1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var length = countries.Length;

            // first item from the beginning is zero
            Assert.IsTrue(countries[0] == "Italy");
            var italyIndex = new Index(0);
            Assert.IsTrue(countries[0] == countries[italyIndex]);

            // first item from the end is length - 1
            Assert.IsTrue(countries[length - 1] == "England");
            var englandIndex = new Index(1, true);
            Assert.IsTrue(countries[length - 1] == countries[englandIndex]);
            Assert.IsTrue(countries[^1] == countries[englandIndex]);

            Assert.ThrowsException<IndexOutOfRangeException>(() => countries[^0]);
        }

        [TestMethod]
        public void TestRangeAll()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var expected = countries.ToArray();

            var all1 = countries[..];
            var all2 = countries[0..^0];
            var allRange = new Range(0, new Index(0, true));
            var all3 = countries[allRange];
            var all4 = Range.All;
            Assert.IsTrue(expected.SequenceEqual(all1));
            Assert.IsTrue(expected.SequenceEqual(all2));
            Assert.IsTrue(expected.SequenceEqual(all3));
        }

        [TestMethod]
        public void TestRangeSkipFirst()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var expected = new[] { "Romania", "Switzerland", "Germany", "France", "England" };

            var skipFirst1 = countries[1..];
            var skipFirst2 = countries[1..^0];
            var skipFirstRange = new Range(1, new Index(0, true));
            var skipFirst3 = countries[skipFirstRange];
            Assert.IsTrue(expected.SequenceEqual(skipFirst1));
            Assert.IsTrue(expected.SequenceEqual(skipFirst2));
            Assert.IsTrue(expected.SequenceEqual(skipFirst3));
        }

        [TestMethod]
        public void TestRangeSkipLast()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var expected = new[] { "Italy", "Romania", "Switzerland", "Germany", "France" };

            var skipLast1 = countries[..^1];
            var skipLast2 = countries[0..^1];
            var skipLastRange = new Range(0, new Index(1, true));
            var skipLast3 = countries[skipLastRange];
            Assert.IsTrue(expected.SequenceEqual(skipLast1));
            Assert.IsTrue(expected.SequenceEqual(skipLast2));
            Assert.IsTrue(expected.SequenceEqual(skipLast3));
        }

        [TestMethod]
        public void TestRangeSkipFirstAndLast()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var expected = new[] { "Romania", "Switzerland", "Germany", "France" };

            var skipFirstAndLast1 = countries[1..^1];
            var skipFirstAndLastRange = new Range(1, new Index(1, true));
            var skipFirstAndLast2 = countries[skipFirstAndLastRange];
            Assert.IsTrue(expected.SequenceEqual(skipFirstAndLast1));
            Assert.IsTrue(expected.SequenceEqual(skipFirstAndLast2));
        }

        [TestMethod]
        public void TestRangeSecondAndThird()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var expected = new[] { "Romania", "Switzerland" };

            var skipSecondAndThird1 = countries[1..3];
            var skipSecondAndThirdRange = new Range(1, 3);
            var skipSecondAndThird2 = countries[skipSecondAndThirdRange];
            Assert.IsTrue(expected.SequenceEqual(skipSecondAndThird1));
            Assert.IsTrue(expected.SequenceEqual(skipSecondAndThird2));
        }

        [TestMethod]
        public void TestRangeFromEnd()
        {
            var countries = new[] { "Italy", "Romania", "Switzerland", "Germany", "France", "England" };
            var expected = new[] { "Germany", "France" };

            var fromEnd1 = countries[^3..^1];
            var fromEndRange = new Range(new Index(3, true), new Index(1, true));
            var fromEnd2 = countries[fromEndRange];
            Assert.IsTrue(expected.SequenceEqual(fromEnd1));
            Assert.IsTrue(expected.SequenceEqual(fromEnd2));
        }
    }
}
