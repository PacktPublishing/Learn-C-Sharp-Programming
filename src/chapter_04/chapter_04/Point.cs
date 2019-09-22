using System;

namespace chapter_04
{
   namespace v1
   {
      struct Point
      {
         public int x;
         public int y;
      }
   }

   namespace v2
   {
      struct Point
      {
         public int X { get; }
         public int Y { get; }

         public Point(int x = 0, int y = 0)
         {
            X = x;
            Y = y;
         }
      }
   }

   namespace v3
   {
      struct Point : IEquatable<Point>
      {
         public int X { get; }
         public int Y { get; }

         public Point(int x = 0, int y = 0)
         {
            X = x;
            Y = y;
         }

         public bool Equals(Point other)
         {
            return X == other.X && Y == other.Y;
         }

         public override bool Equals(object obj)
         {
            if (obj is Point other)
            {
               return this.Equals(other);
            }
            return false;
         }

         public override int GetHashCode()
         {
            return X.GetHashCode() * 17 + Y.GetHashCode();
         }
      }
   }


   namespace v4
   {
      struct Point
      {
         public int X { get; }
         public int Y { get; }

         public Point(int x = 0, int y = 0)
         {
            X = x;
            Y = y;
         }

         public override bool Equals(object obj)
         {
            if (obj is Point other)
            {
               return this.Equals(other);
            }
            return false;
         }

         public override int GetHashCode()
         {
            return X.GetHashCode() * 17 + Y.GetHashCode();
         }

         public static bool operator !=(Point p1, Point p2)
         {
            return p1.X != p2.X || p1.Y != p2.Y;
         }

         public static bool operator ==(Point p1, Point p2)
         {
            return p1.X == p2.X && p1.Y == p2.Y;
         }
      }
   }
}
