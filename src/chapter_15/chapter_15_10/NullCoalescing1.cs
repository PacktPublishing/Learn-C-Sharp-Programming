using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace chapter_15_10
{
    [TestClass]
    public class NullCoalescing1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> x = null;
            Accumulate(ref x, "one", "two");
            Accumulate(ref x, "three");
            Assert.IsTrue(x.Count == 3);
        }

        void Accumulate(ref List<string> list, params string[] words)
        {
            list ??= new List<string>();
            list.AddRange(words);
        }


        class Person
        {
            public Person(string firstName, string lastName, int age)
            {
                this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
                this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
                this.Age = age;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

    }
}
