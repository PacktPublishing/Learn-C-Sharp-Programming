using System;

namespace chapter_02
{
   class Program
   {
      static void Main(string[] args)
      {
         {
            int dec = 32;
            int hex = 0x2A;
            int bin = 0b_0010_1010;
         }

         {
            var a = 42.99;
            float b = 19.50f;
            System.Double c = -1.23;
         }

         {
            decimal a = 42.99m;
            var b = 12.45m;
            System.Decimal c = 100.75M;
         }

         {
            char a = 'A';
            char b = '\x0065';
            char c = '\u15FE';
         }

         {
            string s1;                       // unitialized
            string s2 = null;                // initialized with null
            string s3 = String.Empty;        // empty string
            string s4 = "hello world";       // initialized with text
            var s5 = "hello world";
            System.String s6 = "hello world";
            char[] letters = { 'h', 'e', 'l', 'l', 'o'};
            string s7 = new string(letters); // from an array of chars

            char c = s4[0];  // OK
            //s4[0] = 'H';     // error

            var s8 = s6.Remove(5);       // hello
            var s9 = s6.ToUpper();       // HELLO WORLD            
         }

         {
            int i = 42;
            double d = 19.99;
            var s1 = i.ToString();
            var s2 = d.ToString();
         }

         {
            int i = 42;
            string s1 = "This is item " + i.ToString();
            string s2 = string.Format("This is item {0}", i);
            string s3 = $"This is item {i}";
            string s4 = $@"This is item ""{i}""";
         }

         {
            var s1 = "c:\\Program Files (x86)\\Windows Kits\\";
            var s2 = "That was called a \"demo\"";
            var s3 = "This text\nspawns multiple lines.";
         }

         {
            var s1 = @"c:\Program Files (x86)\Windows Kits\";
            var s2 = @"That was called a ""demo""";
            var s3 = @"This text
spawns multiple lines.";
         }

         {
            bool f;
            char ch = 'x';
            int a, b = 20, c = 42;

            a = -1;
            f = true;
         }

         {
            for (int i = 1; i < 10; i++)
            {
               Console.WriteLine(i);
            }

            // i = 20; // i is out of scope
         }

         {
            int a = 5;
            for (int i = 1; i < 10; i++)
            {
               //char a = 'w';                 // compile error
               if (i % 2 == 0)
               {
                  Console.WriteLine(i + a); // a is within the scope of Main
               }
            }

            // i = 20;                           // i is out of scope
         }

         {
            int x = 42;
            object o = x;   // boxing

            o = 43;
            int y = (int)o; // unboxing

            Console.WriteLine(x);  // 42
            Console.WriteLine(y);  // 43
         }

         {
            int? a;
            int? b = null;
            int? c = 42;

            if (c.HasValue)
               Console.WriteLine(c.Value);

            int d = c ?? -1;
         }

         {
            Nullable<int> a;
            Nullable<int> b = null;
            Nullable<int> c = 42;
         }
      }
   }
}
