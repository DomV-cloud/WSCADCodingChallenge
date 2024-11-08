using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge
{
    public partial class MainWindow : Window
    {
        private List<IShape> shapes;
        string path = "";

        public MainWindow()
        {
            InitializeComponent();

            string appDirectory = AppDomain.CurrentDomain.BaseDirectory; // WSCADCodingChallenge\WSCADCodingChallenge\bin\Debug
            path = Path.Combine(appDirectory, "Data", "dataCanvas.json");

            shapes = LoadShapesFromJson(path);

            // I know it is junk leave it like that, but I'd like to talk about little bit
            //DrawShapes();
        }

        private List<IShape> LoadShapesFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var shapesData = JsonSerializer.Deserialize<List<ShapeData>>(json);
            var shapes = new List<IShape>();

            foreach (var shapeData in shapesData)
            {
                IShape shape = shapeData.ToShape();
                if (shape != null)
                    shapes.Add(shape);
            }
            return shapes;
        }

        private void DrawShapes()
        {
            //Same case...
            //MyCanvas.Children.Clear(); // Clear previous shapes

            // Calculate bounding box and scale
            // https://stackoverflow.com/questions/5104525/wpf-how-to-get-the-true-size-bounding-box-of-shapes
            Rect boundingBox = CalculateBoundingBox(shapes);
            double scale = Math.Min(MyCanvas.ActualWidth / boundingBox.Width, MyCanvas.ActualHeight / boundingBox.Height);

            // Calculate offsets to center shapes
            double offsetX = (MyCanvas.ActualWidth - boundingBox.Width * scale) / 2 - boundingBox.Left * scale;
            double offsetY = (MyCanvas.ActualHeight - boundingBox.Height * scale) / 2 - boundingBox.Top * scale;

            // Draw each shape with scale and offsets
            foreach (var shape in shapes)
            {
                shape.Draw(MyCanvas, scale, offsetX, offsetY);
            }
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            DrawShapes();  //The canvas is fully loaded, call DrawShapes
        }

        // Resources I have used
        // https://stackoverflow.com/questions/1106339/resize-image-to-fit-in-bounding-box
        private Rect CalculateBoundingBox(List<IShape> shapes)
        {
            double minX = double.MaxValue, minY = double.MaxValue, maxX = double.MinValue, maxY = double.MinValue;
            foreach (var shape in shapes)
            {
                var bounds = shape.GetBounds();
                minX = Math.Min(minX, bounds.Left);
                minY = Math.Min(minY, bounds.Top);
                maxX = Math.Max(maxX, bounds.Right);
                maxY = Math.Max(maxY, bounds.Bottom);
            }
            return new Rect(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
