using System;

namespace ShapeAreaCalculator.Models
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle() { }

        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Dimensions must be positive.");
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;

        public override double GetPerimeter() => 2 * (Width + Height);
    }
}
