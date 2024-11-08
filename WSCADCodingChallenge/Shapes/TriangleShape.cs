using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCADCodingChallenge.Interfaces;

namespace WSCADCodingChallenge.Shapes
{
    public class TriangleShape : IShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Color Color { get; set; }
        public bool Filled { get; set; }

        public void Draw(Canvas canvas, double scale, double offsetX, double offsetY)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection
                {
                    ScalePoint(A, scale, offsetX, offsetY),
                    ScalePoint(B, scale, offsetX, offsetY),
                    ScalePoint(C, scale, offsetX, offsetY)
                },
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };

            if (Filled)
                polygon.Fill = new SolidColorBrush(Color);

            canvas.Children.Add(polygon);
        }

        // Helper method to scale and offset points
        private Point ScalePoint(Point point, double scale, double offsetX, double offsetY)
        {
            return new Point(point.X * scale + offsetX, point.Y * scale + offsetY);
        }

        private Point ScalePoint(Point point, double scale)
        {
            return new Point(point.X * scale, point.Y * scale);
        }

        public Rect GetBounds() => Rect.Union(new Rect(A, B), new Rect(B, C));
    }
}
