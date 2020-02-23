using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_02
{
    [TestClass]
    public class InterfaceMembers2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var p = new Person("John", "Doe");
            //p.Greet();    // Wrong, Greet() is not available in Person
        }

        [TestMethod]
        public void TestMethod2()
        {
            IWelcome p = new Person("John", "Doe");
            //p.Greet();    // Wrong, Greet() is not available in Person
            Assert.AreEqual("Welcome John", p.Greet());
        }

        public interface IWelcome
        {
            string FirstName { get; }
            string LastName { get; }
            string Greet() => $"Welcome {FirstName}";
        }


        public class Person : IWelcome
        {
            public Person(string firstName, string lastName)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
            }

            public string FirstName { get; }
            public string LastName { get; }
        }

    }
}
