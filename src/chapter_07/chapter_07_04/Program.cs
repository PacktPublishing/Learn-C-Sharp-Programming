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
            var text = "2019-12-25";
            var match = Regex.Match(text, @"^(\d{4})-(1[0-2]|0[1-9]|[0-9]?)-(3[01]|[12][0-9]|0[1-9]|[0-9]?)$");
            Console.WriteLine(match.Value);
         }

         {
            var text = "2019-12-25";
            var regex = new Regex(@"^(\d{4})-(1[0-2]|0[1-9]|[0-9]?)-(3[01]|[12][0-9]|0[1-9]|[0-9]?)$");
            var match = regex.Match(text);
            Console.WriteLine(match.Value);
         }

         {
            var text = "2019-05-01,2019-5-9,2019-12-25,2019-13-21";
            var matches = Regex.Matches(text, @"(\d{4})-(1[0-2]|0[1-9]|[0-9]?)-(3[01]|[12][0-9]|0[1-9]|[0-9]?)");
            foreach(Match match in matches)
               Console.WriteLine(match);
            for (int i = 0; i < matches.Count; ++i)
               if(matches[i].Success)
                  Console.WriteLine(
                     $"[{matches[i].Index}..{matches[i].Length}]={matches[i].Value}");
         }

         {
            var text = "2019-05-01,2019-5-9,2019-12-25,2019-13-21";
            var matches = Regex.Matches(text, @"(\d{4})-(1[0-2]|0[1-9]|[0-9]?)-(3[01]|[12][0-9]|0[1-9]|[0-9]?)");
            foreach (Match match in matches)
               Console.WriteLine(match.Groups[1].Value);
            for (int i = 0; i < matches.Count; ++i)
               if (matches[i].Success)
                  Console.WriteLine(
                     $"[{matches[i].Index}..{matches[i].Length}]={matches[i].Groups[1].Value}");
         }

         {
            var text = "2019-05-01\n2019-5-9\n2019-12-25\n2019-13-21";
            var matches = Regex.Matches(text, @"^(\d{4})-(1[0-2]|0[1-9]|[0-9]?)-(3[01]|[12][0-9]|0[1-9]|[0-9]?)$", RegexOptions.Multiline);
            foreach(Match match in matches)
            {
               Console.WriteLine($"{ match.Groups[1]} {match.Groups[4]}");
            }
         }

         {
            var text = "2019-05-01\n2019-5-9\n2019-12-25\n2019-13-21";
            var matches = Regex.Matches(
               text,
               @"^(\d{4})-(1[0-2]|0[1-9]|[0-9]?)-(3[01]|[12][0-9]|0[1-9]|[0-9]?)$", 
               RegexOptions.Multiline, 
               TimeSpan.FromMilliseconds(1));

            foreach (Match match in matches)
            {
               Console.WriteLine($"{match.Groups[1]}-{match.Groups[2]}-{match.Groups[3]}");
            }
         }

         {
            var text = "2019-12-25";
            var match = Regex.Match(text, @"^(?<year>\d{4})-(?<month>1[0-2]|0[1-9]|[0-9]?)-(?<day>3[01]|[12][0-9]|0[1-9]|[0-9]?)$");
            Console.WriteLine($"{match.Groups["year"]}-{match.Groups["month"]}-{match.Groups["day"]}");
         }
      }
   }
}
