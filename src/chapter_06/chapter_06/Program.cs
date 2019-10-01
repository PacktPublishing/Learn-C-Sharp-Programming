using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter_06
{
   class Program
   {
      static void Main(string[] args)
      {
         {
            var p1 = new Pair<int, int>(1, 2);
            var p2 = new Pair<int, double>(1, 42.99);
            var p3 = new Pair<string, bool>("true", true);
         }

         {
            var obj1 = new GenericDemo<int>(10);
            var obj2 = new GenericDemo<string>("Hello World");

            var t1 = obj1.GetType();
            Console.WriteLine(t1.Name);
            Console.WriteLine(t1.GetGenericArguments().FirstOrDefault().Name);
            var t2 = obj2.GetType();
            Console.WriteLine(t2.Name);
            Console.WriteLine(t2.GetGenericArguments().FirstOrDefault().Name);

            Console.WriteLine(obj1);
            Console.WriteLine(obj2);
         }

         Rectangle<int> rectangle1 = new Rectangle<int>(10, 20);
         rectangle1.GetDimension();

         Rectangle<double> rectangle2 = new Rectangle<double>(5.5, 7.5);
         rectangle2.GetDimension();

         {
            v1.Square objSquare = new v1.Square(10);
            Console.WriteLine($"The area of square is {objSquare.Area}");

            v1.Circle objCircle = new v1.Circle(7.5);
            Console.WriteLine($"The area of circle is {objCircle.Area}");
         }

         {
            v2.Square objSquare = new v2.Square(10);
            Console.WriteLine($"The area of square is {objSquare.Area}");

            v2.Circle objCircle = new v2.Circle(7.5);
            Console.WriteLine($"The area of circle is {objCircle.Area}");
         }

         {
            v3.Square objSquare = new v3.Square(10);
            Console.WriteLine($"The area of square is {objSquare.Area}");

            v3.Circle objCircle = new v3.Circle(7.5);
            Console.WriteLine($"The area of circle is {objCircle.Area}");
         }

         {
            IEnumerable<string> names = new List<string> { "Marius", "Ankit", "Raffaele" };
            IEnumerable<object> objects = names;
         }

         {
            List<string> names = new List<string> { "Marius", "Ankit", "Raffaele" };
            //List<object> objects = names; // error
         }

         {
            IEnumerable<int> numbers = new List<int> { 1, 1, 2, 3, 5, 8 };
            //IEnumerable<object> objects = numbers; // error
         }

         {
            v4.Square sqr1 = new v4.Square(4);
            v4.Square sqr2 = new v4.Square(5);

            v4.SquareComparison.IsBigger(sqr1, sqr2, new v4.SquareComparer());
            v4.SquareComparison.IsBigger(sqr1, sqr2, new v4.ShapeComparer());
            //v4.SquareComparison.IsBigger(sqr1, sqr2, new v4.CircleComparer());
         }

         Employee employee = new Employee(10000, 500);
         Console.WriteLine("The total salary of employee is " + employee.Add());

         Student student = new Student("John", "Doe");
         Console.WriteLine("The full name of student is " + student.Add());

         TestVehicle<Car> objCar = new TestVehicle<Car>(new Car());
         objCar.GetVehicleType();

         // TestVehicle<HangGlider> objHang = new TestVehicle<HangGlider>(new HangGlider()); // Compile-time error

         CompareObject compareObject = new CompareObject();
         Console.WriteLine(compareObject.Compare<int>(10, 10));
         Console.WriteLine(compareObject.Compare<double>(10.5, 10.8));
         Console.WriteLine(compareObject.Compare<string>("a", "a"));
         Console.WriteLine(compareObject.Compare<string>("a", "b"));

         Console.ReadLine();
      }
   }
}
