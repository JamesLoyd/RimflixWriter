
using System.Drawing;
using System.Net.Mime;
using SkiaSharp;

namespace RimflixShowMaker.ModBuilder;

public static class ResizeImageHelper
{
    public static void Build(string path, ModConfig config)
    {
        var imageDirectory = Path.Combine(config.SourceImagesFolderPath);
        var images = Directory.GetFiles(imageDirectory);
        foreach (var configScreenOption in config.ScreenOptions)
        {
            var screenOption = ScreenTypeHelper.GetScreenType(configScreenOption);
            foreach (var image in images)
            {
                BuildImageForScreen("Hockey", screenOption, image);
            }
        }
    }


    public static void ResizeImage(string inputPath, int width, int height, string outputPath)
    {
        using var input = File.OpenRead(inputPath);
        using var original = SKBitmap.Decode(input);

        using var resized = original.Resize(new SKImageInfo(width, height), SKSamplingOptions.Default);
        if (resized == null)
            throw new Exception("Failed to resize image.");

        using var image = SKImage.FromBitmap(resized);
        using var output = File.OpenWrite(outputPath);
        image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(output);
    }
    
    public static void BuildImageForScreen(string def, ScreenTypes types, string image)
    {
        if (types == ScreenTypes.Flat)
        {
            ResizeImage(image, 310, 128, $"{def}_FlatScreen.png");
        }
        else if (types == ScreenTypes.Mega)
        {
            ResizeImage(image, 1920, 1080, $"{def}_MegaScreen.png");
        }
        else if (types == ScreenTypes.Tube)
        {
            ResizeImage(image, 1280, 720, $"{def}_TubeScreen.png");
        }
    }
    
    
}

