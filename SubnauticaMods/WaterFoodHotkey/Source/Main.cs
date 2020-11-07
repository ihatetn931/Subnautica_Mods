using System.Reflection;
using SMLHelper.V2.Handlers;
using UnityEngine;
using HarmonyLib;
using QModManager.API.ModLoading;
using QModManager.Utility;
using System.IO;

namespace WaterFoodHotkey
{
    [QModCore]
    public static class MainPatch
    {
        public static bool EditNameCheck = false;
        public static bool SurvivalCheck = false;
        public static WaterFoodHotKeyStates settings;

        public static void FirstStart()
        {
            ConfigFile startupHandler = new ConfigFile();
            if (!File.Exists(ConfigFile.lightStatePath))
            {
                startupHandler.AttemptToCreate();
                if(startupHandler.AttemptToCreate())
                {
                    startupHandler.AttemptToLoad();
                }
            }
            ///QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"Settings: {settings}", null, true);
            if (settings != null)
            {
                if (settings.UseThisConfig)
                {
                    startupHandler.AttemptToLoad();
                    SecondStart();
                }
                else
                {
                    Config.Load();
                    OptionsPanelHandler.RegisterModOptions(new Options());
                    SecondStart();
                }
            }
        }
        [QModPatch]
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("WaterFoodHotkey.mod");

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

