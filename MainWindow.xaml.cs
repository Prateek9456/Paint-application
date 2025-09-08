using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintEffectsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private BrushType currentBrushType = BrushType.Foliage;
        private Random random = new Random();
        
        public enum BrushType
        {
            Foliage,
            Fire,
            Smoke
        }

        public MainWindow()
        {
            InitializeComponent();
            UpdateButtonStates();
        }

        private void FoliageButton_Click(object sender, RoutedEventArgs e)
        {
            currentBrushType = BrushType.Foliage;
            UpdateButtonStates();
        }

        private void FireButton_Click(object sender, RoutedEventArgs e)
        {
            currentBrushType = BrushType.Fire;
            UpdateButtonStates();
        }

        private void SmokeButton_Click(object sender, RoutedEventArgs e)
        {
            currentBrushType = BrushType.Smoke;
            UpdateButtonStates();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }

        private void UpdateButtonStates()
        {
            // Reset all button backgrounds
            FoliageButton.Background = new SolidColorBrush(Color.FromRgb(39, 174, 96));
            FireButton.Background = new SolidColorBrush(Color.FromRgb(231, 76, 60));
            SmokeButton.Background = new SolidColorBrush(Color.FromRgb(127, 140, 141));

            // Highlight selected button
            switch (currentBrushType)
            {
                case BrushType.Foliage:
                    FoliageButton.Background = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                    break;
                case BrushType.Fire:
                    FireButton.Background = new SolidColorBrush(Color.FromRgb(255, 87, 51));
                    break;
                case BrushType.Smoke:
                    SmokeButton.Background = new SolidColorBrush(Color.FromRgb(149, 165, 166));
                    break;
            }
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            Point position = e.GetPosition(DrawingCanvas);
            CreatePaintEffect(position);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(DrawingCanvas);
                CreatePaintEffect(position);
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }

        private void CreatePaintEffect(Point position)
        {
            double brushSize = BrushSizeSlider.Value;
            
            switch (currentBrushType)
            {
                case BrushType.Foliage:
                    CreateFoliageEffect(position, brushSize);
                    break;
                case BrushType.Fire:
                    CreateFireEffect(position, brushSize);
                    break;
                case BrushType.Smoke:
                    CreateSmokeEffect(position, brushSize);
                    break;
            }
        }

        private void CreateFoliageEffect(Point position, double brushSize)
        {
            // Create multiple small circles and ellipses to simulate foliage
            for (int i = 0; i < 8; i++)
            {
                Ellipse leaf = new Ellipse();
                
                // Random size variation
                double size = brushSize * (0.3 + random.NextDouble() * 0.7);
                leaf.Width = size;
                leaf.Height = size * (0.6 + random.NextDouble() * 0.8);
                
                // Various shades of green
                Color[] greenColors = {
                    Color.FromRgb(34, 153, 84),
                    Color.FromRgb(39, 174, 96),
                    Color.FromRgb(46, 204, 113),
                    Color.FromRgb(22, 160, 133),
                    Color.FromRgb(26, 188, 156)
                };
                
                Color leafColor = greenColors[random.Next(greenColors.Length)];
                leafColor.A = (byte)(100 + random.Next(100));
                
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientStops.Add(new GradientStop(leafColor, 0.0));
                brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1.0));
                
                leaf.Fill = brush;
                
                // Random position around the mouse cursor
                double offsetX = (random.NextDouble() - 0.5) * brushSize;
                double offsetY = (random.NextDouble() - 0.5) * brushSize;
                
                Canvas.SetLeft(leaf, position.X + offsetX - leaf.Width / 2);
                Canvas.SetTop(leaf, position.Y + offsetY - leaf.Height / 2);
                
                DrawingCanvas.Children.Add(leaf);
            }
        }

        private void CreateFireEffect(Point position, double brushSize)
        {
            // Create flame-like shapes
            for (int i = 0; i < 6; i++)
            {
                Ellipse flame = new Ellipse();
                
                // Flame shapes are taller than they are wide
                double width = brushSize * (0.4 + random.NextDouble() * 0.4);
                double height = width * (1.5 + random.NextDouble() * 1.0);
                
                flame.Width = width;
                flame.Height = height;
                
                // Fire colors - reds, oranges, yellows
                Color[] fireColors = {
                    Color.FromRgb(231, 76, 60),
                    Color.FromRgb(230, 126, 34),
                    Color.FromRgb(241, 196, 15),
                    Color.FromRgb(192, 57, 43),
                    Color.FromRgb(211, 84, 0)
                };
                
                Color flameColor = fireColors[random.Next(fireColors.Length)];
                flameColor.A = (byte)(120 + random.Next(100));
                
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.Center = new Point(0.5, 0.8);
                brush.GradientStops.Add(new GradientStop(flameColor, 0.0));
                brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1.0));
                
                flame.Fill = brush;
                
                // Flames tend to go upward
                double offsetX = (random.NextDouble() - 0.5) * brushSize * 0.5;
                double offsetY = -random.NextDouble() * brushSize * 0.8;
                
                Canvas.SetLeft(flame, position.X + offsetX - flame.Width / 2);
                Canvas.SetTop(flame, position.Y + offsetY - flame.Height);
                
                DrawingCanvas.Children.Add(flame);
            }
        }

        private void CreateSmokeEffect(Point position, double brushSize)
        {
            // Create wispy smoke-like shapes
            for (int i = 0; i < 5; i++)
            {
                Ellipse smoke = new Ellipse();
                
                // Smoke particles vary in size
                double size = brushSize * (0.5 + random.NextDouble() * 1.0);
                smoke.Width = size;
                smoke.Height = size * (0.7 + random.NextDouble() * 0.6);
                
                // Gray smoke colors
                Color[] smokeColors = {
                    Color.FromRgb(127, 140, 141),
                    Color.FromRgb(149, 165, 166),
                    Color.FromRgb(95, 106, 106),
                    Color.FromRgb(178, 190, 195),
                    Color.FromRgb(69, 90, 100)
                };
                
                Color smokeColor = smokeColors[random.Next(smokeColors.Length)];
                smokeColor.A = (byte)(40 + random.Next(80));
                
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientStops.Add(new GradientStop(smokeColor, 0.0));
                brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1.0));
                
                smoke.Fill = brush;
                
                // Smoke drifts upward and outward
                double offsetX = (random.NextDouble() - 0.5) * brushSize * 1.2;
                double offsetY = -random.NextDouble() * brushSize * 1.5;
                
                Canvas.SetLeft(smoke, position.X + offsetX - smoke.Width / 2);
                Canvas.SetTop(smoke, position.Y + offsetY - smoke.Height / 2);
                
                DrawingCanvas.Children.Add(smoke);
            }
        }
    }
}