using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace WaterFoodHotkeyBZ
{
    [QModCore]
    public static class MainPatch
    {
        internal static Config HotkeyConfig { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        public static bool EditNameCheck = false;

        public static KeyCode FoodDrinkHotKey;
        public static KeyCode MedHotKey;
        public static KeyCode HeatHotkey;

        public static string TextValue;

        public static bool ToggleFoodDrink;
        public static bool ToggleMedHotKey;
        public static bool ToggleHeatHotKey;

        public static float FoodDrinkPercentage;
        public static float HealthPercentage;
        public static float HeatPercentage;

        [QModPatch]
        public static void FirstStart()
        {
            FoodDrinkHotKey = HotkeyConfig.SetFoodDrinkHotKey;
            MedHotKey = HotkeyConfig.SetMedHotkey;
            HeatHotkey = HotkeyConfig.SetHeatHotKey;

            TextValue = HotkeyConfig.Text;

            ToggleFoodDrink = HotkeyConfig.ToggleFoodDrink;
            ToggleMedHotKey = HotkeyConfig.ToggleHealth;
            ToggleHeatHotKey = HotkeyConfig.ToggleHeat;

            FoodDrinkPercentage = HotkeyConfig.FoodDrinkPercent;
            HealthPercentage = HotkeyConfig.HealthPercent;
            HeatPercentage = HotkeyConfig.HeatPercent;

            //Patches
            Harmony harmony = new Harmony("WaterFoodHotkey.mod");
            harmony.PatchAll();

            //Player Patch for hotkey
            MethodInfo pInfo = AccessTools.Method(typeof(Player), nameof(Player.Update));
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.PlayerHeat_Patch), nameof(Patches.PlayerHeat_Patch.Patch_Player_Heat)), null);
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.PlayerHealth_Patch), nameof(Patches.PlayerHealth_Patch.Patch_Player_Health)), null);
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.PlayerFood_Patch), nameof(Patches.PlayerFood_Patch.Patch_Player_Food_Drink)), null);

            //Patches for checks to see if player is editing anything that contains typing in game
            MethodInfo Edit_Name_Check_Gui_Input_OnSelect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.OnSelect));
            MethodInfo Edit_Name_Check_Gui_Input_OnDeselect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.OnDeselect));
            MethodInfo Edit_Name_Check_Gui_Input_Deselect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.Deselect));
            harmony.Patch(Edit_Name_Check_Gui_Input_OnSelect, null, new HarmonyMethod(typeof(Patches.Patch_uGUI_InputGroup), nameof(Patches.Patch_uGUI_InputGroup.Patch_uGUI_InputGroup_OnSelect)), null);
            harmony.Patch(Edit_Name_Check_Gui_Input_OnDeselect, null, new HarmonyMethod(typeof(Patches.Patch_uGUI_InputGroup), nameof(Patches.Patch_uGUI_InputGroup.Patch_uGUI_InputGroup_OnDeselect)), null);
            harmony.Patch(Edit_Name_Check_Gui_Input_Deselect, null, new HarmonyMethod(typeof(Patches.Patch_uGUI_InputGroup), nameof(Patches.Patch_uGUI_InputGroup.Patch_uGUI_InputGroup_Deselect)), null);
        }
    }
}

