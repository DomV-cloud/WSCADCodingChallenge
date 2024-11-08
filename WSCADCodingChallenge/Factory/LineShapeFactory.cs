using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge
{
    public class LineShapeFactory : IShapeFactory
    {
        public IShape CreateShape(ShapeData shapeData, ShapeDataParser parser)
        {
            return new LineShape
            {
                A = parser.ParsePoint(shapeData.A),
                B = parser.ParsePoint(shapeData.B),
                Color = parser.ParseColor(shapeData.Color)
            };
        }
    }
}
