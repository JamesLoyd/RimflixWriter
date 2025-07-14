// See https://aka.ms/new-console-template for more information

using RimflixShowMaker;
using RimflixShowMaker.ModBuilder;
using Tomlyn;

Console.WriteLine("This program will generate a rimflix show for you!");
Console.WriteLine("You may still need to edit the images but the hard part will be done for you.");
Console.WriteLine("Make sure you read the README.md file for more information.");

var appConfig = File.ReadAllText("config.toml");
var model = Toml.ToModel<AppConfig>(appConfig);
Console.WriteLine("Reading from mod build folder of: " + model.ModBuildTargets);
Console.WriteLine("Mods will be built to mod release folder of: " + model.ModReleaseTargets);

var files  = Directory.EnumerateFiles(model.ModBuildTargets);
foreach (var file in files)
{
    if (file.EndsWith(".json"))
    {
        var conf = File.ReadAllText(file);
        var cof = Newtonsoft.Json.JsonConvert.DeserializeObject<ModConfig>(conf);
        ModBuilder.BuildMod(cof, model);
    }
}