# WPF Paint Effects Application

A Windows Presentation Foundation (WPF) application that provides realistic painting effects including Foliage, Fire, and Smoke brushes. Create beautiful digital art with natural-looking paint effects.

## Features

- 🌿 **Foliage Brush**: Creates leaf-like shapes in various shades of green
- 🔥 **Fire Brush**: Generates flame-shaped particles in reds, oranges, and yellows
- 💨 **Smoke Brush**: Produces wispy, semi-transparent gray particles
- 🎨 **Adjustable Brush Size**: Control effect intensity with size slider (5-50 pixels)
- 🧹 **Clear Canvas**: Reset your artwork with one click
- ✨ **Real-time Drawing**: Click and drag to paint with realistic particle effects

## Screenshots

The application features a clean, modern interface with:
- Dark toolbar with brush selection buttons
- White drawing canvas
- Visual feedback for selected brush
- Adjustable brush size controls

## System Requirements

- **Operating System**: Windows 10 or later
- **.NET Framework**: .NET 6.0 or later
- **Development Tools**: 
  - Visual Studio 2022 (recommended) OR
  - Visual Studio Code with C# Dev Kit extension
  - .NET SDK 6.0 or later

## Installation and Setup

### Option 1: Using Visual Studio 2022

1. **Install Visual Studio Community 2022** (free)
   - Download from: https://visualstudio.microsoft.com/downloads/
   - Select ".NET desktop development" workload during installation

2. **Create New Project**
   - Open Visual Studio
   - Click "Create a new project"
   - Search for "WPF Application" (C#)
   - Name: `PaintEffectsApp`
   - Select .NET 6.0, 7.0, or 8.0

3. **Replace Default Files**
   - Replace the content of the generated files with the provided code
   - Build and run with F5

### Option 2: Using Visual Studio Code

1. **Install Prerequisites**
   ```bash
   # Install .NET SDK
   # Download from: https://dotnet.microsoft.com/download
   
   # Install VS Code extensions:
   # - C# Dev Kit
   # - C#
   # - XAML
   ```

2. **Create Project**
   ```bash
   # Open terminal/command prompt
   cd C:\Projects
   dotnet new wpf -n PaintEffectsApp
   cd PaintEffectsApp
   code .
   ```

3. **Build and Run**
   ```bash
   dotnet build
   dotnet run
   ```

## Project Structure

```
PaintEffectsApp/
├── App.xaml                 # Application definition
├── App.xaml.cs             # Application code-behind
├── MainWindow.xaml         # Main window UI definition
├── MainWindow.xaml.cs      # Main window logic and paint effects
├── PaintEffectsApp.csproj  # Project configuration
├── bin/                    # Build output
└── obj/                    # Build intermediates
```

## File Descriptions

### MainWindow.xaml
Contains the user interface definition including:
- Toolbar with brush selection buttons
- Brush size slider
- Drawing canvas
- Layout and styling

### MainWindow.xaml.cs
Contains the application logic:
- Paint effect algorithms
- Mouse event handling
- Brush type management
- Visual effect generation

### App.xaml & App.xaml.cs
Standard WPF application bootstrap files.

## How to Use

1. **Launch the Application**
   - Run the executable or press F5 in Visual Studio/VS Code

2. **Select Brush Type**
   - Click 🌿 **Foliage** for leaf-like green effects
   - Click 🔥 **Fire** for upward-moving flame particles
   - Click 💨 **Smoke** for wispy, drifting gray effects

3. **Adjust Brush Size**
   - Use the slider to control effect intensity (5-50 pixels)

4. **Start Painting**
   - Click and drag on the white canvas
   - Each brush creates multiple particles with natural variations

5. **Clear Canvas**
   - Click **Clear** button to start over

## Technical Details

### Paint Effect Algorithms

**Foliage Effect**:
- Creates 8 elliptical shapes per mouse position
- Varies size and opacity for natural look
- Uses 5 different shades of green
- Applies radial gradients for depth

**Fire Effect**:
- Generates 6 flame-shaped particles
- Taller than wide with upward movement
- Uses red, orange, and yellow colors
- Positions flames to rise upward from cursor

**Smoke Effect**:
- Produces 5 wispy circular shapes
- Very transparent with gray coloring
- Drifts upward and outward naturally
- Varies in size and opacity

### Performance Considerations

- Effects create multiple visual elements during drawing
- Canvas children are managed automatically
- Clear function removes all elements and frees memory
- Optimized for smooth real-time interaction

## Customization

### Adding New Brush Types

1. Add new enum value to `BrushType`:
   ```csharp
   public enum BrushType
   {
       Foliage,
       Fire,
       Smoke,
       YourNewBrush  // Add here
   }
   ```

2. Create new effect method:
   ```csharp
   private void CreateYourNewBrushEffect(Point position, double brushSize)
   {
       // Your effect logic here
   }
   ```

3. Add button to XAML and wire up events

### Modifying Effect Parameters

- Change particle count in effect methods (loop iterations)
- Adjust color arrays for different palettes
- Modify size calculations for different brush behaviors
- Alter transparency values (Alpha channel)

## Troubleshooting

### Build Errors

**"InitializeComponent does not exist"**:
```bash
dotnet clean
dotnet build
```

**XAML Parse Errors**:
- Check all XML tags are properly closed
- Verify namespace declarations
- Ensure event handler names match

**Missing Controls**:
- Verify XAML element names match C# references
- Check x:Name attributes in XAML
- Rebuild solution

### Runtime Issues

**Application Won't Start**:
- Check App.xaml has correct StartupUri
- Verify target framework compatibility
- Check for missing dependencies

**Effects Not Working**:
- Verify mouse event handlers are connected
- Check canvas is properly initialized
- Ensure brush size slider has valid range

## Development Environment

### Recommended Extensions (VS Code)

- **C# Dev Kit**: Essential C# development tools
- **XAML**: Syntax highlighting and IntelliSense
- **GitLens**: Git integration (optional)
- **.NET Install Tool**: Manage .NET versions

### Build Commands

```bash
# Clean build artifacts
dotnet clean

# Restore NuGet packages
dotnet restore

# Build project
dotnet build

# Run application
dotnet run

# Publish for distribution
dotnet publish -c Release -r win-x64 --self-contained true
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is provided as-is for educational and demonstration purposes.

## Version History

- **v1.0**: Initial release with three paint effects
  - Foliage, Fire, and Smoke brushes
  - Adjustable brush size
  - Clear canvas functionality
  - Modern UI design

## Future Enhancements

- [ ] Save/Load artwork functionality
- [ ] Additional brush types (Water, Lightning, etc.)
- [ ] Undo/Redo functionality
- [ ] Color picker for custom effects
- [ ] Brush opacity controls
- [ ] Export to image formats
- [ ] Animation playback of drawing process

## Support

For issues or questions:
1. Check the troubleshooting section above
2. Verify your development environment setup
3. Review the project structure and file contents
4. Create an issue with detailed error messages

---

**Created with ❤️ using WPF and .NET**
