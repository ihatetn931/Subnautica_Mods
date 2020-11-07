using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.Utility;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json.ExtensionMethods;

namespace BetterSeaglideBZ
{
    [QModCore]
    public class MainPatch
    {
        public static bool pGlide;
        internal static SeaglideConfig SeaglideC { get; } = OptionsPanelHandler.Main.RegisterModOptions<SeaglideConfig>();
        public static void FirstStart()
        {
            SecondStart();
        }

        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("BetterSeaglideBZ.mod");
            harmony.PatchAll();
        }
    }
}