using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.Utility;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json.ExtensionMethods;
using UnityEngine;

namespace BetterSeaglideBZ
{
    [QModCore]
    public class MainPatch
    {
        public static bool pGlide;
        internal static SeaglideConfig SeaglideC { get; } = OptionsPanelHandler.Main.RegisterModOptions<SeaglideConfig>();

        public static SerializableColor FlashLightColor = new Color(0.016f, 1.000f, 1.000f);
        public static SerializableColor SeaglideModelColor = new Color(1.000f, 1.000f, 1.000f);
        public static SerializableColor MapColor = new Color(0.226f, 0.567f, 0.853f, 1.000f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static bool SeaglideColor;
        public static bool SeaglideLightOptions;
        public static float spotAngle;
        public static float seagliderValue;
        public static float seaglidegValue;
        public static float seaglidebValue;
        public static float boostSpeed;
        public static KeyCode BoostKey;

        public static void FirstStart()
        {
            rValue = SeaglideC.SeaglideLightRed;
            gValue = SeaglideC.SeaglideLightGreen;
            bValue = SeaglideC.SeaglideLightBlue;
            Intensity = SeaglideC.LightBrightness;
            Range = SeaglideC.LightRange;
            ToggleColor = SeaglideC.ToggleLightColor;
            SeaglideColor = SeaglideC.ToggleSeaglideColor;
            SeaglideLightOptions = SeaglideC.ToggleSeaglideLightOptions;
            spotAngle = SeaglideC.LightConeSize;
            seagliderValue = SeaglideC.SeaglideRed;
            seaglidegValue = SeaglideC.SeaglideGreen;
            seaglidebValue = SeaglideC.SeaglideBlue;
            BoostKey = SeaglideC.BoostKey;
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