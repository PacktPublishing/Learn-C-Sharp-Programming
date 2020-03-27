using System;
using System.Collections.Generic;
using chapter_08_06.Extensions;

namespace chapter_08_06
{
   namespace Simple
   {
      static class StringExtensions
      {
         public static string Reverse(string s)
         {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
         }
      }
   }

   namespace Extensions
   {
      static class StringExtensions
      {
         public static string Reverse(this string s)
         {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
         }
      }

      static class ExceptionExtensions
      {
         public static string AllMessages(
            this Exception exception,
            bool reverse = false)
         {
            var messages = new List<string>();
            var ex = exception;
            while (ex != null)
            {
               messages.Add(ex.Message);
               ex = ex.InnerException;
            }

            if (reverse) messages.Reverse();

            return string.Join(Environment.NewLine, messages);
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         {
            var text = "demo";
            var result = Simple.StringExtensions.Reverse(text);
         }

         {
            var text = "demo";
            var result = text.Reverse();
         }

         {
            var exception =
               new InvalidOperationException(
                  "An invalid operation occurred",
                  new NotSupportedException(
                     "The operation is not supported",
                     new InvalidCastException(
                        "Cannot apply cast!")));

            Console.WriteLine(exception.AllMessages());
            Console.WriteLine(exception.AllMessages(true));
         }
      }
   }
}
