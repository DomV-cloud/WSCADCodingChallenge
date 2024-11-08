using System.Windows;
using System.Windows.Media;

namespace WSCADCodingChallenge
{
    public class ShapeDataParser
    {
        public Color ParseColor(string colorString)
        {
            var parts = colorString.Split(';');
            return Color.FromArgb(
                byte.Parse(parts[0]),
                byte.Parse(parts[1]),
                byte.Parse(parts[2]),
                byte.Parse(parts[3])
            );
        }

        public Point ParsePoint(string pointString)
        {
            var coordinates = pointString.Split(';');
            return new Point(
                double.Parse(coordinates[0]),
                double.Parse(coordinates[1])
            );
        }
    }

}
