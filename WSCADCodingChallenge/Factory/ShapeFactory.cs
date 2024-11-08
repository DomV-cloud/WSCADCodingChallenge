using System;
using System.Collections.Generic;
using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge.Factory
{
    public class ShapeFactory
    {
        private readonly Dictionary<string, IShapeFactory> shapeFactories;
        private readonly ShapeDataParser parser;

        public ShapeFactory(Dictionary<string, IShapeFactory> shapeFactories, ShapeDataParser parser)
        {
            this.shapeFactories = shapeFactories;
            this.parser = parser;
        }

        public IShape CreateShape(ShapeData shapeData)
        {
            if (shapeFactories.TryGetValue(shapeData.Type, out var factory))
            {
                return factory.CreateShape(shapeData, parser);
            }

            throw new NotSupportedException($"Shape type '{shapeData.Type}' is not supported.");
        }
    }
}
