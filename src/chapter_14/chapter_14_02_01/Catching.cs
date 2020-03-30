using System;
using System.Diagnostics;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_01
{
    [TestClass]
    public class Catching
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReadTextFile2(false, "EmptyFile.txt");
            ReadTextFile3(false, "NotExistentFile.txt");

            Assert.IsNull(ReadTextFile(true, "//"));
            Assert.ThrowsException<IOException>(() => ReadTextFile(false, "//"));

            Assert.AreEqual(0, ReadTextFile2(true, "//"));
            Assert.AreEqual(0, ReadTextFile2(false, "//"));
        }

        public string ReadTextFile(bool validateExistence, string filename)
        {
            if (validateExistence && !File.Exists(filename)) return null;
            var content = File.ReadAllText(filename);
            return content;
        }

        public int ReadTextFile2(bool validateExistence, string filename)
        {
            try
            {
                if (validateExistence && !File.Exists(filename)) return 0;
                var content = File.ReadAllText(filename);
                return content.Length;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ReadTextFile3(bool validateExistence, string filename)
        {
            try
            {
                if (validateExistence && !File.Exists(filename)) return 0;
                var content = File.ReadAllText(filename);
                return content.Length;
            }
            catch (ArgumentNullException) { /* ... */ }
            catch (IOException) { /* ... */ }
            catch (UnauthorizedAccessException) { /* ... */ }
            catch (Exception) { /* ... */ }

            return 0;
        }

        public void CopyReversedTextFile(string source, string target)
        {
            try
            {
                var content = ReadTextFile(source);
                content = content.Replace("\r\n", "\r");
                WriteTextFile(target, content);
            }
            catch (IOException) { /*...*/ }
        }

        public string ReadTextFile(string filename)
        {
            try
            {
                var content = File.ReadAllText(filename);
                return content;
            }
            catch (ArgumentNullException) { /* ... */ }
            return null;
        }

        public void WriteTextFile(string filename, string content)
        {
            try
            {
                File.WriteAllText(filename, content);
            }
            catch (ArgumentNullException) { /* ... */ }
        }

    }


}
