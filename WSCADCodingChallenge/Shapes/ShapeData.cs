using System.Text.Json.Serialization;
using System.Windows.Media;
using System.Windows;
using System;
using WSCADCodingChallenge.Interfaces;

namespace WSCADCodingChallenge.Shapes
{
    public class ShapeData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("a")]
        public string A { get; set; }

        [JsonPropertyName("b")]
        public string B { get; set; }

        [JsonPropertyName("c")]
        public string C { get; set; }

        [JsonPropertyName("center")]
        public string Center { get; set; }

        [JsonPropertyName("radius")]
        public double Radius { get; set; }

        [JsonPropertyName("filled")]
        public bool Filled { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        public IShape ToShape()
        {
            Color color = ParseColor(Color);

            switch (Type.ToLower())
            {
                case "line":
                    return new LineShape
                    {
                        A = ParsePoint(A),
                        B = ParsePoint(B),
                        Color = color
                    };

                case "circle":
                    return new CircleShape
                    {
                        Center = ParsePoint(Center),
                        Radius = Radius,
                        Color = color,
                        Filled = Filled
                    };

                case "triangle":
                    return new TriangleShape
                    {
                        A = ParsePoint(A),
                        B = ParsePoint(B),
                        C = ParsePoint(C),
                        Color = color,
                        Filled = Filled
                    };

                default:
                    throw new NotSupportedException($"Shape type '{Type}' is not supported.");
            }
        }

        private Color ParseColor(string colorString)
        {
            var parts = colorString.Split(';');
            return System.Windows.Media.Color.FromArgb(
                byte.Parse(parts[0]),   // Alpha
                byte.Parse(parts[1]),   // Red
                byte.Parse(parts[2]),   // Green
                byte.Parse(parts[3])    // Blue
            );
        }

        private Point ParsePoint(string pointString)
        {
            var coordinates = pointString.Split(';');
            return new Point(
                double.Parse(coordinates[0]),
                double.Parse(coordinates[1])
            );
        }

    }
}
