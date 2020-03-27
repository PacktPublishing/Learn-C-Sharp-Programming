using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace chapter_08_05
{
   class Roman
   {
      static readonly Dictionary<int, string> NumberRomanDictionary;

      static Roman()
      {
         NumberRomanDictionary = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };
      }

      public static string To(int number)
      {
         var roman = new StringBuilder();

         foreach (var item in NumberRomanDictionary)
         {
            while (number >= item.Key)
            {
               roman.Append(item.Value);
               number -= item.Key;
            }
         }

         return roman.ToString();
      }
   }

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

         var pattern = @"(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})";

         {
            var success = Regex.IsMatch("2019-12-25", pattern);
            Console.WriteLine(success);
         }

         {
            var regex = new Regex(pattern);
            var success = regex.IsMatch("2019-12-25");
            Console.WriteLine(success);
         }

         {
            var success = Regex.IsMatch(
               "2019-12-25",
               @"^(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})$",
               RegexOptions.ECMAScript,
               TimeSpan.FromMilliseconds(1));
            Console.WriteLine(success);
         }

         {
            var text = "2019-12-25";
            var match = Regex.Match(text, pattern);
            Console.WriteLine(match.Value);
            Console.WriteLine($"{match.Groups[1]}.{match.Groups[2]}.{match.Groups[3]}");
         }

         {
            var text = "2019-12-25";
            var regex = new Regex(@"^(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})$");
            var match = regex.Match(text);
            Console.WriteLine(match.Value);
         }

         {
            var text = "2019-05-01,2019-5-9,2019-12-25,2019-13-21";
            var matches = Regex.Matches(text, @"(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})");
            foreach (Match match in matches)
               Console.WriteLine(match);
            for (int i = 0; i < matches.Count; ++i)
               if (matches[i].Success)
                  Console.WriteLine(
                     $"[{matches[i].Index}..{matches[i].Length}]={matches[i].Value}");
         }

         {
            var text = "2019-05-01,2019-5-9,2019-12-25,2019-13-21";
            var matches = Regex.Matches(text, @"(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})");
            foreach (Match match in matches)
               Console.WriteLine(match.Groups[1].Value);
            for (int i = 0; i < matches.Count; ++i)
               if (matches[i].Success)
                  Console.WriteLine(
                     $"[{matches[i].Index}..{matches[i].Length}]={matches[i].Groups[1].Value}");
         }

         {
            var text = "2019-05-01\n2019-5-9\n2019-12-25\n2019-13-21\n2019-1-32";
            var matches = Regex.Matches(text, @"^(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})$", RegexOptions.Multiline);
            foreach (Match match in matches)
            {
               Console.WriteLine(
                     $"[{match.Index}..{match.Length}]={match.Value}");
            }
         }

         {
            var text = "2019-05-01\n2019-5-9\n2019-12-25\n2019-13-21";
            var matches = Regex.Matches(
               text,
               @"^(\d{4})-(1[0-2]|0[1-9]|[1-9]{1})-(3[01]|[12][0-9]|0[1-9]|[1-9]{1})$",
               RegexOptions.Multiline,
               TimeSpan.FromMilliseconds(1));

            foreach (Match match in matches)
            {
               Console.WriteLine($"{match.Groups[1]}-{match.Groups[2]}-{match.Groups[3]}");
            }
         }

         {
            var text = "2019-12-25";
            var match = Regex.Match(text, @"^(?<year>\d{4})-(?<month>1[0-2]|0[1-9]|[1-9]{1})-(?<day>3[01]|[12][0-9]|0[1-9]|[1-9]{1})$");
            Console.WriteLine($"{match.Groups["year"]}-{match.Groups["month"]}-{match.Groups["day"]}");
         }

         {
            var text = "2019-12-25";
            var result = Regex.Replace(text, pattern, m => $"{m.Groups[2]}/{m.Groups[3]}/{m.Groups[1]}");
            Console.WriteLine(result);
         }
      }
   }
}
