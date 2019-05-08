using System;
using System.Runtime.InteropServices;

namespace chapter_09_03
{
   public class Engine : IDisposable
   {
      private bool disposed = false;

      protected virtual void Dispose(bool disposing)
      {
         if (!disposed)
         {
            if (disposing)
            {
               // dispose managed objects
            }

            disposed = true;
         }
      }

      public void Dispose()
      {
         Dispose(true);
      }
   }

   public class Car : IDisposable
   {
      private Engine engine;

      public Car(Engine e)
      {
         engine = e;
      }

      #region IDisposable Support

      private bool disposed = false;

      protected virtual void Dispose(bool disposing)
      {
         if (!disposed)
         {
            if (disposing)
            {
               engine?.Dispose();
            }

            disposed = true;
         }
      }

      public void Dispose()
      {
         Dispose(true);
      }

      #endregion
   }

   public class ElectricCar : Car
   {
      public ElectricCar(Engine e):base(e)
      {
      }

      protected override void Dispose(bool disposing)
      {
         base.Dispose(disposing);
      }
   }

   public class HandleWrapper : IDisposable
   {
      [DllImport("kernel32.dll", SetLastError = true)]
      static extern bool CloseHandle(IntPtr hHandle);

      public IntPtr Handle { get; private set; }

      public HandleWrapper(IntPtr ptr)
      {
         Handle = ptr;
      }

      #region IDisposable Support
      private bool disposed = false; // To detect redundant calls

      protected virtual void Dispose(bool disposing)
      {
         if (!disposed)
         {
            if (disposing)
            {
               // nothing to dispose
            }

            if (Handle != default)
               CloseHandle(Handle);

            disposed = true;
         }
      }

      ~HandleWrapper()
      {
         Dispose(false);
      }

      // This code added to correctly implement the disposable pattern.
      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
      #endregion
   }

   public class MyResource : IDisposable
   {
      private bool disposed = false;

      protected virtual void Dispose(bool disposing)
      {
         if (!disposed)
         {
            if (disposing)
            {
               // dispose managed objects
            }

            // free unmanaged resources
            // set large fields to null.

            disposed = true;
         }
      }

      ~MyResource()
      {
         Dispose(false);
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         {
            Car car = null;

            try
            {
               car = new Car(new Engine());
               // use the car here
            }
            finally
            {
               car?.Dispose();
            }
         }

         {
            using (Car car = new Car(new Engine()))
            {
               // use the car here
            }
         }

         {
            using (Car car1 = new Car(new Engine()),
                       car2 = new Car(new Engine()))
            {
               // use car1 and car2 here
            }
         }

         {
            using (Car car1 = new Car(new Engine()))
            using (Car car2 = new Car(new Engine()))
            {
               // use car1 and car2 here
            }
         }
      }
   }
}
