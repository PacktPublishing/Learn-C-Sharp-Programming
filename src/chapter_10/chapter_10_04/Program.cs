using System;
using System.Linq;

namespace chapter_10_04
{
   class Program
   {
      static void Main(string[] args)
      {
         {
            int[] arr = { 1, 1, 3, 5, 8, 13, 21, 34 };
            {
               int sum = 0;
               for (int i = 0; i < arr.Length; ++i)
               {
                  if (arr[i] % 2 == 1)
                     sum += arr[i];
               }
            }

            {
               int sum = arr.Where(x => x % 2 == 1).Sum();
            }

            {
               int sum = (from x in arr
                          where x % 2 == 1
                          select x).Sum();

            }
         }

         {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

            {
               var count = text
                  .Split(new char[] { ' ', ',', '.' })
                  .Where(w => !string.IsNullOrEmpty(w))
                  .Count();

               var groups = text
                  .Split(new char[] { ' ', ',', '.' })
                  .GroupBy(w => w.Length, w => w.ToLower())
                  .Select(g => new { Length = g.Key, Words = g })
                  .Where(g => g.Length > 0)
                  .OrderBy(g => g.Length);

               foreach (var group in groups)
               {
                  Console.WriteLine($"Length={group.Length}");
                  foreach (var word in group.Words)
                  {
                     Console.WriteLine($"  {word}");
                  }
               }
            }

            {
               var count = (from w in text.Split(new char[] { ' ', ',', '.' })
                            where !string.IsNullOrEmpty(w)
                            select w).Count();

               var groups = from w in text.Split(new char[] { ' ', ',', '.' })
                            group w.ToLower() by w.Length into g
                            where g.Key > 0
                            orderby g.Key
                            select new { Length = g.Key, Words = g };

               foreach (var group in groups)
               {
                  Console.Write($"Length={group.Length}: ");
                  Console.WriteLine(string.Join(',', group.Words));
               }
            }
         }
      }
   }
}
