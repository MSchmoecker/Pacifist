# Pacifist
## About
Removes blood, hit and death effects from the game.
If wanted, the attack behaviour of monsters to players can be disabled.

By default every blood, hit and death effect is disabled and the attack behaviour towards players is enabled.
This still provides a normal Valheim experience but without blood and gore.\
Every effect and attack behaviour can be toggled individually for every mob.
This also works ingame, but changes only apply for newly spawned creatures (restarting the game is sufficient).
The config is generated after you loaded into your world and also works with creatures from other mods if they haven't done something completely different from the vanilla game. 

I have no problem with blood and gore, but want to make the game accessible for those who do.
Please contact me if something is still present.

## Installation
This mod requires BepInEx and Jötunn.\
Extract the content of `Pacifist` into the `BepInEx/plugins` folder.

You can edit the config at `BepInEx/config/com.maxsch.valheim.pacifist.cfg`.\
vfx are Particles, sfx are sounds, ragdoll are dead bodies

## Development
BepInEx must be setup at manual or with r2modman/Thunderstore Mod Manager.
Jötunn must be installed.

Note the master branch will always use a stable Jötunn version while others may use a directly compiled one.

Create a file called `Environment.props` inside the project root.
Copy the example and change the Valheim install path to your location.
If you use r2modman/Tunderstore Mod Manager you can set the path too, but this is optional.

```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="Current" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <!-- Needs to be your path to the base Valheim folder -->
        <VALHEIM_INSTALL>E:\Programme\Steam\steamapps\common\Valheim</VALHEIM_INSTALL>
        <!-- Optional, needs to be the path to a r2modmanPlus profile folder -->
        <R2MODMAN_INSTALL>C:\Users\[user]\AppData\Roaming\r2modmanPlus-local\Valheim\profiles\Develop</R2MODMAN_INSTALL>
        <USE_R2MODMAN_AS_DEPLOY_FOLDER>false</USE_R2MODMAN_AS_DEPLOY_FOLDER>
    </PropertyGroup>
</Project>
```

If you want you can use `deploy.sh` to copy all files to your Valheim install.

## Links
- Discord: Margmas#9562

## Changelog
0.1.0
- Release
