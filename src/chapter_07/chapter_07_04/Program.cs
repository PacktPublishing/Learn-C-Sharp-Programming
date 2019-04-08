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

         {
            var text = "M270 Turbo 1.6l 75kW";
            var match = Regex.Match(text, @"\d+kW");
            Console.WriteLine(match.Value);
         }

         {
            var text = "M270 Turbo 1.6l 75kW";
            var regex = new Regex(@"\d+kW");
            var match = regex.Match(text);
            Console.WriteLine(match.Value);
         }

         {
            var text = "M270 Turbo 1.6l 75kW, 90kW, 115kW";
            var matches = Regex.Matches(text, @"\d+kW");
            foreach(Match match in matches)
               Console.WriteLine(match);
            for (int i = 0; i < matches.Count; ++i)
               if(matches[i].Success)
                  Console.WriteLine(
                     $"[{matches[i].Index}..{matches[i].Length}]={matches[i].Value}");
         }

         {
            var text = "M270 Turbo 1.6l 75kW, 90kW, 115kW";
            var matches = Regex.Matches(text, @"(\d+)kW");
            foreach (Match match in matches)
               Console.WriteLine(match.Groups[1].Value);
            for (int i = 0; i < matches.Count; ++i)
               if (matches[i].Success)
                  Console.WriteLine(
                     $"[{matches[i].Index}..{matches[i].Length}]={matches[i].Groups[1].Value}");
         }

         {
            var text = "M270 DE20LA 2.0l 160kW\nM274 DE16LA 2.0l 135kW\nM271 KE18ML 1.8l 90kW";
            var matches = Regex.Matches(text, @"^(M\d+) ([A-Z]+\d+[A-Z]{2}) (\d.\d)l (\d+)kW$", RegexOptions.Multiline);
            foreach(Match match in matches)
            {
               Console.WriteLine($"{match.Groups[1]} {match.Groups[4]}");
            }
         }

         {
            var text = "M270 DE20LA 2.0l 160kW\nM274 DE16LA 2.0l 135kW\nM271 KE18ML 1.8l 90kW";
            var matches = Regex.Matches(
               text, 
               @"^(M\d+) ([A-Z]+\d+[A-Z]{2}) (\d.\d)l (\d+)kW$", 
               RegexOptions.Multiline, 
               TimeSpan.FromMilliseconds(1));

            foreach (Match match in matches)
            {
               Console.WriteLine($"{match.Groups[1]} {match.Groups[4]}");
            }
         }
      }
   }
}
