namespace RimflixShowMaker.ModBuilder;

public static class BuildImageDefs
{
    public static IEnumerable<ImageSource> BuildImageSources(ModConfig config)
    {
        if (string.IsNullOrEmpty(config.SourceImagesFolderPath) || !Directory.Exists(config.SourceImagesFolderPath))
        {
            throw new DirectoryNotFoundException($"Source images folder not found: {config.SourceImagesFolderPath}");
        }

        var imageFiles = Directory.EnumerateFiles(config.SourceImagesFolderPath, "*.*", SearchOption.AllDirectories)
            .Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase));

        return imageFiles.Select(file => new ImageSource
        {
            TexPath = file,
            GraphicClass = "Graphic_Single"
        });
    }
}