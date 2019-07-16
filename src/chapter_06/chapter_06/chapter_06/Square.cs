using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_06
{
    public class Square : Shape<int>
    {
        int Length { get; set; }

        public Square(int length)
        {
            Length = length;
        }
        public override int CalculateArea()
        {
            return Length * Length;
        }
    }
}
