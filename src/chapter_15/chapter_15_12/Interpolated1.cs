using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_12
{
    [TestClass]
    public class Interpolated1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s1 = "c:\\temp";
            string s2 = @"c:\temp";
            Assert.AreEqual(s1, s2);

            var folder = "temp";
            var s3 = $"The path for {folder} is c:\\{folder}";
            var s4 = $@"The path for {folder} is c:\{folder}";
            Assert.AreEqual(s3, s4);
            var s5 = @$"The path for {folder} is c:\{folder}";
            Assert.AreEqual(s3, s5);
        }
    }
}
