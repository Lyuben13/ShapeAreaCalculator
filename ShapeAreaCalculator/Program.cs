using System;
using System.Collections.Generic;
using ShapeAreaCalculator.Models;
using ShapeAreaCalculator.Services;

namespace ShapeAreaCalculator
{
    class Program
    {
        static List<Shape> shapes = new List<Shape>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Shape Area Calculator ---");
                Console.WriteLine("1. Add Circle");
                Console.WriteLine("2. Add Rectangle");
                Console.WriteLine("3. Add Triangle");
                Console.WriteLine("4. Show All Shapes");
                Console.WriteLine("5. Remove Shape");
                Console.WriteLine("6. Exit");
                Console.WriteLine("7. Save Shapes");
                Console.WriteLine("8. Load Shapes");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1": AddCircle(); break;
                        case "2": AddRectangle(); break;
                        case "3": AddTriangle(); break;
                        case "4": ShowShapes(); break;
                        case "5": RemoveShape(); break;
                        case "6": return;
                        case "7":
                            ShapeSerializer.SaveShapes(shapes);
                            Console.WriteLine("Shapes saved to shapes.json");
                            break;
                        case "8":
                            shapes = ShapeSerializer.LoadShapes();
                            Console.WriteLine("Shapes loaded from shapes.json");
                            break;

                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void AddCircle()
        {
            Console.Write("Enter radius: ");
            double r = double.Parse(Console.ReadLine());
            shapes.Add(new Circle(r));
        }

        static void AddRectangle()
        {
            Console.Write("Enter width: ");
            double w = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            double h = double.Parse(Console.ReadLine());
            shapes.Add(new Rectangle(w, h));
        }

        static void AddTriangle()
        {
            Console.Write("Enter base: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            double h = double.Parse(Console.ReadLine());
            shapes.Add(new Triangle(b, h));
        }

        static void ShowShapes()
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("No shapes to display.");
                return;
            }

            int i = 1;
            foreach (var shape in shapes)
            {
                Console.WriteLine($"{i++}. {shape.GetType().Name} - Area: {shape.GetArea():F2}, Perimeter: {shape.GetPerimeter():F2}");
            }
        }

        static void RemoveShape()
        {
            ShowShapes();
            Console.Write("Enter the number of the shape to remove: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < shapes.Count)
            {
                shapes.RemoveAt(index);
                Console.WriteLine("Shape removed.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }
    }
}
