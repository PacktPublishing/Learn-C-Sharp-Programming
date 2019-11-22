using System;

namespace chapter_17_lib
{
   public struct Rectangle
   {
      public readonly int Left;
      public readonly int Top;
      public readonly int Right;
      public readonly int Bottom;

      public int Width => Right - Left;
      public int Height => Bottom - Top;

      public int Area => Width * Height;

      public Rectangle(int left, int top, int right, int bottom)
      {
         Left = left;
         Top = top;
         Right = right;
         Bottom = bottom;
      }

      public static Rectangle Empty => new Rectangle(0, 0, 0, 0);      
   }

   public static class RectangleExtensions
   {
      public static Rectangle Inflate(this Rectangle r, int left, int top, int right, int bottom) =>
         new Rectangle(r.Left + left, r.Top + top, r.Right + right, r.Bottom + bottom);

      public static Rectangle Deflate(this Rectangle r, int left, int top, int right, int bottom) =>
         new Rectangle(r.Left - left, r.Top - top, r.Right - right, r.Bottom - bottom);

      public static Rectangle Intersect(this Rectangle a, Rectangle b)
      {
         int l = Math.Max(a.Left, b.Left);
         int r = Math.Min(a.Right, b.Right);
         int t = Math.Max(a.Top, b.Top);
         int bt = Math.Min(a.Bottom, b.Bottom);

         if (r >= l && bt >= t)
            return new Rectangle(l, t, r, bt);

         return Rectangle.Empty;
      }

      public static bool IntersectsWith(this Rectangle a, Rectangle b) =>
         ((b.Left < a.Right) && (a.Left < b.Right)) &&
         ((b.Top < a.Bottom) && (a.Top < b.Bottom));
   }
}
