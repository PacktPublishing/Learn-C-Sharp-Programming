using System;
using System.Diagnostics;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_03
{
    [TestClass]
    public class ConditionalCatch
    {
        [TestMethod]
        public void TestMethod1()
        {
            CopyFrom(null);
            Assert.ThrowsException<ArgumentNullException>(() => CopyFrom2(null));
            CopyFrom3("EmptyFile.txt");
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                File.Copy(null, null);
            }
            catch (FileNotFoundException err)
            {
                Debug.WriteLine($"Can't find: {err.FileName}");
                Assert.Fail();
                return;
            }
            catch (ArgumentNullException)
            {
                return; // ok
            }

            Assert.Fail();
        }

        private void CopyFrom(string source)
        {
            try
            {
                var target = CreateFilename(source);
                File.Copy(source, target);
            }
            catch (ArgumentException err)
            {
                Debug.WriteLine($"The parameter {err.ParamName} is invalid");
                return;
            }
        }

        private void CopyFrom2(string source)
        {
            try
            {
                var target = CreateFilename(source);
                File.Copy(source, target);
            }
            catch (ArgumentException err) when (err.ParamName == "destFileName")
            {
                Debug.WriteLine($"The parameter {err.ParamName} is invalid");
                return;
            }
        }

        private void CopyFrom3(string source)
        {
            var target = CreateFilename(source);
            try
            {
                File.Copy(source, target);
            }
            catch (ArgumentException err) when (target is null)
            {
                Debug.WriteLine($"The parameter {err.ParamName} is invalid");
                return;
            }
        }

        /// <summary>
        /// The generated filename is wrong on purpose
        /// </summary>
        string CreateFilename(string name) => null;//$"//{name}";


    }
}
