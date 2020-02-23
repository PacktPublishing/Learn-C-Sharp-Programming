using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_04
{
    [TestClass]
    public class PatternMatching1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Color.Red, ToColor(ConsoleKey.R));
            Assert.AreEqual(Color.Green, ToColor(ConsoleKey.G));
            Assert.AreEqual(Color.Blue, ToColor(ConsoleKey.B));
            Assert.ThrowsException<ArgumentException>(() => ToColor(ConsoleKey.Z));
        }

        public Color ToColor(ConsoleKey key) => key switch
        {
            ConsoleKey.R => Color.Red,
            ConsoleKey.G => Color.Green,
            ConsoleKey.B => Color.Blue,
            _ => throw new ArgumentException($"Invalid {nameof(key)}"),
        };

        public Color ToColor0(ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.R => Color.Red,
                ConsoleKey.G => Color.Green,
                ConsoleKey.B => Color.Blue,
                _ => throw new ArgumentException($"Invalid {nameof(key)}"),
            };
        }

    }
}
