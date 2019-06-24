using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    public class EmployeeOverload
    {
        public void FullName(string firstName)
        {
            Console.WriteLine("The full Name of Employee is {0}", firstName);
        }

        public void FullName(string firstName, string lastName)
        {
            Console.WriteLine("The full Name of Employee is {0}", firstName + " " + lastName);
        }

        public string FullName(string firstName, string middleName, string lastName)
        {
            return firstName + " " + middleName + " " + lastName;
        }
    }
}
