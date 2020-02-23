using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NickBuhro.Translit;

namespace chapter_15_02
{
    [TestClass]
    public class InterfaceMembers5
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = new CompositeTransliterator();
            var input = "Matryoshka";

            var russian = t.TransliterateCyrillic(input);
            Assert.AreEqual("Матрёшка", russian);
            var latin = t.TransliterateCyrillic(russian);
            Assert.AreEqual(input, latin);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var t = new CompositeTransliterator();
            var input = "你好";
            Assert.ThrowsException<NotImplementedException>(
                () => t.TransliterateCyrillic(input));
        }

        public interface ICyrillicToLatin
        {
            public string Convert(string input)
            {
                return Transliteration.CyrillicToLatin(input, Language.Russian);
            }
        }

        public interface ILatinToCyrillic
        {
            public string Convert(string input)
            {
                return Transliteration.LatinToCyrillic(input, Language.Russian);
            }
        }

        public class CompositeTransliterator : ICyrillicToLatin, ILatinToCyrillic
        {
            public string TransliterateCyrillic(string input)
            {
                string result;
                return this switch
                {
                    ICyrillicToLatin c when (result = c.Convert(input)) != input => result,

                    ILatinToCyrillic l when (result = l.Convert(input)) != input => result,

                    _ => throw new NotImplementedException("Can't find a suitable language"),
                };
            }
        }

    }
}
