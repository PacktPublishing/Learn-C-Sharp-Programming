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

   namespace v5
   {
      class Employee
      {
         private int employeeId;
         private string firstName;
         private string lastName;

         public int EmployeeId
         {
            get { return employeeId; }
            set { employeeId = value; }
         }

         public string FirstName
         {
            get { return firstName; }
            set { firstName = value; }
         }

         public string LastName
         {
            get { return lastName; }
            set { lastName = value; }
         }
      }
   }

   namespace v6
   {
      class Employee
      {
         private int employeeId;
         private string firstName;
         private string lastName;

         public int EmployeeId
         {
            get { return employeeId; }
            set {
               if (value < 0)
                  throw new ArgumentException("ID must be greater than zero.");
               employeeId = value;
            }
         }

         public string FirstName
         {
            get { return firstName; }
            set { firstName = value; }
         }

         public string LastName
         {
            get { return lastName; }
            set { lastName = value; }
         }

         public string Name
         {
            get { return $"{FirstName} {LastName}"; }
         }
      }
   }

   namespace v7
   {
      class Employee
      {
         public int EmployeeId { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
      }
   }

   namespace v8
   {
      class Employee
      {
         public int EmployeeId { get; private set; }
         public string FirstName { get; private set; }
         public string LastName { get; private set; }

         public Employee(int id, string firstName, string lastName)
         {
            EmployeeId = id;
            FirstName = firstName;
            LastName = lastName;
         }
      }
   }

   namespace v9
   {
      class Employee
      {
         public int EmployeeId { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }

         public string Name => $"{FirstName} {LastName}";
      }
   }

   namespace v10
   {
      class Employee
      {
         private int employeeId;
         public int EmployeeId
         {
            get => employeeId;
            set => employeeId = value > 0 ? value : throw new ArgumentException("ID must be greater than zero.");
         }
         public string FirstName { get; set; }
         public string LastName { get; set; }

         public string Name => $"{FirstName} {LastName}";
      }
   }

   namespace v11
   {
      class Employee
      {
         public int EmployeeId { get; set; } = 1;
         public string FirstName { get; set; }
         public string LastName { get; set; }
      }
   }

   namespace v12
   {
      class Employee
      {
         public int EmployeeId = 1;
         public string FirstName { get; set; }
         public string LastName { get; set; }
      }
   }

   namespace v13
   {
      class Employee
      {
         public int EmployeeId => 1;
         public string FirstName { get; set; }
         public string LastName { get; set; }
      }
   }

   namespace v14
   {
      class ProjectRoles
      {
         readonly Dictionary<int, string> roles = new Dictionary<int, string>();

         public string this[int projectId]
         {
            get
            {
               if (!roles.TryGetValue(projectId, out string role))
                  throw new Exception("Project ID not found!");
               return role;
            }
            set
            {
               roles[projectId] = value;
            }
         }
      }

      class Employee
      {
         public int EmployeeId { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public ProjectRoles Roles { get; private set; }

         public Employee() => Roles = new ProjectRoles();
      }
   }
}
