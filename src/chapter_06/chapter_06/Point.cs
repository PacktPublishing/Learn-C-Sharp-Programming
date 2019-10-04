using System;

namespace chapter_06
{
   namespace v1
   {
      struct Point<T>
      {
         public T X { get; }
         public T Y { get; }

         public Point(T x, T y)
         {
            X = x;
            Y = y;
         }
      }
   }

   namespace v2
   {
      struct Point<T>
         where T : struct,
                   IComparable, IComparable<T>,
                   IConvertible,
                   IEquatable<T>,
                   IFormattable
      {
         public T X { get; }
         public T Y { get; }

         public Point(T x, T y)
         {
            X = x;
            Y = y;
         }
      }
   }
}
