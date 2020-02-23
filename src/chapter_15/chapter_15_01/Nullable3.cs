using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_01.Nullable3
{
    [TestClass]
    public class Nullable3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var someObject1 = new OtherClass();
            Assert.IsTrue(someObject1.GetItemLength(0) == string.Empty);
        }


#nullable enable
        public class OtherClass
        {
            private string?[]? _names;

            public OtherClass() { }

            public int Count => _names?.Length ?? 0;

            public string GetItemLength(int index)
            {
                if (_names == null) return string.Empty;
                var name = _names[index];
                if (name == null) return string.Empty;
                return name;
            }

        }
#nullable restore

    }
}