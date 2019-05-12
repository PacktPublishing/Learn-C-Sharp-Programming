using EngineLibBase;
using System;
using System.Reflection;

namespace chapter_11_03
{
   class Program
   {
      static void Example1()
      {
         var assembly = Assembly.LoadFrom("EngineLib.dll");

         if (assembly != null)
         {
            var type = assembly.GetType("EngineLib.Engine");
            object engine = assembly.CreateInstance(
               "EngineLib.Engine",
               true,
               BindingFlags.CreateInstance,
               null,
               new object[] { "M270 Turbo", 1600, 75.0 },
               null,
               null);

            /*
            object engine = Activator.CreateInstance(
               type,
               new object[] { "M270 Turbo", 1600, 75.0 });
            */

            var pi = type.GetProperty("Status");
            if (pi != null)
               Console.WriteLine(pi.GetValue(engine));

            var mi = type.GetMethod("Start");
            if (mi != null)
               mi.Invoke(engine, null);

            if (pi != null)
               Console.WriteLine(pi.GetValue(engine));
         }
      }

      static void Example2()
      {
         var assembly = Assembly.LoadFrom("EngineLib.dll");

         if (assembly != null)
         {
            var type = assembly.GetType("EngineLib.Engine");
            var engine = (IEngine)Activator.CreateInstance(
               type,
               new object[] { "M270 Turbo", 1600, 75.0 });

            Console.WriteLine(engine.Status);
            engine.Start();
            Console.WriteLine(engine.Status);
         }
      }

      static void Main(string[] args)
      {
         Example1();
         Example2();
      }
   }
}
