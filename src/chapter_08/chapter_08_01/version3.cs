using System;
using System.IO;

namespace chapter_08_01.version3
{
   public enum Status { Started, Stopped }

   public delegate void StatusChange(Status status);

   public class Engine
   {
      public event StatusChange StatusChanged;

      public void Start()
      {
         StatusChanged?.Invoke(Status.Started);
      }

      public void Stop()
      {
         StatusChanged?.Invoke(Status.Stopped);
      }
   }

   class Example
   {
      public static void Execute()
      {
         Engine engine = new Engine();
         engine.StatusChanged += OnEngineStatusChanged;
         engine.StatusChanged += status => Console.WriteLine($"Engine is now {status}");

         engine.Start();
         engine.Stop();

         engine.StatusChanged -= OnEngineStatusChanged;

         engine.Start();
      }

      private static void OnEngineStatusChanged(Status status)
      {
         File.AppendAllText(
            @"c:\temp\engine.log",
            $"Engine is now {status}\n");         
      }
   }
}
