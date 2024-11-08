using System.Collections.Generic;
using System.Xml.Serialization;

namespace WSCADCodingChallenge.Shapes
{
    [XmlRoot("Shapes")]
    public class ShapesCollection
    {
        [XmlElement("Shape")]
        public List<ShapeData> ShapeList { get; set; } = new List<ShapeData>();
    }
}
