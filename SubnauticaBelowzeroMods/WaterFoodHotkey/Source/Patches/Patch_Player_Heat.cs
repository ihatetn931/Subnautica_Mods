using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkeyBZ.Patches
{
    class PlayerHeat_Patch
    {
        public static void Patch_Player_Heat()
        {
            Inventory pInventory = Inventory.main;
            List<InventoryItem> heatItems = new List<InventoryItem>();

            if (pInventory.container.itemsMap != null)
            {
                foreach (var test in pInventory.container.itemsMap)
                {
                    if (test != null)
                    {
                        if (test.item.GetComponent<Thermos>())
                        {
                            heatItems.Add(test);
                        }
                    }
                }
            }
            if (!MainPatch.EditNameCheck)
            {
                if (Input.GetKeyDown(MainPatch.HeatHotkey))
                {
                    if (MainPatch.ToggleHeatHotKey)
                    {
                        if (Player.main.GetComponent<Survival>().bodyTemperature.currentBodyHeatValue <= MainPatch.HeatPercentage)
                        {
                            if (heatItems.Count > 0)
                            {
                                pInventory.ExecuteItemAction(ItemAction.Eat, heatItems.First());
                            }
                            else
                            {
                                if (MainPatch.TextValue == "Standard")
                                {
                                    ErrorMessage.AddWarning("You Do Not Have Any Thermos In your Inventory");
                                }
                                else if (MainPatch.TextValue == "Subtitles")
                                {
                                    Subtitles.Add("You Do Not Have Any Thermos In your Inventory");
                                }
                            }
                        }
                        else
                        {
                            if (MainPatch.TextValue == "Standard")
                            {
                                ErrorMessage.AddWarning($"You Do Not Need To Use a Thermos Your Heat is Already Above {MainPatch.HeatPercentage}");
                            }
                            else if (MainPatch.TextValue == "Subtitles")
                            {
                                Subtitles.Add($"You Do Not Need To Use a Thermos Your Heat is Already Above {MainPatch.HeatPercentage}");
                            }
                        }
                    }
                    else
                    {
                        if (MainPatch.TextValue == "Standard")
                        {
                            ErrorMessage.AddWarning("You Have Disabled The Thermos Hotkey");
                        }
                        else if (MainPatch.TextValue == "Subtitles")
                        {
                            Subtitles.Add("You Have Disabled The Thermos Hotkey");
                        }
                    }
                }
            }

        }
    }

}



