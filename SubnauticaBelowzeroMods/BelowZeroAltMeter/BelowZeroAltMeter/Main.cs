
using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;

namespace BelowZeroAltMeter
{
    [QModCore]
    public class MainPatch
    {
        internal static Config HotkeyConfig { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        public static bool ToggleSymbol;

        public static void FirstStart()
        {
            ToggleSymbol = HotkeyConfig.ToggleAltSymbol;
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
