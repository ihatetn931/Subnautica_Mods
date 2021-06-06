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
            Inventory pInventory = Inventory.main;

            IList<InventoryItem> medKit = pInventory.container.GetItems(TechType.FirstAidKit);

            if (!MainPatch.EditNameCheck)
            {
                if (Input.GetKeyDown(MainPatch.MedHotKey))
                {
                    if (MainPatch.ToggleMedHotKey)
                    {
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
                                else if (MainPatch.TextValue == "Subtitles")
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
                            else if (MainPatch.TextValue == "Subtitles")
                            {
                                Subtitles.Add($"You Do not need to use a FirstAidKit Your health is already above {MainPatch.HealthPercentage }");
                            }
                        }
                    }
                    else
                    {
                        if (MainPatch.TextValue == "Standard")
                        {
                            ErrorMessage.AddWarning("You have Disabled The MedKit Hotkey");
                        }
                        else if (MainPatch.TextValue == "Subtitles")
                        {
                            Subtitles.Add("You Have Disabled The MedKit Hotkey");
                        }
                    }
                }
            }
        }
    }
}
