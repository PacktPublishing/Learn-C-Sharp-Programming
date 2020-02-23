using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_01.Nullable2
{
    [TestClass]
    public class Nullable2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var someObject1 = new SomeClass();
            Assert.IsTrue(someObject1.NameLength1 == 0);
            Assert.IsTrue(someObject1.NameLength2 == 0);

            var someObject2 = new SomeClass("Raf");
            Assert.IsTrue(someObject2.NameLength1 == 3);
            Assert.IsTrue(someObject2.NameLength2 == 3);
        }


#nullable enable
        public class SomeClass
        {
            private string? _name;

            public SomeClass() { }
            public SomeClass(string name) { _name = name; }

            public int NameLength1
            {
                get { return _name?.Length ?? 0; }
            }

            public int NameLength2
            {
                get
                {
                    if (_name == null) return 0; else return _name.Length;
                }
            }
            public int NameLength3
            {
                get { return _name!.Length; }
            }

        }
#nullable restore
    }
}