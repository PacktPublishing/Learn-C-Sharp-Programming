using System;

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
}
