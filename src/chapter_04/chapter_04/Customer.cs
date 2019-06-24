using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_04
{
    static class Customer
    {
        public static string FirstName { get; set; }

        public static string LastName { get; set; }

        public static void GetFullName()
        {
            Console.WriteLine("Full name of Customer is : {0}", FirstName + " " + LastName);
        }
        static Customer()
        {
            Console.WriteLine("Customer class constructor invoked");
        }
    }
}
