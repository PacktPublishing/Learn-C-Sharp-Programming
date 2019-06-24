using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    public class Employee
    {
        private string EmployeeName;
        private int EmployeeSalary;

        public string Name
        {
            get
            {
                return EmployeeName;
            }
            set
            {
                EmployeeName = value;
            }
        }

        public int Salary
        {
            get
            {
                return EmployeeSalary;
            }
            set
            {
                EmployeeSalary = value;
            }
        }
    }
}
