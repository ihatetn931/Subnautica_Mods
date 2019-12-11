using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;



namespace WaterFoodHotkey
{
    public static class MainPatch
    {
       //// public static Configkey keyConfig;
        //public static TextDisplay textConfig;
        //public static ToggleKeys toggleConfig;
       // public static PercentageValues percentageConfig;

        public static bool EditNameCheck = false;

        public static void FirstStart()
        {
            //Build And Load Settings Menu
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options());
#if DEBUG

            Debug.Log($"[WaterFoodHotkey] :: WaterHotKey is '{Config.WaterHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: FoodHotKey is '{Config.FoodHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: MedHotKey is '{Config.MedHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: TextValue is '{Config.TextValue}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleWaterHotKey is '{Config.ToggleWaterHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleFoodHotKey is '{Config.ToggleFoodHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleMedHotKey is '{Config.ToggleMedHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: WaterPercentage is '{Config.WaterPercentage}'");
            Debug.Log($"[WaterFoodHotkey] :: FoodPercentage is '{Config.FoodPercentage}'");
            Debug.Log($"[WaterFoodHotkey] :: HealthPercentage is '{Config.HealthPercentage}'");
#endif
            //Patches
            HarmonyInstance harmony = HarmonyInstance.Create("WaterFoodHotkey.mod");
            // harmony.PatchAll(Assembly.GetExecutingAssembly());

            //Player Patch for hotkey
            MethodInfo pInfo = AccessTools.Method(typeof(Player), "Update");
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

