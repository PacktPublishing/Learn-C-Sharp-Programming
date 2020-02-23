using System;
using System.Diagnostics;

namespace chapter_15_11
{
    /// <summary>
    /// Static local functions
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var person = new Person("John", "Smith", 25);
            program.PrintName(person);
            program.PrintName2(person);
            Console.ReadKey();
        }

        private void PrintName(Person person)
        {
            var p = person ?? throw new ArgumentNullException(nameof(person));
            Debug.WriteLine(Obfuscated());

            string Obfuscated()
            {
                if (p.Age < 18) return $"{p.FirstName[0]}. {p.LastName[0]}.";
                return $"{p.FirstName} {p.LastName}";
            }
        }

        private void PrintName2(Person person)
        {
            var p = person ?? throw new ArgumentNullException(nameof(person));
            Console.WriteLine(Obfuscated(p));

            static string Obfuscated(Person p)
            {
                if (p.Age < 18) return $"{p.FirstName[0]}. {p.LastName[0]}.";
                return $"{p.FirstName} {p.LastName}";
            }
        }
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
