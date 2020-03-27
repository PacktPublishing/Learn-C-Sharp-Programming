using System;

namespace chapter_08_03
{
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

   static class EngineExtension
   {
      public static void Deconstruct(this Engine engine, out string name, out int capacity, out double power)
      {
         name = engine.Name;
         capacity = engine.Capacity;
         power = engine.Power;
      }
   }

   class Program
   {
      static (string, int, double) GetEngine()
      {
         return ("M270 Turbo", 1600, 75.0);
      }

      static (string Name, int Capacity, double Power) GetEngine2()
      {
         return ("M270 Turbo", 1600, 75.0);
      }

      static void Main(string[] args)
      {
         {
            var engine = new Tuple<string, int, double>("M270 Turbo", 1600, 75);

            Console.WriteLine($"{engine.Item1} {engine.Item2 / 1000.0}l {engine.Item3}kW");
         }

         {
            var engine = Tuple.Create("M270 Turbo", 1600, 75);
         }

         {
            var engine = Tuple.Create(
                  "M270 DE16 LA R", 1595, 83, 73.7, 180, "gasoline", 2015,
                  Tuple.Create(75, 90, 115)
               );

            Console.WriteLine($"{engine.Item1} powers: {engine.Rest}");
         }

         {
            var engine = new Tuple<string, int, int, double, int, string, int, Tuple<int, int, int>>(
               "M270 DE16 LA R", 1595, 83, 73.7, 180, "gasoline", 2015,
               new Tuple<int, int, int>(75, 90, 115));

            Console.WriteLine($"{engine.Item1} powers: {engine.Rest}");
         }

         {
            var engine = ("M270 Turbo", 1600, 75.0);
         }

         {
            ValueTuple<string, int, double> engine = ("M270 Turbo", 1600, 75.0);

            Console.WriteLine($"{engine.Item1} {engine.Item2 / 1000.0}l {engine.Item3}kW");
         }

         {
            (string, int, double) engine = ("M270 Turbo", 1600, 75.0);
         }

         {
            var engine = (Name: "M270 Turbo", Capacity: 1600, Power: 75.0);

            Console.WriteLine($"{engine.Name} {engine.Capacity / 1000.0}l {engine.Power}kW");
         }

         {
            (string Name, int Capacity, double Power) engine = ("M270 Turbo", 1600, 75.0);
            Console.WriteLine($"{engine.Name} {engine.Capacity / 1000.0}l {engine.Power}kW");
         }

         {
            (string Name, int Capacity, double Power) engine = (name: "M270 Turbo", cap: 1600, pow: 75.0);
            Console.WriteLine($"{engine.Name} {engine.Capacity / 1000.0}l {engine.Power}kW");
         }

         {
            var name = "M270 Turbo";
            var capacity = 1600;
            var engine = (name, capacity, 75);

            Console.WriteLine($"{engine.name} {engine.capacity / 1000.0}l {engine.Item3}kW");
         }

         {
            var engine = GetEngine();
            Console.WriteLine($"{engine.Item1} {engine.Item2 / 1000.0}l {engine.Item3}kW");
         }

         {
            var engine = GetEngine2();
            Console.WriteLine($"{engine.Name} {engine.Capacity / 1000.0}l {engine.Power}kW");
         }

         {
            var e1 = ("M270 Turbo", 1600, 75.0);
            var e2 = (Name: "M270 Turbo", Capacity: 1600, Power: 75.0);
            Console.WriteLine(e1 == e2);
         }

         {
            (int, long) t1 = (1, 2);
            (long, int) t2 = (1, 2);
            Console.WriteLine(t1 == t2);
         }

         {
            (string name, int capacity, double power) = GetEngine();
         }

         {
            (var name, var capacity, var power) = GetEngine();
         }

         {
            var (name, capacity, power) = GetEngine();
         }

         {
            (var name, var capacity, double power) = GetEngine();
         }

         {
            (var name, _, _) = GetEngine();
         }

         {
            var engine = ("M270 Turbo", 1600, 75.0);
            (string name, int capacity, double power) = engine;
         }

         {
            var engine = new Engine("M270 Turbo", 1600, 75.0);

            var (Name, Capacity, Power) = engine;
         }

         {
            // error
            // var engine = new Engine("M270 Turbo", 1600, 75.0);
            // Console.WriteLine(engine == ("M270 Turbo", 1600, 75.0));
         }
      }
   }
}
