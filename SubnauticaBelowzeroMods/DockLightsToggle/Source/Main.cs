using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;
using UnityEngine;


namespace DockLightsToggleBZ
{
    [QModCore]
    public static class MainPatch
    {
        public static bool seaTruckIsDocked = false;
        public static bool exoSuitIsDocked = false;
        public static bool snowfoxIsDocked = false;
        public static LightState state;

        public static void FirstStart()
        {
            if(ConfigFile.AttemptToLoad())
            {
                Config.Load();
                OptionsPanelHandler.RegisterModOptions(new Options());
                SecondStart();
            }
        }
        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("DockLightsToggle.mod");
            harmony.PatchAll();
        }
    }
}