using System;

namespace ShapeAreaCalculator.Models
{
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle() { }

        public Triangle(double b, double h)
        {
            if (b <= 0 || h <= 0)
                throw new ArgumentException("Dimensions must be positive.");
            Base = b;
            Height = h;
        }

        public override double GetArea() => 0.5 * Base * Height;

        public override double GetPerimeter()
        {
            double side = Math.Sqrt(Math.Pow(Base / 2, 2) + Math.Pow(Height, 2));
            return Base + 2 * side;
        }
    }
}
