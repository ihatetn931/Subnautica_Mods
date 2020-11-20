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
        //// public static Configkey keyConfig;
        //public static TextDisplay textConfig;
        //public static ToggleKeys toggleConfig;
        // public static PercentageValues percentageConfig;
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
        [QModPatch]
        public static void FirstStart()
        {
            //Build And Load Settings Menu
            //Config.Load();
            //HotkeyConfig.Load();
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
            //OptionsPanelHandler.RegisterModOptions(new Options());
#if DEBUG

            Debug.Log($"[WaterFoodHotkey] :: WaterHotKey is '{WaterHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: FoodHotKey is '{FoodHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: MedHotKey is '{MedHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: TextValue is '{TextValue}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleWaterHotKey is '{ToggleWaterHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleFoodHotKey is '{ToggleFoodHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleMedHotKey is '{ToggleMedHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: WaterPercentage is '{WaterPercentage}'");
            Debug.Log($"[WaterFoodHotkey] :: FoodPercentage is '{FoodPercentage}'");
            Debug.Log($"[WaterFoodHotkey] :: HealthPercentage is '{HealthPercentage}'");
#endif
            //Patches
            Harmony harmony = new Harmony("WaterFoodHotkey.mod");
            harmony.PatchAll();

            //Player Patch for hotkey
            MethodInfo pInfo = AccessTools.Method(typeof(Player), nameof(Player.Update));
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.PlayerWater_Patch), nameof(Patches.PlayerWater_Patch.Patch_Player_Water)), null);
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.PlayerHealth_Patch), nameof(Patches.PlayerHealth_Patch.Patch_Player_Health)), null);
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.PlayerFood_Patch), nameof(Patches.PlayerFood_Patch.Patch_Player_Food)), null);

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

