using System;

namespace chapter_02
{
#pragma warning disable CS0219, CS0168
   public readonly struct fancyint
   {
      private readonly int value;
      public fancyint(int value)
      {
         this.value = value;
      }
      public static implicit operator int(fancyint v) => v.value;
      public static explicit operator fancyint(int v) => new fancyint(v);

      public override string ToString() => $"{value}";
   }

   class foo
   {
      public int run() { return 42; }
   }

   class bar
   {
      public foo f { get; set; }
   }

   class foobar
   {
      readonly string text;

      public foobar(string value)
      {
         text = value ?? throw new ArgumentNullException(nameof(value));
      }
   }

   class Program
   {
      static int max(int a, int b)
      {
         return a >= b ? a : b;
      }

      static string GetDisplayName(string name, string email)
      {
         return name ?? email ?? "unknown";
      }

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
            int a = 42;
            object o = a;   // boxing

            o = 43;
            int b = (int)o; // unboxing

            Console.WriteLine(a);  // 42
            Console.WriteLine(b);  // 43
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

         {
            int[] arr1;
            int[] arr2 = null;
            int[] arr3 = new int[6];
            int[] arr4 = new int[] { 1, 1, 2, 3, 5, 8 };
            int[] arr5 = new int[6] { 1, 1, 2, 3, 5, 8 };
            int[] arr6 = { 1, 1, 2, 3, 5, 8 };

            for (int i = 0; i < arr6.Length; ++i)
               Console.WriteLine(arr6[i]);

            foreach (int element in arr6)
               Console.WriteLine(element);

            for (int i = 0; i < arr6.Length; ++i)
               arr6[i] *= 2;  // OK

            //foreach (int element in arr6)
            //   element *= 2;  // error
         }

         {
            int[,] arr1;
            arr1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr2 = null;
            int[,] arr3 = new int[2,3];
            int[,] arr4 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr5 = new int[2,3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] arr6 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < arr6.GetLength(0); ++i)
            {
               for (int j = 0; j < arr6.GetLength(1); ++j)
               {
                  Console.Write($"{arr6[i, j]} ");
               }
               Console.WriteLine();
            }

            int[,,] arr7 = new int[4, 3, 2]
            {
               { { 11, 12}, { 13, 14}, {15, 16 } },
               { { 21, 22}, { 23, 24}, {25, 26 } },
               { { 31, 32}, { 33, 34}, {35, 36 } },
               { { 41, 42}, { 43, 44}, {45, 46 } }
            };
         }

         {
            int[][] arr1;
            int[][] arr2 = null;
            int[][] arr3 = new int[2][];
            arr3[0] = new int[3];
            arr3[1] = new int[] { 1, 1, 2, 3, 5, 8 };
            int[][] arr4 = new int[][]
            {
               new int[] { 1, 2, 3 },
               new int[] { 1, 1, 2, 3, 5, 8 }
            };
            int[][] arr5 =
            {
               new int[] { 1, 2, 3 },
               new int[] { 1, 1, 2, 3, 5, 8 }
            };
            int[][,] arr6 = new int[][,]
            {
               new int[,] { { 1, 2}, { 3, 4 } },
               new int[,] { {11, 12, 13}, { 14, 15, 16} }
            };

            for(int i = 0; i < arr5.Length; ++i)
            {
               for(int j = 0; j < arr5[i].Length; ++j)
               {
                  Console.Write($"{arr5[i][j]} ");
               }
               Console.WriteLine();
            }
         }

         {
            int i = 10;
            float f = i;

            long l = 7195467872;
            double d = l;

            string s = "example";
            object o = s;          // implicit conversion
            string r = (string)o;  // explicit conversion
         }

         {
            double d = 12.34;
            int i = (int)d;
         }

         {
            fancyint a = new fancyint(42);
            int i = a;                 // implicit conversion
            fancyint b = (fancyint)i;  // explicit conversion
         }

         {
            DateTime dt1 = DateTime.Parse("2019.08.31");
            DateTime.TryParse("2019.08.31", out DateTime dt2);

            int i1 = int.Parse("42");
            try
            {
               int i2 = int.Parse("42.15");
            }
            catch { }
            int.TryParse("42.15", out int i3);
         }

         {
            int a = 10;
            int b = a++;
         }

         {
            int a = 10;
            int b = ++a;
         }

         {
            bool a = true, b = false;
            bool c = a && b;
            bool d = a || !b;
         }

         {
            int a = 10;      // 1010
            int b = 5;       // 0101
            int c = a & b;   // 0000
            int d = a | b;   // 1111
         }

         {
            int x = 0b_0000_0110;
            x = x << 4;  // 0b_0110_0000
            Console.WriteLine(Convert.ToString(x, 2));

            uint y = 0b_1111_0000_0000_0000_1111_1110_1100_1000;
            y = y << 2;  // 0b_1100_0000_0000_0011_1111_1011_0010_0000;
            Console.WriteLine(Convert.ToString(y, 2));
         }

         {
            int x = 0b_0000_0000;
            x = x >> 4;  // 0b_0110_0000
            Console.WriteLine(Convert.ToString(x, 2));

            uint y = 0b_1111_0000_0000_0000_1111_1110_1100_1000;
            y = y >> 2;  // 0b_0011_1100_0000_0000_0011_1111_1011_0010;
            Console.WriteLine(Convert.ToString(y, 2));
         }

         {
            int a = 42;
            a = a + 11;
            // or
            a += 11;
         }

         {
            bar[] bars = new bar[] { null };
            int? i = bars[0]?.f?.run();
         }
      }
   }
#pragma warning restore CS0219, CS0168
}
