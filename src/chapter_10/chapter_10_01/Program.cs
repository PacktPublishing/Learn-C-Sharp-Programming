using System;

namespace chapter_10_01
{
   namespace version1
   {
      struct Rectangle
      {
         public int Left;
         public int Right;
         public int Top;
         public int Bottom;

         public int Width { get { return Right - Left; } }
         public int Height { get { return Bottom - Top; } }

         public Rectangle(int l, int t, int r, int b)
         {
            Left = l;
            Top = t;
            Right = r;
            Bottom = b;
         }

         public void Inflate(int l, int t, int r, int b)
         {
            Left -= l;
            Right += r;
            Top -= t;
            Bottom += b;
         }
      }

      static class Helpers
      {
         public static void Inflate(ref Rectangle rect, int l, int t, int r, int b)
         {
            rect.Left -= l;
            rect.Right += r;
            rect.Top -= t;
            rect.Bottom += b;
         }
      }
   }

   namespace version2
   {
      struct Rectangle
      {
         public readonly int Left;
         public readonly int Right;
         public readonly int Top;
         public readonly int Bottom;

         public int Width { get { return Right - Left; } }
         public int Height { get { return Bottom - Top; } }

         public Rectangle(int l, int t, int r, int b)
         {
            Left = l;
            Top = t;
            Right = r;
            Bottom = b;
         }
      }

      static class Helpers
      {
         public static Rectangle Inflate(Rectangle rect, int l, int t, int r, int b)
         {
            return new Rectangle(rect.Left - l,
                                 rect.Right + r,
                                 rect.Top - t,
                                 rect.Bottom + b);
         }
      }
   }

   class Program
   {
      static void Main(string[] args)
      {
         {
            var r = new version1.Rectangle(10, 10, 30, 20);
            r.Left -= 5;
            r.Right += 5;

            r.Inflate(5, 0, 5, 0);

            version1.Helpers.Inflate(ref r, 5, 0, 5, 0);
         }

         {
            var r = new version2.Rectangle(10, 10, 30, 20);
            r = version2.Helpers.Inflate(r, 5, 0, 5, 0);
         }
      }
   }
}
