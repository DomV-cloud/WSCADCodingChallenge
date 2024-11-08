using System.Windows;
using System.Windows.Controls;

namespace WSCADCodingChallenge.Interfaces
{
    public interface IShape
    {
        void Draw(Canvas canvas, double scale, double offsetX, double offsetY);
        Rect GetBounds();
    }
}
