using System;

namespace chapter_09_01
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
         var engine = new Engine("M270 Turbo", 1600, 75.0);
         Console.WriteLine($"Generation of engine: {GC.GetGeneration(engine)}");

         Console.WriteLine($"Estimated heap size: {GC.GetTotalMemory(false)}");
      }
   }
}
