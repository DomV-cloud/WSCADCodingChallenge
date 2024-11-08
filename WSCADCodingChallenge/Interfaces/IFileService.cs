using System.Collections.Generic;

namespace WSCADCodingChallenge.Interfaces
{
    public interface IFileService
    {
        List<IShape> LoadShapesFromJson(string filePath);

        List<IShape> LoadShapesFromXml(string filePath);
    }
}
