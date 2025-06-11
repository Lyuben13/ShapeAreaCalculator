using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShapeAreaCalculator.Models;

namespace ShapeAreaCalculator.Services
{
    public class ShapeJsonConverter : JsonConverter<Shape>
    {
        public override Shape Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            var typeProp = root.TryGetProperty("Type", out var typeElement) ? typeElement.GetString() : null;
            if (string.IsNullOrEmpty(typeProp))
                throw new JsonException("Missing or invalid 'Type' property in JSON.");

            return typeProp switch
            {
                "Circle" => JsonSerializer.Deserialize<Circle>(root.GetRawText(), options),
                "Rectangle" => JsonSerializer.Deserialize<Rectangle>(root.GetRawText(), options),
                "Triangle" => JsonSerializer.Deserialize<Triangle>(root.GetRawText(), options),
                _ => throw new NotSupportedException($"Unknown type: {typeProp}")
            };
        }

        public override void Write(Utf8JsonWriter writer, Shape value, JsonSerializerOptions options)
        {
            var type = value.GetType().Name;
            var json = JsonSerializer.Serialize(value, value.GetType(), options);
            using var doc = JsonDocument.Parse(json);

            writer.WriteStartObject();
            writer.WriteString("Type", type);
            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                prop.WriteTo(writer);
            }
            writer.WriteEndObject();
        }
    }
}
