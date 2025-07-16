namespace RimflixShowMaker.ModBuilder;

public static class ModBuilder
{
    public static void BuildMod(ModConfig config, AppConfig appConfig)
    {
        // check for images in the source folder
        if (!CheckForImages(config.SourceImagesFolderPath))
        {
            Console.WriteLine("No images found in the source folder. Please add images to the folder: " + config.SourceImagesFolderPath);
            return;
        }

        var homePath = appConfig.ModReleaseTargets + "/" + config.PackageId;
        Directory.Delete(homePath, true);
        Directory.CreateDirectory(homePath);
        BuildAbout(homePath, config);
        BuildDefs(homePath, config);
        BuildTextures(homePath, config);
    }

    private static bool CheckForImages(string path)
    {
        if (Directory.Exists(path))
        {
          return  Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories).Any();
        }

        return false;
    }

    private static void BuildAbout(string path, ModConfig config)
    {
        Directory.CreateDirectory(path + "/About");
        var modMetadata = new ModMetaData
        {
            Name = config.ModName,
            PackageId = config.PackageId,
            Author = config.Author,
            SupportedVersions = new SupportedVersions
            {
                Li = config.SupportedVersions.ToList(),
            },
            Description = config.Description,
        };
        
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ModMetaData));
        using var writer = new StreamWriter(path + "/About/about.xml");
        serializer.Serialize(writer, modMetadata);
    }

    private static void BuildDefs(string path, ModConfig config)
    {
        Directory.CreateDirectory(path + "/Defs/ShowDefs");
        foreach (var screenOptions in config.ScreenOptions)
        {
            var screen = ScreenTypeHelper.GetScreenType(screenOptions);
            foreach (var showDef in config.ShowDefNames)
            {
                var defName = $"{showDef}_{screen}screen";
                var defs = new Defs
                {
                    RimFlixShowDef = new RimFlixShowDef
                    {
                        DefName = defName,
                        Label = showDef,
                        Description = "A RimFlix show",
                        TelevisionDefs = new TelevisionDefs
                        {
                            Li = "FlatscreenTelevision"
                        },
                        SecondsBetweenFrames = double.Parse(config.SecondsBetweenFrames),
                        Sound = null, // Placeholder for sound, can be set later
                        Frames = new Frames
                        {
                            Li = BuildImageDefs.BuildImageSources(config).ToList()
                        }
                    }
                };
                var xmlserializer = new System.Xml.Serialization.XmlSerializer(typeof(Defs));
                var filePath = Path.Combine(path, "Defs", "ShowDefs", $"{defName}.xml");
                using (var writer = new StreamWriter(filePath))
                {
                    xmlserializer.Serialize(writer, defs);
                }
            }

        }
    }

    private static void BuildTextures(string path, ModConfig config)
    {
        Directory.CreateDirectory("" + path + "/Textures/Shows/" + config.ShowDefNames);
        ResizeImageHelper.Build(path, config);
    }
 }