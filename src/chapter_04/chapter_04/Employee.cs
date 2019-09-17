using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_04
{
   namespace v1
   {
      class Employee
      {
         public const int StartId = 100;

         public int EmployeeId;
         public string FirstName;
         public string LastName;
      }
   }

   namespace v2
   {
      class Employee
      {
         public const int StartId = 100;

         public readonly int EmployeeId;
         public string FirstName;
         public string LastName;

         public Employee(int id)
         {
            EmployeeId = id;
         }
      }
   }

   namespace v3
   {
      class Employee
      {
         public int    EmployeeId;
         public string FirstName;
         public string LastName;

         public Employee(int employeeId, string firstName, string lastName)
         {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
         }

         public string GetEmployeeName()
         {
            return $"{FirstName} {LastName}";
         }
      }
   }

   namespace v4
   {
      class Employee
      {
         public int EmployeeId;
         public string FirstName;
         public string LastName;

         public Employee(int employeeId, string firstName, string lastName)
         {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
         }

         public string GetEmployeeName() => $"{FirstName} {LastName}";
      }
   }
}
