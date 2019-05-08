using System;
using System.IO;

namespace chapter_08_01.version4
{
   public enum Status { Started, Stopped }

   public class EngineEventArgs : EventArgs
   {
      public Status Status { get; private set; }

      public EngineEventArgs(Status s)
      {
         Status = s;
      }
   }

   public delegate void StatusChange(object sender, EngineEventArgs args);

   public class Engine
   {
      public event StatusChange StatusChanged;

      public void Start()
      {
         StatusChanged?.Invoke(this, new EngineEventArgs(Status.Started));
      }

      public void Stop()
      {
         StatusChanged?.Invoke(this, new EngineEventArgs(Status.Stopped));
      }
   }

   class Example
   {
      public static void Execute()
      {
         Engine engine = new Engine();
         engine.StatusChanged += OnEngineStatusChanged;
         engine.StatusChanged += (s, args) => Console.WriteLine($"Engine is now {args.Status}");

         engine.Start();
         engine.Stop();

         engine.StatusChanged -= OnEngineStatusChanged;

         engine.Start();
      }

      private static void OnEngineStatusChanged(object sender, EngineEventArgs args)
      {
         File.AppendAllText(
            @"c:\temp\engine.log",
            $"Engine is now {args.Status}\n");
      }
   }
}
