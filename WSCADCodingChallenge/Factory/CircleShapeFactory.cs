using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge
{
    public class CircleShapeFactory : IShapeFactory
    {
        public IShape CreateShape(ShapeData shapeData, ShapeDataParser parser)
        {
            return new CircleShape
            {
                Center = parser.ParsePoint(shapeData.Center),
                Radius = shapeData.Radius,
                Color = parser.ParseColor(shapeData.Color),
                Filled = shapeData.Filled
            };
        }
    }
}
