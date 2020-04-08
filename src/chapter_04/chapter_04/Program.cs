using chapter_04.demo;
using System;

namespace chapter_04
{
#pragma warning disable CS0219, CS0168
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

         // static 
         {
            v16.Employee obj1 = v16.Employee.Create("John", "Doe");
            v16.Employee obj2 = v16.Employee.Create("Jane", "Doe");
            Console.WriteLine($"{obj1.EmployeeId} {obj1.FirstName}");
            Console.WriteLine($"{obj2.EmployeeId} {obj2.FirstName}");
         }

         {
            var lbs = MassConverters.KgToPound(42.5);
            var kgs = MassConverters.PoundToKg(180);
         }

         {
            v17.Employee obj1 = v17.Employee.Create("John", "Doe");
            v17.Employee obj2 = v17.Employee.Create("Jane", "Doe");
            Console.WriteLine($"{obj1.EmployeeId} {obj1.FirstName}");
            Console.WriteLine($"{obj2.EmployeeId} {obj2.FirstName}");
         }

         // ref params

         {
            int num1 = 10;
            int num2 = 20;

            Console.WriteLine($"Before swapping: num1={num1}, num2={num2}");
            Swap(ref num1, ref num2);
            Console.WriteLine($"After swapping:  num1={num1}, num2={num2}");
         }

         {
            v8.Employee e1 = new v8.Employee(1, "John", "Doe");
            Project proj = new Project("Demo", e1);
            Console.WriteLine(proj);

            ref v8.Employee owner = ref proj.GetOwner();
            owner = new v8.Employee(2, "Jane", "Doe");
            Console.WriteLine(proj);
         }

         // in
         {
            int i = 0;
            string s = "hello";
            DontTouch(i, s);
         }

         // variable params
         {
            var a = Any(42 > 15, "text".Length == 3);
            var b = All(true, false, true);
            var c = All();
         }

         // optional paramters
         {
            v2.Point p1 = new v2.Point();     // x = 0, y = 0
            v2.Point p2 = new v2.Point(1);    // x = 1, y = 0
            v2.Point p3 = new v2.Point(1, 2); // x = 1, y = 2
         }

         // named arguments
         {
            v2.Point p1 = new v2.Point(x: 1, y: 2); // x = 1, y = 2
            v2.Point p2 = new v2.Point(1, y: 2);    // x = 1, y = 2
            v2.Point p3 = new v2.Point(x: 1, 2);    // x = 1, y = 2

            v2.Point p4 = new v2.Point(y: 2);       // x = 0, y = 2
            v2.Point p5 = new v2.Point(x: 1);       // x = 1, y = 0
         }

         // partial classes
         {
            v18.Employee obj = new v18.Employee()
            {
               EmployeeId = 1,
               FirstName = "John",
               LastName = "Doe"
            };
         }

         // structures         
         {
            v1.Point p = new v1.Point()
            {
               x = 2,
               y = 3
            };
         }

         {
            v1.Point p;
            p.x = 2;
            p.y = 3;
         }

         {
            v1.Point? p = null;
         }

         {
            v2.Point p1 = new v2.Point(2, 3);
            v2.Point p2 = new v2.Point(0, 3);

            if (p1.Equals(p2)) { /* do something */ }
         }

         {
            v4.Point p1 = new v4.Point(2, 3);
            v4.Point p2 = new v4.Point(0, 3);

            if (p1 == p2) { /* do something */ }
         }

         // enumerations
         {
            v1.Priority p = v1.Priority.Normal;
            int i = (int)v1.Priority.Normal;

            Console.WriteLine(v1.Priority.Normal);
            Console.WriteLine((int)v1.Priority.Urgent);
         }

         {
            v1.Priority p1 = (v1.Priority)42;
            v3.Priority p2 = 0;
            v3.Priority p3 = (v3.Priority)10;
         }

         {
            Enum.TryParse("Normal", out v3.Priority p1);
            Enum.TryParse(typeof(v3.Priority), "normal", true, out object o);
            v3.Priority p2 = (v3.Priority)o;
         }

         {            
            var f = new foo2();
         }

         {
            global::System.Console.WriteLine("Hello, world!");
         }
      } 

      static void Swap(ref int a, ref int b)
      {
         int temp = a;
         a = b;
         b = temp;
      }

      static void DontTouch(in int value, in string text)
      {
         // value = 42;   // error
         // ++value;      // error
         // text = null;  // error
      }

      static void Square(int input, out int output)
      {
         output = input * input;
      }

      static bool Any(params bool [] values)
      {
         foreach (bool v in values)
            if (v) return true;
         return false;
      }

      static bool All(params bool[] values)
      {
         if (values.Length == 0) return false;

         foreach (bool v in values)
            if (!v) return false;
         return true;
      }
   }
#pragma warning restore CS0219, CS0168
}
