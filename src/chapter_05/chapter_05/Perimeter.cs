using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    public abstract class Perimeter
    {
        public abstract double CalculatePerimeter();
    }

    public class Rectangle : Perimeter
    {
        private double Length { get; set; }
        private double Width { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }
    }

    public class Circle : Perimeter
    {
        private double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
