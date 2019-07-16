using System;


namespace chapter_06
{
    public class Circle : Shape<double>
    {
        double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
