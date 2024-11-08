using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using WSCADCodingChallenge.Factory;
using WSCADCodingChallenge.Interfaces;
using WSCADCodingChallenge.Services;
using WSCADCodingChallenge.Shapes;

namespace WSCADCodingChallenge
{
    public partial class MainWindow : Window
    {
        private readonly string path = "";
        private readonly string appDirectory = "";

        private readonly List<IShape> shapes;
        private readonly Dictionary<string, IShapeFactory> shapeFactories;

        private readonly FileService fileService;
        private readonly ShapeDataParser parser;
        private readonly ShapeFactory shapeFactory;

        public MainWindow()
        {
            InitializeComponent();

            shapeFactories = new Dictionary<string, IShapeFactory>(StringComparer.OrdinalIgnoreCase)
            {
                { "line", new LineShapeFactory() },
                { "circle", new CircleShapeFactory() },
                { "triangle", new TriangleShapeFactory() }
            };

            parser = new ShapeDataParser();

            shapeFactory = new ShapeFactory(shapeFactories, parser);
            fileService = new FileService(shapeFactory);

            appDirectory = AppDomain.CurrentDomain.BaseDirectory; // WSCADCodingChallenge\WSCADCodingChallenge\bin\Debug
            
            // I would definetely add configuration file, like appsettings.json
            // to configure path and if I want to load data from json or xml file
            //path = Path.Combine(appDirectory, "Data", "dataJson.json");
            path = Path.Combine(appDirectory, "Data", "dataXml.xml");

            //shapes = LoadShapesFromJson(path);
            bool useJson = false;
            shapes = useJson ? fileService.LoadShapesFromJson(path) : fileService.LoadShapesFromXml(path);

            // I know it's junk, but I'd like to talk about little bit so I am leaving it here
            //DrawShapes();
        }

        private void DrawShapes()
        {
            //Same case...
            //MyCanvas.Children.Clear(); // Clear previous shapes

            // Calculate bounding box and scale
            // Reources I've used
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
