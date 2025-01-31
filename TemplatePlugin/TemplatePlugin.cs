using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;
using System;
using MoCore;
using Subpixel.Events;

namespace TemplatePlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.mosadie.mocore", BepInDependency.DependencyFlags.HardDependency)]
    [BepInProcess("Slipstream_Win.exe")]
    public class TemplatePlugin : BaseUnityPlugin, MoPlugin
    {
        private static ConfigEntry<bool> debugLogs;

        internal static ManualLogSource Log;

        public static readonly string COMPATIBLE_GAME_VERSION = "4.1595"; // This is the fallback version if the version check fails, keep this up to date with the latest version of Slipstream: Rogue Space. The current versions is printed in the console when the game is started.
        public static readonly string GAME_VERSION_URL = "https://raw.githubusercontent.com/MoSadie/Slipstream-Template-Plugin/refs/heads/main/versions.json"; //FIXME: Update this URL to point to your own version file.

        // This is called when the plugin is loaded as a component on the BepInEx GameObject.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Actually used once compiled.")]
        private void Awake()
        {
            try
            {
                // Configure the logger, call this directly to bypass the configuration option.
                TemplatePlugin.Log = base.Logger;

                // Version checking code, if the game version is not compatible, RegisterPlugin will return false.
                if (!MoCore.MoCore.RegisterPlugin(this))
                {
                    Log.LogError("Failed to register plugin with MoCore. Please check the logs for more information.");
                    return;
                }

                // Define configuration options
                debugLogs = Config.Bind("Debug", "DebugLogs", false, "Enable additional logging for debugging");

                // Here is where you would add your own initialization code
                // as an example, we will log when a ship is loaded.

                // Register the event listener, see the method OnShipLoaded for the logging code.
                Svc.Get<Events>().AddListener<ShipLoadedEvent>(OnShipLoaded, 1);

                // Other useful events to know about:
                // - BattleStartEvent
                // - BattleEndEvent
                // - CampaignStartEvent
                // - CampaignEndEvent
                // - CrewmateCreatedEvent
                // - CrewmateRemovedEvent
                // - ... and more!


                // This is an example of how to listen for the application quitting event from Unity.
                Application.quitting += ApplicationQuitting;

                Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            } catch (Exception e)
            {
                Log.LogError("An error occurred while starting the plugin.");
                Log.LogError(e.Message);
            }

        }

        // The following methods are used to log messages to the console, but ONLY when the debugLogs plugin configuration option is enabled.

        internal static void DebugLogInfo(string message)
        {
            if (debugLogs.Value)
            {
                Log.LogInfo(message);
            }
        }

        internal static void DebugLogWarn(string message)
        {
            if (debugLogs.Value)
            {
                Log.LogWarning(message);
            }
        }

        internal static void DebugLogError(string message)
        {
            if (debugLogs.Value)
            {
                Log.LogError(message);
            }
        }

        internal static void DebugLogDebug(string message)
        {
            if (debugLogs.Value)
            {
                Log.LogDebug(message);
            }
        }

        // This is the event listener for the ShipLoadedEvent we registered in the Awake method.

        private void OnShipLoaded(ShipLoadedEvent e)
        {
            // Since we want this log to always happen, we don't use the debugLogInfo method.
            Log.LogInfo($"Ship loaded!");
        }

        // This is the event listener for the Application.quitting event.
        private void ApplicationQuitting()
        {
            // If you need to do any cleanup, do it here
            
            DebugLogInfo($"Cleanup complete for {PluginInfo.PLUGIN_NAME}");
        }



        // Should not need to modify anything below this line, these are used for MoCore to check game version compatibility.

        public string GetCompatibleGameVersion()
        {
            return COMPATIBLE_GAME_VERSION;
        }

        public string GetVersionCheckUrl()
        {
            return GAME_VERSION_URL;
        }

        public BaseUnityPlugin GetPluginObject()
        {
            return this;
        }
    }
}
