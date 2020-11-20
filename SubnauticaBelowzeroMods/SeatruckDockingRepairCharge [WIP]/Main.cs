using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;

namespace SeatruckDockRepairCharge
{
    [QModCore]
    public class MainPatch
    {
        internal static MenuConfig DockingModule { get; } = OptionsPanelHandler.Main.RegisterModOptions<MenuConfig>();
        public static float RepairValue { get; set; }
        public static float ChargeValue { get; set; }
        public static void FirstStart()
        {
            DockingModule.LoadWithConverters();
            SecondStart();
        }
        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("SeatruckDockingModuleRepairCharge.mod");
            harmony.PatchAll();
        }
    }
}