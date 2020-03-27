using System;

namespace chapter_08_02
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

   class Program
   {
      static void Main(string[] args)
      {
         {
            var o = new { Name = "M270 Turbo", Capacity = 1600, Power = 75.0 };
            Console.WriteLine($"{o.Name} {o.Capacity / 1000.0}l {o.Power}kW");
         }

         {
            var e = new Engine("M270 Turbo", 1600, 75.0);
            var o = new { e.Name, e.Power };
            Console.WriteLine($"{o.Name} {o.Power}kW");
         }
      }
   }
}
