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