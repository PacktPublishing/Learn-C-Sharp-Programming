using System;

namespace chapter_08_01.version1
{
   public enum Status { Started, Stopped }

   public delegate void StatusChange(Status status);

   public class Engine
   {
      private StatusChange statusChangeHandler;

      public void RegisterStatusChangeHandler(StatusChange handler)
      {
         statusChangeHandler = handler;
      }

      public void Start()
      {
         if (statusChangeHandler != null)
            statusChangeHandler(Status.Started);
      }

      public void Stop()
      {
         if (statusChangeHandler != null)
            statusChangeHandler(Status.Stopped);
      }
   }

   class Example
   {
      public static void Execute()
      {
         Engine engine = new Engine();
         engine.RegisterStatusChangeHandler(OnEngineStatusChanged);

         engine.Start();

         engine.Stop();
      }

      private static void OnEngineStatusChanged(Status status)
      {
         Console.WriteLine($"Engine is now {status}");
      }
   }
}
