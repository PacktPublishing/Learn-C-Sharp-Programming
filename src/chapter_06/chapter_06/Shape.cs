using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace chapter_06
{
   namespace v1
   {
      public abstract class Shape<T>
      {
         public abstract T Area { get; }
      }

      public class Square : Shape<int>
      {
         public int Length { get; set; }

         public Square(int length)
         {
            Length = length;
         }

         public override int Area => Length * Length;
      }

      public class Circle : Shape<double>
      {
         public double Radius { get; set; }

         public Circle(double radius)
         {
            Radius = radius;
         }

         public override double Area => Math.PI * Radius * Radius;
      }

      /*
      public class Square<T> : Shape<T>
      {
         public T Length { get; set; }

         public Square(T length)
         {
            Length = length;
         }

         // ERROR: Operator '*' cannot be applied to operands of type 'T' and 'T'
         public override T Area => Length * Length;
      }
      */
   }

   namespace v2
   {
      public interface IShape<T>
      {
         public T Area { get; }
      }

      public class Square : IShape<int>
      {
         public int Length { get; set; }

         public Square(int length)
         {
            Length = length;
         }

         public int Area => Length * Length;
      }

      public class Circle : IShape<double>
      {
         public double Radius { get; set; }

         public Circle(double radius)
         {
            Radius = radius;
         }

         public double Area => Math.PI * Radius * Radius;
      }
   }

   namespace v3
   {
      public interface IShape<T>
      {
         public T Area { get; }
      }

      public struct Square : IShape<int>
      {
         public int Length { get; set; }

         public Square(int length)
         {
            Length = length;
         }

         public int Area => Length * Length;
      }

      public struct Circle : IShape<double>
      {
         public double Radius { get; set; }

         public Circle(double radius)
         {
            Radius = radius;
         }

         public double Area => Math.PI * Radius * Radius;
      }
   }

   namespace v4
   {
      public interface IShape
      {
         public double Area { get; }
      }

      public class Square : IShape
      {
         public double Length { get; set; }

         public Square(int length)
         {
            Length = length;
         }

         public double Area => Length * Length;
      }

      public class Circle : IShape
      {
         public double Radius { get; set; }

         public Circle(double radius)
         {
            Radius = radius;
         }

         public double Area => Math.PI * Radius * Radius;
      }

      public class ShapeComparer : IComparer<IShape>
      {
         public int Compare([AllowNull] IShape x, [AllowNull] IShape y)
         {
            if (x is null)
               return y is null ? 0 : -1;

            if (y is null)
               return 1;

            return x.Area.CompareTo(y.Area);
         }
      }

      public class SquareComparer : IComparer<Square>
      {
         public int Compare([AllowNull] Square x, [AllowNull] Square y)
         {
            if (x is null)
               return y is null ? 0 : -1;

            if (y is null)
               return 1;

            return x.Length.CompareTo(y.Length);
         }
      }

      public class CircleComparer : IComparer<Circle>
      {
         public int Compare([AllowNull] Circle x, [AllowNull] Circle y)
         {
            if (x is null)
               return y is null ? 0 : -1;

            if (y is null)
               return 1;

            return x.Radius.CompareTo(y.Radius);
         }
      }

      public class SquareComparison
      {
         public static bool IsBigger(Square a, Square b, IComparer<Square> comparer)
         {
            return comparer.Compare(a, b) >= 0;
         }
      }
   }

   namespace v5
   {
      enum ShapeType
      {
         Sharp,
         Rounded
      };

      class Shape { }
      class Ellipsis : Shape { }
      class Circle : Shape { }
      class Rectangle : Shape { }
      class Square : Shape { }
   }
}
