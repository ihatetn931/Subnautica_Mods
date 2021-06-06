using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace BetterFlashLightBZ
{
    [QModCore]
    public class MainPatch
    {
        internal static FlashLightConfig SeaglideC { get; } = OptionsPanelHandler.Main.RegisterModOptions<FlashLightConfig>();
        public static SerializableColor FlashLightColor = Color.white;
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static bool ToggleOptions;
        public static void FirstStart()
        {
            rValue = SeaglideC.SeaglideLightRed;
            gValue = SeaglideC.SeaglideLightGreen;
            bValue = SeaglideC.SeaglideLightBlue;
            Intensity = SeaglideC.LightBrightness;
            Range = SeaglideC.LightRange;
            ToggleColor = SeaglideC.ToggleFlashLightColor;
            ToggleOptions = SeaglideC.ToggleFlashLightOptions;
            SecondStart();
        }
        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("BetterFlashLightBZ.mod");
            harmony.PatchAll();
        }
    }
}