using System;
using System.Diagnostics;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_14_02_02
{
    [TestClass]
    public class ExceptionObject
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sizes = GetFileLengths("DeBelloGallico_LiberI.txt", "EmptyFile.txt");
            Assert.AreEqual(2, sizes.Length);
            Assert.AreEqual(0, sizes[1]);
        }

        int[] GetFileLengths(params string[] filenames)
        {
            try
            {
                var sizes = new int[filenames.Length];
                int i = 0;
                foreach (var filename in filenames)
                {
                    var content = File.ReadAllText(filename);
                    sizes[i++] = content.Length;  // may differ from file size
                }
                return sizes;
            }
            catch (FileNotFoundException err)
            {
                Debug.WriteLine($"Cannot find {err.FileName}");
                return null;
            }
        }


    }
}
