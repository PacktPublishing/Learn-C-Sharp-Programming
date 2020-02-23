using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_04
{
    [TestClass]
    public class PatternMatching5
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(IsOnAxis(new Point(0, 10)));
            Assert.IsTrue(IsOnAxis(new Point(10, 0)));
            Assert.IsTrue(IsOnAxis(new Point(0, 0)));
            Assert.IsTrue(!IsOnAxis(new Point(10, 10)));

            Assert.AreEqual(SpecialPosition.YAxis, IsOnSpecialPosition(new Point(0, 10)));
            Assert.AreEqual(SpecialPosition.YAxis, IsOnSpecialPosition(new Point(0, -10)));

            Assert.AreEqual(SpecialPosition.XAxis, IsOnSpecialPosition(new Point(10, 0)));
            Assert.AreEqual(SpecialPosition.XAxis, IsOnSpecialPosition(new Point(-10, 0)));

            Assert.AreEqual(SpecialPosition.Origin, IsOnSpecialPosition(new Point(0, 0)));

            Assert.AreEqual(SpecialPosition.MainDiagonal, IsOnSpecialPosition(new Point(10, 10)));
            Assert.AreEqual(SpecialPosition.MainDiagonal, IsOnSpecialPosition(new Point(-10, -10)));

            Assert.AreEqual(SpecialPosition.AntiDiagonal, IsOnSpecialPosition(new Point(10, -10)));
            Assert.AreEqual(SpecialPosition.AntiDiagonal, IsOnSpecialPosition(new Point(-10, 10)));
        }

        public bool IsOnAxis(Point p) => p switch
        {
            (0, _) => true,
            (_, 0) => true,
            (_, _) => false,
        };

        SpecialPosition IsOnSpecialPosition(Point p) => p switch
        {
            (0, 0) => SpecialPosition.Origin,
            (0, _) => SpecialPosition.YAxis,
            (_, 0) => SpecialPosition.XAxis,
            var (x, y) when x == y => SpecialPosition.MainDiagonal,
            var (x, y) when x == -y => SpecialPosition.AntiDiagonal,
            _ => SpecialPosition.None,
        };

        enum SpecialPosition
        {
            None,
            Origin,
            XAxis,
            YAxis,
            MainDiagonal,
            AntiDiagonal,
        }

        public struct Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public void Deconstruct(out int x, out int y)
            {
                x = X;
                y = Y;
            }
        }
    }
}
