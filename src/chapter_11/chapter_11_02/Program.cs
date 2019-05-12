using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace chapter_11_02
{
   class Program
   {
      static void DisplayType(Assembly assembly)
      {
         if (assembly != null)
         {
            var type = assembly.GetType("EngineLib.Engine");
            if (type != null)
            {
               var properties = type.GetProperties();
               foreach (var p in properties)
               {
                  Console.WriteLine($"{p.Name} ({p.PropertyType.Name})");
               }
            }
         }
      }

      static void Main(string[] args)
      {
         //var assembly = Assembly.Load("EngineLib");

         //var assembly = Assembly.Load(@"EngineLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

         //var assemblyName = new AssemblyName()
         //{
         //   Name = "EngineLib",
         //   Version = new Version(1,0,0,0),
         //   CultureInfo = null,
         //   CodeBase = Directory.GetCurrentDirectory()
         //};

         //var assembly = Assembly.Load(assemblyName);

         //var assembly = Assembly.Load(@"WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

         var assembly = Assembly.LoadFrom("EngineLib.dll");

         Console.WriteLine(
$@"Name:  {assembly.GetName().FullName}
Files: {string.Join(
         ',', 
         assembly.GetFiles().Select(
            s=>Path.GetFileName(s.Name)))}
Refs:  {string.Join(
         ',', 
         assembly.GetReferencedAssemblies().Select(
            n=>n.Name))}");

         DisplayType(assembly);            
      }
   }
}
