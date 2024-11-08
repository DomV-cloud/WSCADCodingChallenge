using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WSCADCodingChallenge.Factory;
using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge.Services
{
    public class FileService : IFileService
    {
        private readonly ShapeFactory shapeFactory;

        public FileService(ShapeFactory shapeFactory)
        {
            this.shapeFactory = shapeFactory;
        }

        public List<IShape> LoadShapesFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var shapesData = JsonSerializer.Deserialize<List<ShapeData>>(json);
            var shapes = new List<IShape>();

            foreach (var shapeData in shapesData)
            {
                shapes.Add(shapeFactory.CreateShape(shapeData));
            }

            return shapes;
        }

        public List<IShape> LoadShapesFromXml(string filePath)
        {
            var serializer = new XmlSerializer(typeof(ShapesCollection));
            using (var reader = new StreamReader(filePath))
            {
                var shapesData = (ShapesCollection)serializer.Deserialize(reader);
                var shapes = new List<IShape>();

                foreach (var shapeData in shapesData.ShapeList)
                {
                    shapes.Add(shapeFactory.CreateShape(shapeData));
                }

                return shapes;
            }
        }
    }
}
