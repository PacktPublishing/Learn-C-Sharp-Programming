using chapter_06.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_06
{
    public class Employee : IJoin<int>
    {
        int BasicSalary { get; set; }
        int Bonus { get; set; }

        public Employee(int basicSalary, int bonus)
        {
            BasicSalary = basicSalary;
            Bonus = bonus;
        }

        public int Add()
        {
            return BasicSalary + Bonus;
        }
    }
}
