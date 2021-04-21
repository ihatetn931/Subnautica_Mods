using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.Utility;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Json.ExtensionMethods;
using UnityEngine;
using WaterHealthFoodHotkeyBZ.Menu;

namespace WaterHealthFoodHotkeyBZ
{
    [QModCore]
    public class MainPatch
    {
        internal static Config HotkeyConfig { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        public static bool EditNameCheck = false;
        public static KeyCode WaterHotKey;
        public static KeyCode FoodHotKey;
        public static KeyCode MedHotKey;

        public static string TextValue;

        public static bool ToggleWaterHotKey;
        public static bool ToggleFoodHotKey;
        public static bool ToggleMedHotKey;

        public static float WaterPercentage;
        public static float FoodPercentage;
        public static float HealthPercentage;

        public static void FirstStart()
        {
            WaterHotKey = HotkeyConfig.SetWaterHotkey;
            FoodHotKey = HotkeyConfig.SetFoodHotkey;
            MedHotKey = HotkeyConfig.SetMedHotkey;

            TextValue = HotkeyConfig.Text;

            ToggleWaterHotKey = HotkeyConfig.ToggleWater;
            ToggleFoodHotKey = HotkeyConfig.ToggleFood;
            ToggleMedHotKey = HotkeyConfig.ToggleHealth;

            WaterPercentage = HotkeyConfig.WaterPercent;
            FoodPercentage = HotkeyConfig.FoodPercent;
            HealthPercentage = HotkeyConfig.HealthPercent;

            SecondStart();
        }

        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("WaterHealthFoodHotkeyBZ.mod");
            //Patches for checks to see if player is editing anything that contains typing in game
            MethodInfo Edit_Name_Check_Gui_Input_OnSelect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.OnSelect));
            MethodInfo Edit_Name_Check_Gui_Input_OnDeselect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.OnDeselect));
            MethodInfo Edit_Name_Check_Gui_Input_Deselect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.Deselect));
            harmony.Patch(Edit_Name_Check_Gui_Input_OnSelect, null, new HarmonyMethod(typeof(Patches.Patch_uGUI_InputGroup), nameof(Patches.Patch_uGUI_InputGroup.Patch_uGUI_InputGroup_OnSelect)), null);
            harmony.Patch(Edit_Name_Check_Gui_Input_OnDeselect, null, new HarmonyMethod(typeof(Patches.Patch_uGUI_InputGroup), nameof(Patches.Patch_uGUI_InputGroup.Patch_uGUI_InputGroup_OnDeselect)), null);
            harmony.Patch(Edit_Name_Check_Gui_Input_Deselect, null, new HarmonyMethod(typeof(Patches.Patch_uGUI_InputGroup), nameof(Patches.Patch_uGUI_InputGroup.Patch_uGUI_InputGroup_Deselect)), null);
            harmony.PatchAll();
        }
    }
}

