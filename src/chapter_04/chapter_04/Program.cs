using chapter_04.ClassType;
using chapter_04.Enum;
using System;

namespace chapter_04
{
   class Program
   {
      static void Main(string[] args)
      {
         // classes

         {
            v1.Employee obj = new v1.Employee();
            obj.EmployeeId = 1;
            obj.FirstName = "John";
            obj.LastName = "Doe";
         }

         {
            v2.Employee obj = new v2.Employee(1);
            obj.FirstName = "John";
            obj.LastName = "Doe";
         }

         {
            v1.Employee obj1 = new v1.Employee();
            obj1.EmployeeId = 1;

            v1.Employee obj2 = obj1; 
            obj2.FirstName = "John";    // obj1.FirstName == "John"
            obj2.LastName = "Doe";      // obj1.LastName == "Doe"
         }

         // constructors

         {
            v3.Employee obj = new v3.Employee(1, "John", "Doe");

            string fullName = obj.GetEmployeeName();

            Console.WriteLine("Employee ID is: {0}", obj.EmployeeId);
            Console.WriteLine("The full name of employee is: {0}", fullName);
         }

         {
            v1.Employee obj = new v1.Employee()
            {
               EmployeeId = 1,
               FirstName = "John",
               LastName = "Doe"
            };
         }


         // properties
         {
            v5.Employee obj = new v5.Employee();
            obj.EmployeeId = 1;
            obj.FirstName = "John";
            obj.LastName = "Doe";

            Console.WriteLine($"{obj.EmployeeId} - {obj.LastName}, {obj.FirstName}");
         }

         {
            v11.Employee obj = new v11.Employee()
            {
               FirstName = "John",
               LastName = "Doe"
            };

            Console.WriteLine($"{obj.EmployeeId} - {obj.LastName}, {obj.FirstName}");
         }

         {
            v13.Employee obj = new v13.Employee();           
         }

         // indexers
         {
            v14.Employee obj = new v14.Employee()
            {
               EmployeeId = 1,
               FirstName = "John",
               LastName = "Doe"
            };

            obj.Roles[1] = "Dev";
            obj.Roles[3] = "SA";
            
            for(int i = 1; i <= 3; ++i)
            {
               try
               {
                  Console.WriteLine($"Project {i}: role is {obj.Roles[i]}");
               }
               catch(Exception ex)
               {
                  Console.WriteLine(ex.Message);
               }
            }
         }

         {
            Customer.FirstName = "John";
            Customer.LastName = "Doe";
            Customer.GetFullName();

            Student student = new Student();
            for (int i = 0; i < 5; i++)
            {
               student[i] = i + 1;
               Console.WriteLine(student[i]);
            }

            student.FirstName = "Mark";
            Console.WriteLine(student.FirstName);

            PartialClassExample objPartial = new PartialClassExample();
            objPartial.ID = 1;
            objPartial.Name = "John";

            Movie movie1 = new Movie("Titanic", 8);
            Movie movie2;
            movie2.Title = "Avengers";
            movie2.Rating = 9;

            Console.WriteLine(movie1.Title + " has " + movie1.Rating + " rating");
            Console.WriteLine(movie2.Title + " has " + movie2.Rating + " rating");

            Console.WriteLine((int)Priority.Low);
            Console.WriteLine((int)Priority.Normal);
            Console.WriteLine((int)Priority.Important);
            Console.WriteLine((int)Priority.Urgent);

            int num1 = 10;
            int num2 = 20;

            Console.WriteLine("Before Swapping - num1 is {0}, num2 is {1}", num1, num2);
            Swap(ref num1, ref num2);
            Console.WriteLine("After Swapping - num1 is {0}, num2 is {1}", num1, num2);

            int num = 10;
            int SquareNum;
            Square(num, out SquareNum);
            Console.WriteLine(SquareNum);

            int value1 = 10;
            object boxObject;

            boxObject = value1; // Boxing
            int value2 = (int)boxObject; // Unboxing

            Console.ReadLine();
         }
      }

      static void Swap(ref int a, ref int b)
      {
         int temp;

         temp = a;
         a = b;
         b = temp;
      }

      static void Square(int input, out int output)
      {
         output = input * input;
      }
   }
}
