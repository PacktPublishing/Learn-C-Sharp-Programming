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

         {
            CompareObjects comp = new CompareObjects();
            Console.WriteLine(comp.Compare<int>(10, 10));
            Console.WriteLine(comp.Compare<double>(10.5, 10.8));
            Console.WriteLine(comp.Compare<string>("a", "a"));
            Console.WriteLine(comp.Compare<string>("a", "b"));
         }

         {
            CompareObjects comp = new CompareObjects();
            Console.WriteLine(comp.Compare(10, 10));
            Console.WriteLine(comp.Compare(10.5, 10.8));
            Console.WriteLine(comp.Compare("a", "a"));
            Console.WriteLine(comp.Compare("a", "b"));
         }

         {
            CompareObjects comp = new CompareObjects();
            Console.WriteLine(comp.Compare<short>(10, 10));
         }

         {
            v1.Point<int> p1 = new v1.Point<int>(3, 4);
            v1.Point<double> p2 = new v1.Point<double>(3.12, 4.55);
            v1.Point<bool> p3 = new v1.Point<bool>(true, false);
            v1.Point<string> p4 = new v1.Point<string>("alpha", "beta");
         }

         {
            v2.Point<int> p1 = new v2.Point<int>(3, 4);
            v2.Point<double> p2 = new v2.Point<double>(3.12, 4.55);
            // v2.Point<bool> p3 = new v2.Point<bool>(true, false);
            // v2.Point<string> p4 = new v2.Point<string>("alpha", "beta");
         }

         {
            var dictionary = new RestrictedDictionary<v5.ShapeType, v5.Shape>();
            var c = dictionary.Make<v5.Circle>(v5.ShapeType.Rounded);
            var e = dictionary.Make<v5.Ellipsis>(v5.ShapeType.Rounded);
            var r = dictionary.Make<v5.Rectangle>(v5.ShapeType.Sharp);
            var s = dictionary.Make<v5.Square>(v5.ShapeType.Sharp);
         }
      }
   }
}
