using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ShapeAreaCalculator.Models;

namespace ShapeAreaCalculator.Services
{
    public static class ShapeSerializer
    {
        private static readonly string FilePath = "shapes.json";

        public static void SaveShapes(List<Shape> shapes)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new ShapeJsonConverter() }
            };
            File.WriteAllText(FilePath, JsonSerializer.Serialize(shapes, options));
        }

        public static List<Shape> LoadShapes()
        {
            if (!File.Exists(FilePath))
                return new List<Shape>();

            var options = new JsonSerializerOptions
            {
                Converters = { new ShapeJsonConverter() }
            };

            return JsonSerializer.Deserialize<List<Shape>>(File.ReadAllText(FilePath), options)
                   ?? new List<Shape>();
        }
    }
}
