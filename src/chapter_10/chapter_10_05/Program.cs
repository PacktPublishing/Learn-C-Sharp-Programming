using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter_10_05
{
   interface IMonoid<T>
   {
      T Combine(T a, T b);
      T Identity { get; }
   }

   struct ConcatList<T> : IMonoid<List<T>>
   {
      public List<T> Identity => new List<T> { };

      public List<T> Combine(List<T> a, List<T> b)
      {
         var l = new List<T>(a);
         l.AddRange(b);
         return l;
      }
   }

   struct ConcatString : IMonoid<string>
   {
      public string Identity => string.Empty;

      public string Combine(string a, string b)
      {
         return a + b;
      }
   }

   static class Monoid
   {
      public static T Concat<MT, T>(IEnumerable<T> seq)
         where MT : struct, IMonoid<T>
      {
         var result = default(MT).Identity;
         foreach (var e in seq)
            result = default(MT).Combine(result, e);
         return result;
      }
   }

   class Program
   {
      static string AsString(int a, double b, string c)
      {
         return $"a={a}, b={b}, c={c}";
      }

      static Func<T2, T3, TResult> Apply<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f, T1 arg)
      {
         return (b, c) => f(arg, b, c);
      }

      static Func<T2, TResult> Apply<T1, T2, TResult>(Func<T1, T2, TResult> f, T1 arg)
      {
         return b => f(arg, b);
      }

      static Func<TResult> Apply<T1, TResult>(Func<T1, TResult> f, T1 arg)
      {
         return () => f(arg);
      }

      static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> f)
      {
         return a => b => c => f(a, b, c);
      }

      static void Execute(Func<int, int> f)
      {
         Console.WriteLine(f(42));
      }

      static Func<int, int> Increment()
      {
         int step = 1;
         return x => x + step;
      }

      class Engine
      {
         public string Name { get; }
         public int Capacity { get; }
         public double Power { get; }

         public Engine(string name, int capacity, double power)
         {
            Name = name;
            Capacity = capacity;
            Power = power;
         }
      }

      sealed class EngineFinder
      {
         public EngineFinder(double minPower, int minCapacity)
         {
            this.minPower = minPower;
            this.minCapacity = minCapacity;
         }

         public double minPower;
         public int minCapacity;

         public bool IsMatch(Engine engine)
         {
            return engine.Power >= minPower && engine.Capacity >= minCapacity;
         }
      }

      static string Hash(int a)
      {
         return $"{a}";
      }

      static Func<int, string> Hash()
      {
         Dictionary<int, string> cache = new Dictionary<int, string>();

         return a =>
         {
            if (cache.TryGetValue(a, out string h)) return h;
            return $"{a}";
         };
      }

      static Func<int> GetNextId()
      {
         int id = 1;
         return () => id++;
      }

      class Monad<T>
      {
         public Monad(T value) => Value = value;

         public T Value { get; }

         public Monad<U> Bind<U>(Func<T, Monad<U>> f) => f(Value);
      }

      class Business
      {
         public IEnumerable<Customer> GetCustomers() { return null; }
      }

      class Customer
      {
         public IEnumerable<Order> GetOrders() { return null; }
      }

      class Order
      {
         public IEnumerable<Article> GetArticles() { return null; }
      }

      class Article { }      

      static void Main(string[] args)
      {
         // ---------- partial function application ----------
         {
            var result = AsString(42, 43.5, "44");
            Console.WriteLine(result);
         }

         {
            var f1 = Apply<int, double, string, string>(AsString, 42);
            Console.WriteLine(f1(43.5, "44"));

            var f2 = Apply(f1, 43.5);
            var f3 = Apply(f2, "44");
            string result = f3();
            Console.WriteLine(result);
         }

         // ---------- currying ----------
         {
            var f1 = Curry<int, double, string, string>(AsString);
            var f2 = f1(42);
            var f3 = f2(43.5);
            string result = f3("44");
            Console.WriteLine(result);
         }

         {
            var f = Curry<int, double, string, string>(AsString);
            string result = f(42)(43.5)("44");
            Console.WriteLine(result);
         }

         // ---------- closures ----------
         {
            var inc = Increment();
            Console.WriteLine(inc(42));
         }

         {
            var list = new List<Engine>();
            var minp = 75.0;
            var minc = 1600;
            var engine = list.Find(e => e.Power >= minp && e.Capacity >= minc);

            var engine2 = list.Find(new EngineFinder(minp, minc).IsMatch);
         }

         {
            Console.WriteLine(Hash(42));
            Console.WriteLine(Hash(42));

            var h = Hash();
            Console.WriteLine(h(42));
            Console.WriteLine(h(42));
         }

         {
            var nextId = GetNextId();
            Console.WriteLine(nextId()); // prints 1
            Console.WriteLine(nextId()); // prints 2
            Console.WriteLine(nextId()); // prints 3
         }

         // ---------- monoids ----------
         {
            var m = new ConcatString();
            var text = m.Combine("Learning", m.Combine(" ", "C# 8"));
            Console.WriteLine(text);
         }

         {
            var text = Monoid.Concat<ConcatString, string>(new[] { "Learning", " ", "C# 8" });
            Console.WriteLine(text);

            var list = Monoid.Concat<ConcatList<int>, List<int>>(
               new[] {
                  new List<int>{ 1,2,3},
                  new List<int> { 4, 5 },
                  new List<int> { } });

            Console.WriteLine(string.Join(",", list));
         }

         // ---------- monads ----------
         {
            var numbers = new int[][]{
               new[]{ 1, 2, 3},
               new[]{ 4, 5 },
               new[]{ 6, 7}
            };

            IEnumerable<int> odds = numbers
               .SelectMany(n => n.Where(x => x % 2 == 1));

            Console.WriteLine(string.Join(",", odds));
         }

         {
            var m = new Monad<int>(21);

            var r = m.Bind(x => new Monad<int>(x * 2))
                     .Bind(x => new Monad<string>($"x={x}"));

            Console.WriteLine(r.Value); // prints x=42
         }

         {
            var m = new Monad<int>(42);
            var mm = new Monad<Monad<int>>(m);
            var r = mm.Bind(x => x);

            Console.WriteLine(r.Value);
         }

         {
            IEnumerable<Article> GetArticlesSoldBy(Business business)
            {
               var articles = new HashSet<Article>();

               foreach (var customer in business.GetCustomers())
               {
                  foreach (var order in customer.GetOrders())
                  {
                     foreach (var article in order.GetArticles())
                     {
                        articles.Add(article);
                     }
                  }
               }

               return articles;
            }

            IEnumerable<Article> GetArticlesSoldBy2(Business business)
            {
               return business.GetCustomers()
                              .SelectMany(c => c.GetOrders())
                              .SelectMany(o => o.GetArticles())
                              .Distinct()
                              .ToList();
            }
         }
      }
   }
}
