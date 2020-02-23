using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_04
{
    [TestClass]
    public class PatternMatching4
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(IsOnAnyAxis(new Point(0, 10)));
            Assert.IsTrue(IsOnAnyAxis(new Point(10, 0)));
            Assert.IsTrue(IsOnAnyAxis(new Point(0, 0)));
            Assert.IsTrue(!IsOnAnyAxis(new Point(10, 10)));
        }

        public bool IsOnAnyAxis(Point p) => (p.X, p.Y) switch
        {
            (0, _) => true,
            (_, 0) => true,
            _ => false,
        };

        public struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }


    }
}
