
using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace BelowZeroAltMeter
{
    [QModCore]
    public class MainPatch
    {
        internal static Config HotkeyConfig { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        public static bool ToggleSymbol;
        public static bool ToggleDepthTextColor;
        public static bool ToggleAltTextColor;

        public static float DepthTextColorRed;
        public static float DepthTextColorGreen;
        public static float DepthTextColorBlue;

        public static float AltColorRed;
        public static float AltColorGreen;
        public static float AltColorBlue;

        public static void FirstStart()
        {
            ToggleSymbol = HotkeyConfig.ToggleAltSymbol;
            ToggleDepthTextColor = HotkeyConfig.ToggleDepthTextColor;
            ToggleAltTextColor = HotkeyConfig.ToggleAltTextColor;

            DepthTextColorRed = HotkeyConfig.DepthTextRed;
            DepthTextColorGreen = HotkeyConfig.DepthTextGreen;
            DepthTextColorBlue = HotkeyConfig.DepthTextBlue;

            AltColorRed = HotkeyConfig.AltTextRed;
            AltColorGreen = HotkeyConfig.AltTextGreen;
            AltColorBlue = HotkeyConfig.AltTextBlue;
            SecondStart();
        }
        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("BelowZeroAltMeter.mod");
            harmony.PatchAll();
        }
    }
}
