using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace WSCADCodingChallenge.Shapes
{
    public class ShapeData
    {
        [JsonPropertyName("type")]
        [XmlElement("Type")]
        public string Type { get; set; }

        [JsonPropertyName("a")]
        [XmlElement("A")]
        public string A { get; set; }

        [JsonPropertyName("b")]
        [XmlElement("B")]
        public string B { get; set; }

        [JsonPropertyName("c")]
        [XmlElement("C")]
        public string C { get; set; }

        [JsonPropertyName("center")]
        [XmlElement("Center")]
        public string Center { get; set; }

        [JsonPropertyName("radius")]
        [XmlElement("Radius")]
        public double Radius { get; set; }

        [JsonPropertyName("filled")]
        [XmlElement("Filled")]
        public bool Filled { get; set; }

        [JsonPropertyName("color")]
        [XmlElement("Color")]
        public string Color { get; set; }
    }
}
