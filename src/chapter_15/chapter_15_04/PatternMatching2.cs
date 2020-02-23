using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_04
{
    [TestClass]
    public class PatternMatching2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("string   'hello'", GetString("hello"));
            Assert.AreEqual("integer   0100", GetString(100));
            Assert.AreEqual("Fallback: 1", GetString((Int16)1));
            Assert.AreEqual("double    3.14", GetString(3.14));
            Assert.AreEqual("Fallback: 10.6", GetString(10.6m));
            Assert.AreEqual("Derived:  a, b", GetString(new Derived("a", "b")));
            Assert.AreEqual("Base:     x", GetString(new Base("x")));
            Assert.AreEqual("null", GetString(null));
        }

        private string GetString(object o) => o switch
        {
            string s => $"string   '{s}'",
            int i => $"integer   {i:d4}",
            double d => $"double    {d:n}",
            Derived d => $"Derived:  {d.Name}, {d.Description}",
            Base b => $"Base:     {b.Name}",
            null => "null",
            _ => $"Fallback: {o}",
        };

    }

    public class Base
    {
        public Base(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    public class Derived : Base
    {
        public Derived(string name, string description)
            : base(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }

}
