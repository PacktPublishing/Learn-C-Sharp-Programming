namespace chapter_05
{
   public struct Complex
   {
      public double Real { get; private set; }
      public double Imaginary { get; private set; }

      public Complex(double real = 0, double imaginary = 0)
      {
         Real = real;
         Imaginary = imaginary;
      }

      public override string ToString() => $"{Real}i + {Imaginary}";

      public static Complex operator +(Complex number1, Complex number2)
      {
         return new Complex()
         {
            Real = number1.Real + number2.Real,
            Imaginary = number2.Imaginary + number2.Imaginary
         };
      }

      public static Complex operator -(Complex number1, Complex number2)
      {
         return new Complex()
         {
            Real = number1.Real - number2.Real,
            Imaginary = number2.Imaginary - number2.Imaginary
         };
      }

      public static bool operator ==(Complex number1, Complex number2)
      {
         return number1.Real.Equals(number2.Real) &&
                number2.Imaginary.Equals(number2.Imaginary);
      }

      public static bool operator !=(Complex number1, Complex number2)
      {
         return !number1.Real.Equals(number2.Real) ||
                !number2.Imaginary.Equals(number2.Imaginary);
      }

      public override bool Equals(object obj)
      {
         return Real.Equals(((Complex)obj).Real) &&
                Imaginary.Equals(((Complex)obj).Imaginary);
      }

      public override int GetHashCode()
      {
         return Real.GetHashCode() * 17 + Imaginary.GetHashCode();
      }

      public static Complex operator ++(Complex number)
      {
         return new Complex(number.Real + 1, number.Imaginary);
      }

      public static Complex operator --(Complex number)
      {
         return new Complex(number.Real - 1, number.Imaginary);
      }
   }

   namespace v2
   { 
      public class Complex
      {
         public double Real { get; private set; }
         public double Imaginary { get; private set; }

         public Complex(double real = 0, double imaginary = 0)
         {
            Real = real;
            Imaginary = imaginary;
         }

         public override string ToString() => $"{Real}i + {Imaginary}";

         public static Complex operator ++(Complex number)
         {
            // WRONG implementation
            number.Real++;
            return number;
         }
      }
   }

   namespace v3
   {
      public class Complex
      {
         public double Real { get; private set; }
         public double Imaginary { get; private set; }

         public Complex(double real = 0, double imaginary = 0)
         {
            Real = real;
            Imaginary = imaginary;
         }

         public override string ToString() => $"{Real}i + {Imaginary}";

         public static Complex operator ++(Complex number)
         {
            return new Complex(number.Real + 1, number.Imaginary);
         }
      }
   }
}
