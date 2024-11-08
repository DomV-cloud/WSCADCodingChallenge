using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WSCADCodingChallenge.Interfaces;

namespace WSCADCodingChallenge.Shapes
{
    public class CircleShape : IShape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public Color Color { get; set; }
        public bool Filled { get; set; }

        public void Draw(Canvas canvas, double scale, double offsetX, double offsetY)
        {
            var ellipse = new Ellipse
            {
                Width = Radius * 2 * scale,
                Height = Radius * 2 * scale,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };

            if (Filled)
                ellipse.Fill = new SolidColorBrush(Color);

            // Set position with offset
            Canvas.SetLeft(ellipse, (Center.X - Radius) * scale + offsetX);
            Canvas.SetTop(ellipse, (Center.Y - Radius) * scale + offsetY);
            canvas.Children.Add(ellipse);
        }

        public Rect GetBounds() => new Rect(new Point(Center.X - Radius, Center.Y - Radius), new Size(Radius * 2, Radius * 2));
    }
}
