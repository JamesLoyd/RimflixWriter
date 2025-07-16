namespace RimflixShowMaker.ModBuilder;

public static class BuildImageDefs
{
    public static IEnumerable<ImageSource> BuildImageSources(ModConfig config, string path, string VARIABLE)
    {
            var showPath = "" + path + "/Textures/Shows/" + VARIABLE;

        var imageFiles = Directory.EnumerateFiles(showPath, "*.*", SearchOption.AllDirectories)
            .Where(file => file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase));

        return imageFiles.Select(file => new ImageSource
        {
            TexPath = file.Split("/Textures/")[1],
            GraphicClass = "Graphic_Single"
        });
    }
}