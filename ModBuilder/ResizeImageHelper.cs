using System.Drawing;
using System.Net.Mime;
using SkiaSharp;

namespace RimflixShowMaker.ModBuilder;

public static class ResizeImageHelper
{
    public static void Build(string path, ModConfig config, string showPath)
    {
        var imageDirectory = Path.Combine(config.SourceImagesFolderPath);
        var images = Directory.GetFiles(imageDirectory);
        foreach (var configScreenOption in config.ScreenOptions)
        {
            var screenOption = ScreenTypeHelper.GetScreenType(configScreenOption);
            var count = 0;
            foreach (var image in images)
            {
                BuildImageForScreen(path, screenOption, image, showPath, count);
                count++;
            }
        }
    }


    public static void ResizeImage(string inputPath, int width, int height, string outputPath)
    {
        ConsoleWriter.Write($"Handling image: {inputPath}");
        using var input = File.OpenRead(inputPath);
        using var original = SKBitmap.Decode(inputPath);
        ConsoleWriter.Write(original != null ? "Image loaded successfully to be resized." : "Failed to load image.", original != null ? ConsoleMessageType.Information : ConsoleMessageType.Error);
        using var resized = original?.Resize(new SKImageInfo(width, height), SKSamplingOptions.Default);
        if (resized == null)
            throw new Exception("Failed to resize image.");

        using var image = SKImage.FromBitmap(resized);
        using var output = File.OpenWrite(outputPath);
        image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(output);
    }

    public static void BuildImageForScreen(string def, ScreenTypes types, string image, string outputPath,
        int pictureCount = 0)
    {
        if (types == ScreenTypes.Flat)
        {
            ResizeImage(image, 310, 128, $"{outputPath}/{def}_{pictureCount}_FlatScreen.png");
        }
        else if (types == ScreenTypes.Mega)
        {
            ResizeImage(image, 451, 128, $"{outputPath}/{def}_{pictureCount}_megascreen.png");
        }
        else if (types == ScreenTypes.Tube)
        {
            ResizeImage(image, 157, 128, $"{outputPath}/{def}_{pictureCount}_tube.png");
        }
    }
}