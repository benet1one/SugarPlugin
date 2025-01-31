# Slipstream Plugin Template

This is a template repository for people to create their own BepInEx plugins for Slipstream: Rogue Space. This template includes everything preconfigured, including the plugin I made to check the game version and a custom setting to toggle expanded logging.

 ## Requirements

- [Slipstream: Rogue Space (free on Steam)](https://playslipstream.com)
- [.NET](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [Thunderstore CLI](https://github.com/thunderstore-io/thunderstore-cli?tab=readme-ov-file#installation) (for bundling your plugin)
- [A Thunderstore account](https://thunderstore.io/c/slipstream-rogues-space) (for publishing your plugin)

Either:

- (Recommended) [r2modman](https://thunderstore.io/c/slipstream-rogue-space/p/ebkr/r2modman/) or [Gale](https://thunderstore.io/c/slipstream-rogue-space/p/Kesomannen/GaleModManager/) to manage installing mods/plugins.

OR

- [BepInEx (manually installed)](https://thunderstore.io/c/slipstream-rogue-space/p/BepInEx/BepInExPack/) if you want to manage plugins manually.

## (Quick-ish) Walkthrough Video

https://youtu.be/jUwMFtK2tOo

## Getting Started

These instructions assume you're on Windows, I'm unsure if these steps will work on any other operating system, good luck!

This guide is a combination of a few guides, here they are for additional reading, if desired:
- [BepinEx Plugin Development](https://docs.bepinex.dev/articles/dev_guide/plugin_tutorial/index.html)
- [TCLI Setup Instructions](https://github.com/thunderstore-io/thunderstore-cli?tab=readme-ov-file#installation) and [Authentication](https://github.com/thunderstore-io/thunderstore-cli/wiki#authentication)
- [GitHub Docs](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template)

### Using the template

1) To make your own copy of the template, press the green `Use this template` button and select `Create a new repository`
2) Choose a name and adjust any settings you want. (If you want easy game version checking, make sure the repository is set to `Public`)
3) Click `Create repository from template`

If this is your first time doing anything with Git, you can use [GitHub Desktop](https://desktop.github.com/) to "clone" your new repository to your computer. This allows you to edit it locally then save ("push") your changes online, backing it up and making sharing easy.

For the purpose of this guide I'll assume you're using GitHub Desktop.

4) Once GitHub Desktop is all setup, you can use the `Clone` button online to clone your repository. You can use the `Open in GitHub Desktop` option to automatically start the clone.
5) You should be able to `Show In Explorer` to find your project's files on your computer. (May need to go to the `Repository` menu at the top to see the option.)

### Setting up .NET and Visual Studio

1) [Download .NET 8 from here](https://dotnet.microsoft.com/download)
2) Run the installer.
3) To make sure it installed correctly, open up a command prompt and see if the command `dotnet --info` works. (Should display a bunch of information)

You can use any IDE to code your project, but for this template I've included Visual Studio project files and instructions.

4) [Download Visual Studio from here](https://visualstudio.microsoft.com/)
5) In the installer, make sure `.NET desktop development` is selected. This makes sure Visual Studio is setup for C# development.
6) Finish the installer.
7) Open up Visual Studio and open the project by selecting the [TemplatePlugin.sln](TemplatePlugin/TemplatePlugin.sln) file.

### Setting up a Thunderstore account.

This template is setup to publish plugins to [Thunderstore](https://thunderstore.io/c/slipstream-rogue-space), which allows mod managers to download the mods automatically.

To create an account, just go to the `Sign in with...` in the top right and select an option.

(If you want you can also link multiple of the ways to login [in settings](https://thunderstore.io/settings/linked-accounts/), so you don't have to remember which one you used)

Only other thing to do right now is make sure you have [a Team](https://thunderstore.io/settings/teams/), I'd recommend naming it your username.

### Customizing the template

Here are all the changes you should make inside Visual Studio to update the branding from the template:

#### TemplatePlugin folder

8) Rename the "TemplatePlugin" folder to your plugin's name.

#### TemplatePlugin.cs

9) Rename the file to your plugin's name, keeping the extension the same. (You can right-click the file in Visual Studio to do this.)
10) Rename all references in the file to `TemplatePlugin` to your plugin's name
12) On the line with GAME_VERSION_URL change `MoSadie` to your GitHub username and `Slipstream-Template-Plugin` to your repository's name

#### TemplatePlugin.csproj

13) Rename the file to your plugin's name, keeping the extension the same. (You can right-click the file in Visual Studio to do this.)
14) Change the value of `AssemblyName` to something unique. I recommend matching the format: `<reverse domain name>.<plugin name>` (if you don't have a website, use `io.github.USERNAME` for the reverse domain name part.)
15) Change the value of `Product` to your plugin's name.
16) Change the value of `Description` to be a one sentence description of your plugin.

#### TemplatePlugin.sln

17) Rename the project to your plugin's name, keeping the extension the same. (You can right-click the project in Visual Studio to do this.)

Make sure to save all your changes!

The rest of these files are not visible inside of Visual Studio and must be edited manually.

#### icon.png

18) Replace with your own icon!

#### thunderstore.toml

19) Update `namespace` to be your [team name on Thunderstore](https://thunderstore.io/settings/teams/)
20) Update `name` to be your plugin's name.
21) Update `description` to be your plugin's one sentence description.
22) Update `websiteUrl` to the webpage you want associated with your plugin, I'd recommend linking to the GitHub repository for your plugin.
23) Update lines 22 and 23 to point to the correct files:
    - Change `TemplatePlugin` to your plugin's folder name.
    - Change `com.mosadie.templateplugin` to the AssemblyName you set before, making sure to keep the `.dll` at the end. (Do this for both lines.)
    - Change `MoSadie-TemplatePlugin` to `YourTeamName-YourPluginName`

#### README.md

This will become the description of your plugin, so update this file accordingly! (If you need a template feel free to copy what my other plugins are doing.)

#### CHANGELOG.md

This will become the "Changes" tab on your plugin's page, so update this file accordingly!

### Getting Building working

You may have noticed that you are getting multiple errors about files being missing. That's because some of these files come from external sources.

If you look inside the `lib` folder you'll find instructions on what files you need and where to find them. Place those files in the correct locations and those errors should dissapear.

Now that your files are there, you can build using the `Build` -> `Build Solution` button or pressing `CTRL + Shift + B`. You'll want to leave the Debug/Release dropdown on Release, so the bundler can find your plugin.

### Setting Up TCLI

TCLI (aka the Thunderstore CLI) is used to bundle up the plugin into a format recongized by the mod managers. It also, when you're ready, handles publishing your plugins to Thunderstore.

To install it, just run this command in your command prompt: ```dotnet tool install -g tcli```

Then navigate the command prompt to your local plugin project files (where thunderstore.toml is located)

(Or just launch the command prompt in the right folder by going to GitHub Desktop and clicking `Respository` -> `Open in Command Prompt`)

You can bundle the plugin for local testing by running `tcli build` (make sure to build in Visual Studio first!)

You can then import the zip file created in the `build` folder as a local mod into your mod manager.

Once you're ready to publish, follow the steps [here](https://github.com/thunderstore-io/thunderstore-cli/wiki#authentication) to setup a service account and get the token. (DO NOT SHARE THE TOKEN, EVER.)

Then you can publish by typing this command: `tcli publish --token ReplaceWithTheToken`

Congrats! 🎉 After a few minutes people can start downloading your plugin from their mod manager!

## Creating a new version

1) Update thunderstore.toml with the new version number.
2) Update your `.csproj` file with the new version number.
3) Add an entry in [versions.json](versions.json) for the new version number.
4) Build and bundle the plugin.
5) After testing locally, (Change MoCore's settings to disable the version checker if needed) commit & push to GitHub then publish using `tcli publish --token ReplaceWithTheToken`

## When The Game Updates

Here's what to do:

1) Update any files in `lib` from the game to the latest version.
2) Check to see if the project still builds with the change.
3) If the project still builds, bundle it and test it.
    - Make sure to go to MoCore's settings in your mod manager and disable the version checker.
    - Also update the version in your main plugin file. (`COMPATIBLE_GAME_VERSION`)
    - If everything works, note down the game version number and update the list of compatible game versions in [versions.json](versions.json) for that plugin version.
    - Then commit and push the updated versions.json file to GitHub, this may take a few minutes for the cache to clear.
4) If it doesn't work, fix what's broken, and [create a new version](#creating-a-new-version).



## Other Notes

- If your crew member is not the captain/first mate, some information about the ship status is not available or may be inaccurate.
- In general, the client only knows the minimum information to display on screen.
- If you're curious about what is available to hook into in the game I personally use [dotPeek](https://www.jetbrains.com/decompiler/) to see what is available.

- **PLEASE BE NICE TO THE DEVS**
    - Be careful with exceptions. Otherwise you will accidentally spam their logs. Ask me how I know.
        - Your plugin info WILL be included in their logging.
    - Do NOT spam packets at the servers, please try and minimize any spammy server requests. Honestly most information you could want is already cached locally, just need to find it.
    - If they ask you to stop doing a feature/thing, *it's dead*. Do NOT make them waste their time solving problems we cause.
    - In looking around the game files you will likely see things not yet revealed, keep them secret. Assume they don't work.
    - Please make clear to your users how they can get in contact with you, since they're using your plugin they should reach out to *you* first for support, not the devs.
- **YOU DO NOT HAVE ACCESS TO THE SERVER**
    - Sorry to ruin your dreams, but you won't be able to move other players or modify how the map is generated.
    - You only know what the client knows. Please be careful when dealing with showing more information than what the client actually shows.
- **NON-MODIFIED PLAYERS WILL JOIN YOUR SHIP**
    - Since anyone can join a ship, this will happen. Make sure your plugin doesn't depend on *everyone* having it.
    - This will also happen if you launch a ship while testing, just be polite. Use the Helm to issue orders if you're not running any real runs.

## Plugin Configuration Options

### DebugLogs

Enables additional logging for debugging. Disabled by default. Default value: `false`