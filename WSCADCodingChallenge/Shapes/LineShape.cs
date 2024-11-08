using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using WSCADCodingChallenge.Interfaces;

namespace WSCADCodingChallenge.Shapes
{
    public class LineShape : IShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Color Color { get; set; }

        public void Draw(Canvas canvas, double scale, double offsetX, double offsetY)
        {
            var line = new Line
            {
                X1 = A.X * scale + offsetX,
                Y1 = A.Y * scale + offsetY,
                X2 = B.X * scale + offsetX,
                Y2 = B.Y * scale + offsetY,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };
            canvas.Children.Add(line);
        }

        public Rect GetBounds() => new Rect(A, B);
    }
}
