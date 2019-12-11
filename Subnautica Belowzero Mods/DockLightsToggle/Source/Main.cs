using System.IO;
using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;
using UnityEngine;


namespace DockLightsToggle
{
    
    public static class MainPatch
    {
        public static bool seaTruckIsDocked = false;
        public static bool exoSuitIsDocked = false;
//        public static bool exuSuitIsDockOnSeaTruck = false;
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
        public static void SecondStart()
        {
            HarmonyInstance.Create("DockLightsToggle.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}