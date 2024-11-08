using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge.Factory
{
    public class TriangleShapeFactory : IShapeFactory
    {
        public IShape CreateShape(ShapeData shapeData, ShapeDataParser parser)
        {
            return new TriangleShape
            {
                A = parser.ParsePoint(shapeData.A),
                B = parser.ParsePoint(shapeData.B),
                C = parser.ParsePoint(shapeData.C),
                Color = parser.ParseColor(shapeData.Color),
                Filled = shapeData.Filled
            };

        }
    }
}
