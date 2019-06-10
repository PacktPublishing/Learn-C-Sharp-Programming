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
      }
   }
}
