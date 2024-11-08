using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge.Interfaces
{
    public interface IShapeFactory
    {
        IShape CreateShape(ShapeData shapeData, ShapeDataParser parser);
    }
}
