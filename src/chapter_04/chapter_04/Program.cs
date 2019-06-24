using chapter_04.ClassType;
using chapter_04.Enum;
using System;

namespace chapter_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer.FirstName = "Jhon";
            Customer.LastName = "Doe";
            Customer.GetFullName();

            Employee objEmployee = new Employee(1, "John", "Doe");

            string fullName = objEmployee.GetEmployeeName();

            Console.WriteLine("Employee ID is: {0}", objEmployee.EmployeeID);
            Console.WriteLine("The full name of employee is: {0}", fullName);

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
