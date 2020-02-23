using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_02
{
    [TestClass]
    public class InterfaceMembers1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICalc calc = new Calc();
            Assert.AreEqual(4, calc.Add(1, 3));
            Assert.AreEqual(3, calc.Mul(1, 3));
        }

        public class Calc : ICalc { }

        public interface ICalc
        {
            int Add(int x, int y) => x + y;
            int Mul(int x, int y) => x * y;
        }
    }
}
