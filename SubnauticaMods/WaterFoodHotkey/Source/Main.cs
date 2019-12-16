using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;


namespace WaterFoodHotkey
{
    public static class MainPatch
    {
        public static bool EditNameCheck = false;

        public static void FirstStart()
        {
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options());
#if DEBUG

            Debug.Log($"[WaterFoodHotkey] :: WaterHotKey is '{Config.WaterHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: FoodHotKey is '{Config.FoodHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: TextValue is '{Config.TextValue}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleWaterHotKey is '{Config.ToggleWaterHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: ToggleFoodHotKey is '{Config.ToggleFoodHotKey}'");
            Debug.Log($"[WaterFoodHotkey] :: Foodpercentage is '{Config.FoodPercentage}'");
            Debug.Log($"[WaterFoodHotkey] :: WaterPercentage is '{Config.WaterPercentage}'");
            Debug.Log($"[WaterFoodHotkey] Loaded Successfully");
#endif
            SecondStart();

        }

        public static void SecondStart()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("WaterFoodHotkey.mod");

            MethodInfo pInfo = AccessTools.Method(typeof(Player), "Update");
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.Water_Patch), nameof(Patches.Water_Patch.Patch_Player_Water)), null);
            harmony.Patch(pInfo, null, new HarmonyMethod(typeof(Patches.Food_Patch), nameof(Patches.Food_Patch.Patch_Player_Food)), null);

            //Patches for checks to see if player is editing anything that contains typing in game
            MethodInfo Edit_Name_Check_Gui_Input_OnSelect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.OnSelect));
            MethodInfo Edit_Name_Check_Gui_Input_OnDeselect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.OnDeselect));
            MethodInfo Edit_Name_Check_Gui_Input_Deselect = AccessTools.Method(typeof(uGUI_InputGroup), nameof(uGUI_InputGroup.Deselect));

            harmony.Patch(Edit_Name_Check_Gui_Input_OnSelect, null, new HarmonyMethod(typeof(Patches.Gui_Patch), nameof(Patches.Gui_Patch.Patch_uGUI_InputGroup_OnSelect)), null);
            harmony.Patch(Edit_Name_Check_Gui_Input_OnDeselect, null, new HarmonyMethod(typeof(Patches.Gui_Patch), nameof(Patches.Gui_Patch.Patch_uGUI_InputGroup_OnDeselect)), null);
            harmony.Patch(Edit_Name_Check_Gui_Input_Deselect, null, new HarmonyMethod(typeof(Patches.Gui_Patch), nameof(Patches.Gui_Patch.Patch_uGUI_InputGroup_Deselect)), null);
        }
    }
}

