using System;
using System.Text.RegularExpressions;

namespace chapter_07_04
{
   class Program
   {
      static void Main(string[] args)
      {
         {
            var text = "123۳۲١८৮੪૯୫୬१७੩௮௫౫೮൬൪๘໒໕២៧៦᠖";
            var match = Regex.Match(text, @"\d+");
            Console.WriteLine($"[{match.Index}..{match.Length}]: {match.Value}");
         }

         {
            var text = "123۳۲١८৮੪૯୫୬१७੩௮௫౫೮൬൪๘໒໕២៧៦᠖";
            var match = Regex.Match(text, @"\d+", RegexOptions.ECMAScript);
            Console.WriteLine($"[{match.Index}..{match.Length}]: {match.Value}");
         }
      }
   }
}
