namespace RimflixShowMaker;

public class ModConfig
{
    public IEnumerable<string> ScreenOptions { get; set; }
    public string ModName { get; set; }
    public string Author { get; set; }
    public string PackageId { get; set; }
    public IEnumerable<string> SupportedVersions { get; set; }
    public string Description { get; set; }
    public string SourceImagesFolderPath { get; set; }
    public IEnumerable<string> ShowDefNames { get; set; }
    public string SecondsBetweenFrames { get; set; }
}

public class AppConfig
{
    public string ModBuildTargets { get; set; }
    public string ModReleaseTargets { get; set; }
}