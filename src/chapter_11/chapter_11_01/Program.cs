using System;
using System.Linq;
using System.Reflection;

namespace chapter_11_01
{
   public enum EngineStatus { Stopped, Started }

   public class Engine
   {
      public string Name { get; }
      public int Capacity { get; }
      public double Power { get; }
      public EngineStatus Status { get; private set; }

      public Engine(string name, int capacity, double power)
      {
         Name = name;
         Capacity = capacity;
         Power = power;
         Status = EngineStatus.Stopped;
      }

      public void Start()
      {
         Status = EngineStatus.Started;
      }

      public void Stop()
      {
         Status = EngineStatus.Stopped;
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         var type = typeof(Engine);

         Console.WriteLine(type.Name);

         var properties = type.GetProperties();
         foreach(var p in properties)
         {
            Console.WriteLine($"{p.Name} ({p.PropertyType.Name})");
         }

         var methods = type.GetMethods(
            BindingFlags.Public|
            BindingFlags.Instance|
            BindingFlags.DeclaredOnly);
         foreach(var m in methods)
         {
            var parameters = string.Join(
               ',',
               m.GetParameters()
                .Select(p => $"{p.ParameterType.Name} {p.Name}"));

            Console.WriteLine($"{m.ReturnType.Name} {m.Name} ({parameters})");
         }
      }
   }
}
