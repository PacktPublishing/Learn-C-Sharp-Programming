using System;

namespace chapter_10_02
{
   namespace delegates
   {
      public delegate int Combine(int a, int b);

      class Math
      {
         public static int Add(int a, int b) { return a + b; }
         public static int Sub(int a, int b) { return a - b; }
         public static int Mul(int a, int b) { return a * b; }
      }

      class Util
      {
         public static int Apply(int a, int b, Combine f)
         {
            return f(a, b);
         }
      }
   }

   namespace functions
   {
      class Math
      {
         public static int Add(int a, int b) { return a + b; }
         public static int Sub(int a, int b) { return a - b; }
         public static int Mul(int a, int b) { return a * b; }
      }

      class Util
      {
         public static T Apply<T>(T a, T b, Func<T, T, T> f)
         {
            return f(a, b);
         }

         public static Func<T, T, T> ApplyReverse<T>(Func<T, T, T> f)
         {
            return delegate (T a, T b) { return f(b, a); };
         }

         public static T Apply<T>(T a, T b, Func<T, T, T> f, Action<string> log)
         {
            var r = f(a, b);

            log?.Invoke($"{f.Method.Name}({a},{b}) = {r}");

            return r;
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         {
            var s = delegates.Util.Apply(2, 3, delegates.Math.Add);
            var p = delegates.Util.Apply(2, 3, delegates.Math.Mul);
         }

         {
            var s = functions.Util.Apply(2, 3, functions.Math.Add);
            var p = functions.Util.Apply(2, 3, functions.Math.Mul);
         }

         {
            var s = functions.Util.Apply(2, 3, functions.Math.Add, Console.WriteLine);
            var p = functions.Util.Apply(2, 3, functions.Math.Mul, Console.WriteLine);
         }

         {
            var s = functions.Util.ApplyReverse<int>(functions.Math.Add)(2, 3);
            var d = functions.Util.ApplyReverse<int>(functions.Math.Sub)(2, 3);
         }

         {
            var s = functions.Util.Apply(2, 3, (a, b) => a + b);
            var d = functions.Util.Apply(2, 3, (a, b) => a - b);
            var p = functions.Util.Apply(2, 3, (a, b) => a * b);
         }

         {
            Func<int, int, Func<int, int, int>, int> apply = (a, b, f) => f(a, b);

            var s = apply(2, 3, (a, b) => a + b);
            var d = apply(2, 3, (a, b) => a - b);
            var p = apply(2, 3, (a, b) => a * b);
         }
      }
   }

}
