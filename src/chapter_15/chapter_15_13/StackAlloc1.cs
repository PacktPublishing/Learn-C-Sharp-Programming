using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_13
{
    [TestClass]
    public class StackAlloc1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = " this string can be trimmed \r\n";
            var expected = "this string can be trimmed";
            ReadOnlySpan<char> trimmedSpan = input.AsSpan().Trim(stackalloc[] { ' ', '\r', '\n' });
            string result = trimmedSpan.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
