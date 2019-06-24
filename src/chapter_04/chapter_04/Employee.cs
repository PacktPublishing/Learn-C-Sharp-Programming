using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_04
{
    sealed class Employee
    {
        public int EmployeeID;
        public string FirstName;
        public string LastName;

        public Employee(int EmployeeID, string FirstName, string LastName)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public string GetEmployeeName()
        {
            return FirstName + " " + LastName;
        }

        static Employee()
        {
            Console.WriteLine("Employee class instantiated");
        }
    }
}
