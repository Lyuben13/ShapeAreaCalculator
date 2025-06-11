using System;

namespace ShapeAreaCalculator.Models
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle() { }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be positive.");
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;

        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }
}
