using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkeyBZ.Patches
{
    public static class PlayerHealth_Patch
    {
        public static void Patch_Player_Health()
        {

            /*bool consoleOpened = (bool)typeof(DevConsole).GetField("state", BindingFlags.NonPublic |
            BindingFlags.Instance).GetValue(typeof(DevConsole).GetField("instance", BindingFlags.NonPublic |
            BindingFlags.Static).GetValue(null));*/

            Inventory pInventory = Inventory.main;

            IList<InventoryItem> medKit = pInventory.container.GetItems(TechType.FirstAidKit);
            if (Input.GetKeyDown(MainPatch.MedHotKey) && MainPatch.ToggleMedHotKey == false && !MainPatch.EditNameCheck)
            {
                if (MainPatch.TextValue == "Standard")
                {
                    ErrorMessage.AddWarning("You have Disabled The MedKit Hotkey");
                }
                else if (MainPatch.TextValue == "Fancy")
                {
                    Subtitles.Add("You Have Disabled The MedKit Hotkey");
                }
            }
            else if (Input.GetKeyDown(MainPatch.MedHotKey) && MainPatch.ToggleMedHotKey == true && !MainPatch.EditNameCheck)
            {
#if DEBUG
                Debug.Log($"[WaterDrinkHotkey] :: PlayerHealth is {Player.main.GetComponent<LiveMixin>().health}");
                Debug.Log($"[WaterDrinkHotkey] :: Player Creative Gamemode is {GameModeUtils.IsOptionActive(GameModeOption.Creative)}");
                Debug.Log($"[WaterDrinkHotkey] :: Player NoSurvival Gamemode is {GameModeUtils.IsOptionActive(GameModeOption.NoSurvival)}");
                Debug.Log($"[WaterDrinkHotkey] :: Player Freedom Gamemode is {GameModeUtils.IsOptionActive(GameModeOption.Freedom)}");
                Debug.Log($"[WaterDrinkHotkey] :: Player Survival Gamemode is {GameModeUtils.IsOptionActive(GameModeOption.Survival)}");
#endif
                if (Player.main.GetComponent<LiveMixin>().health <= MainPatch.HealthPercentage)
                {
                    if (medKit != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Use, medKit.First());
                    }
                    else
                    {
                        if (MainPatch.TextValue == "Standard")
                        {
                            ErrorMessage.AddWarning("You Do Not Have Any MedKits In your Inventory");
                        }
                        else if (MainPatch.TextValue == "Fancy")
                        {
                            Subtitles.Add("You Do Not Have Any MedKits In your Inventory");
                        }
                    }
                }
                else
                {
                    if (MainPatch.TextValue == "Standard")
                    {
                        ErrorMessage.AddWarning($"You Do not need to use a FirstAidKit Your health is already above {MainPatch.HealthPercentage}");
                    }
                    else if (MainPatch.TextValue == "Fancy")
                    {
                        Subtitles.Add($"You Do not need to use a FirstAidKit Your health is already above {MainPatch.HealthPercentage }");
                    }
                }
            }
        }
    }
}
