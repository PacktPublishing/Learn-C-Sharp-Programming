using System;
using System.Runtime.InteropServices;

namespace chapter_09_02
{
   class ResourceWrapper
   {
      // constructor
      ResourceWrapper()
      {
         // construct the object
      }

      // finalizer
      ~ResourceWrapper()
      {
         // release unmanaged resources
      }
   }

   public class HandleWrapper
   {
      [DllImport("kernel32.dll", SetLastError = true)]
      static extern bool CloseHandle(IntPtr hHandle);

      public IntPtr Handle { get; private set; }

      public HandleWrapper(IntPtr ptr)
      {
         Handle = ptr;
      }

      ~HandleWrapper()
      {
         if (Handle != default)
            CloseHandle(Handle);
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Hello World!");
      }
   }
}
