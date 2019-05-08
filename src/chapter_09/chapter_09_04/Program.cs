using System;
using System.Runtime.InteropServices;
using System.Text;

namespace chapter_09_04
{
   static class WindowsAPI
   {
      public static class MessageButtons
      {
         public const int MB_OK = 0;
         public const int MB_OKCANCEL = 1;
         public const int MB_YESNOCANCEL = 3;
         public const int MB_YESNO = 4;
      }

      public static class MessageIcons
      {
         public const int MB_ICONERROR = 0x10;
         public const int MB_ICONQUESTION = 0x20;
         public const int MB_ICONWARNING = 0x30;
         public const int MB_ICONINFORMATION = 0x40;
      }

      public static class MessageResult
      {
         public const int IDOK = 1;
         public const int IDCANCEL = 2;
         public const int IDABORT = 3;
         public const int IDRETRY = 4;
         public const int IDIGNORE = 5;
         public const int IDYES = 6;
         public const int IDNO = 7;
         public const int IDTRYAGAIN = 10;
         public const int IDCONTINUE = 11;
      }

      public static class ErrorCodes
      {
         public const int ERROR_SUCCESS = 0;
         public const int ERROR_INVALID_FUNCTION = 1;
         public const int ERROR_FILE_NOT_FOUND = 2;
         public const int ERROR_PATH_NOT_FOUND = 3;
         public const int ERROR_TOO_MANY_OPEN_FILES = 4;
         public const int ERROR_ACCESS_DENIED = 5;
         public const int ERROR_INVALID_HANDLE = 6;
         public const int ERROR_BUFFER_OVERFLOW = 111;
         public const int ERROR_INSUFFICIENT_BUFFER = 122;
      }

      [DllImport("user32.dll")]
      public static extern int MessageBox(IntPtr hWnd,
                                          string lpText,
                                          string lpCaption,
                                          uint uType);

      [DllImport("kernel32.dll", SetLastError = true, 
                                 CharSet = CharSet.Unicode)]
      public static extern bool GetComputerName(StringBuilder lpBuffer, 
                                                ref uint nSize);

      [DllImport("advapi32.dll", SetLastError = true,
                                 CharSet = CharSet.Unicode)]
      public static extern bool GetUserName(StringBuilder lpBuffer,
                                            ref uint nSize);
   }


   class Program
   {
      static void Main(string[] args)
      {
         {
            uint size = 0;
            var result = WindowsAPI.GetUserName(null, ref size);
            if(!result &&
               Marshal.GetLastWin32Error() == WindowsAPI.ErrorCodes.ERROR_INSUFFICIENT_BUFFER)
            {
               Console.WriteLine($"Requires buffer size: {size}");

               StringBuilder buffer = new StringBuilder((int)size);
               result = WindowsAPI.GetUserName(buffer, ref size);
               if(result)
               {
                  Console.WriteLine($"User name: {buffer.ToString()}");
               }
            }
         }

         {
            uint size = 0;
            var result = WindowsAPI.GetComputerName(null, ref size);
            if (!result &&
               Marshal.GetLastWin32Error() == WindowsAPI.ErrorCodes.ERROR_BUFFER_OVERFLOW)
            {
               Console.WriteLine($"Requires buffer size: {size}");

               StringBuilder buffer = new StringBuilder();
               result = WindowsAPI.GetComputerName(buffer, ref size);
               if (result)
               {
                  Console.WriteLine($"Computer name: {buffer.ToString()}");
               }
            }
         }

         {
            var result = WindowsAPI.MessageBox(
                            IntPtr.Zero,
                            "Is this book helpful?",
                            "Question",
                            WindowsAPI.MessageButtons.MB_YESNO |
                            WindowsAPI.MessageIcons.MB_ICONQUESTION);

            if (result == WindowsAPI.MessageResult.IDYES)
            {
               Console.WriteLine("time to learn more");
            }
         }
      }
   }
}
