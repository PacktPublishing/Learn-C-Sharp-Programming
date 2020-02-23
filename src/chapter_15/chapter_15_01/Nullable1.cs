using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_01.Nullable1
{
    [TestClass]
    public class Nullable1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.ThrowsException<NullReferenceException>(() => new SomeClass().NameLength);
            Assert.IsTrue(new SomeClass("Raf").NameLength >= 0);
        }


        public class SomeClass
        {
            private string _name;

            public SomeClass() { }
            public SomeClass(string name) { _name = name; }

            public int NameLength
            {
                get { return _name.Length; }
            }
        }

    }
}
