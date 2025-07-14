
## About

This is a simple tool that will generate rimflix mods for you.
I do not plan to release binaries, but if you want me to do so, please let me know.
Otherwise, it should be as simple as installing dotnet 6.0 and running the program.
Make sure the config.toml file is set up next to the executable.

## Building
Make sure dotnet 6.0 is installed on your system. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/6.0).
And then just cd into the root of the repository and then just do:
```
dotnet run
```

#### Note
The first run may take some time, but subsequent runs should be faster.
However, the more shows you are generating, the longer it will take.

## Running the Mod Generator
You will need to crate a config file called config.toml

```
mod_build_targets = "/path/to/mods"
mod_release_targets = "/path/to/mods"
```

For each mod you wish to make, you will need to add an ExampleModConfig.json file in the folder. 
Then all you need to do is create the pictures folder you listed. This must have a unique name, so the program can generate the mod correctly.

```json
{
  "screenOptions": ["flat", "mega", "tube"],
  "modName": "Rimflix - Hockey Flix",
  "author": "ExampleModAuthor",
  "packageId": "CommanderJroc.RimFlixHockey",
  "supportedVersions": [
    "1.5",
    "1.6"
  ],
  "description": "A mod that adds a hockey-themed screen to Rimflix.",
  "sourceImagesFolderPath": "/paths/to/your/images"
}
```

And then all you need to do is run the program. It will generate the mod(s) in the mod_release_targets folder.