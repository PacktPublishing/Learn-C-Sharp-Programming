using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    public class ComplexNumber
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public ComplexNumber()
        {
            Real = Imaginary = 0;
        }

        public ComplexNumber(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber operator +(ComplexNumber number1, ComplexNumber number2)
        {
            ComplexNumber result = new ComplexNumber();

            result.Real = number1.Real + number2.Real;
            result.Imaginary = number2.Imaginary + number2.Imaginary;

            return result;
        }

        public static ComplexNumber operator ++(ComplexNumber number)
        {
            ComplexNumber result = new ComplexNumber();

            result.Real = number.Real + 1;
            result.Imaginary = number.Imaginary;
            return result;
        }
    }
}
