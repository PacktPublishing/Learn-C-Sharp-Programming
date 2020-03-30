using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_06
{
    [TestClass]
    public class Rethrowing1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.ThrowsException<FileNotFoundException>(() => ReadAllText("abc.txt"));
        }

        public string ReadAllText(string filename)
        {
            try
            {
                return File.ReadAllText(filename);
            }
            catch (Exception err)
            {
                Log(err.ToString());
                //throw;
                throw err;
            }
        }

        private void Log(string content) { }
    }
}
