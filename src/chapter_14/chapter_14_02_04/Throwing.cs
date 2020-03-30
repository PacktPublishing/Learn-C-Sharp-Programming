using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_04
{
    [TestClass]
    public class Throwing
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ReadLog0(null));
            Assert.ThrowsException<NullReferenceException>(() => ReadLog1(null));
            Assert.ThrowsException<ArgumentNullException>(() => ReadLog2(null));
        }

        private string ReadLog0(string logName)
        {
            return File.ReadAllText(logName);
        }

        private string ReadLog1(string logName)
        {
            var filename = "App-" + (logName.EndsWith(".log") ? logName : logName + ".log");
            return File.ReadAllText(filename);
        }

        private string ReadLog2(string logName)
        {
            if (logName == null) throw new ArgumentNullException(nameof(logName));
            var filename = "App-" + (logName.EndsWith(".log") ? logName : logName + ".log");
            return File.ReadAllText(filename);
        }



    }
}
