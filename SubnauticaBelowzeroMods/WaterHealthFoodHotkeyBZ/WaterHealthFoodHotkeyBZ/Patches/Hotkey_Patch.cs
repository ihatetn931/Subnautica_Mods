using HarmonyLib;
using QModManager.API.ModLoading;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ItemsContainer;

namespace WaterHealthFoodHotkeyBZ.Patch
{
    class Hotkey_Patch
    {

        [HarmonyPatch(typeof(Player))]
        [HarmonyPatch("Update")]
        class Player_Update_Patch
        {
            [QModPrePatch]
            public static bool Prefix(Player __instance)
            {
                foreach (InventoryItem itemTypes in Inventory.main.container)
                {
                    Inventory itemT = Inventory.main;
                    Eatable comp = itemTypes.item.GetComponent<Eatable>();
                    IList<InventoryItem> allItems = itemT.container.GetItems(itemTypes.item.GetTechType());
                    IList<InventoryItem> inventoryItems = new List<InventoryItem>();
                    if (allItems != null)
                    {
                        foreach (var aItems in allItems)
                        {
                            if (comp && aItems.item.GetTechType() != TechType.Coffee)
                            {
                                inventoryItems.Add(aItems);
                                QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"aItems Added { aItems.item.name}", null, true);
                            }
                            else
                            {
                                inventoryItems.Remove(aItems);
                                // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"aItems Removed {aItems.item.name}", null, true);
                            }
                            //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Allitems { aItems.item.name}", null, true);
                            //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Allitems First { allItems.First().item.name}", null, true);
                        }
                    }
                    //  Pickupable pickup = itemTypes.item.GetComponent<Pickupable>();
                    // IList<InventoryItem> medKit = itemT.container.GetItems(TechType.FirstAidKit);
                    //IList<InventoryItem> ignoredItems = new List<InventoryItem>();
                    if (inventoryItems != null)
                    {
                        /*if (comp != null)
                        {
                            //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Comp:{comp} / item:{itemTypes.item}", null, true);

                            if (comp && itemTypes.item.GetTechType() != TechType.Coffee)/*GetComponent<Eatable>().name.Contains("Coffee(Clone)")
                            {
                                QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"itemtypes Added { itemTypes.item.name}", null, true);
                                inventoryItems.Add(itemTypes);
                            }
                            else
                            {
                                QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"itemtypes Removed {itemTypes.item.name}", null, true);
                                inventoryItems.Remove(itemTypes);
                               // ignoredItems.Add(itemTypes.item.name);
                            }
                        }*/

                        //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"IItems:{inventoryItems.First()}", null, true);
                        //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"InventoryItems:{inventoryItems}", null, true);
                        if (comp != null)
                        {
                            if (MainPatch.ToggleFoodHotKey)
                            {
                                if (Input.GetKeyDown(MainPatch.FoodHotKey) && MainPatch.EditNameCheck == false)
                                {
                                    if (Player.main.GetComponent<Survival>().food <= MainPatch.FoodPercentage)
                                    {
                                        if (comp.decomposes)
                                        {
                                            itemT.ExecuteItemAction(ItemAction.Eat, inventoryItems.First());
                                            if (MainPatch.TextValue == "Standard")
                                            {
                                                ErrorMessage.AddWarning($"{inventoryItems.First().item.name.Replace("(Clone)", "")} eaten");
                                            }
                                            else if (MainPatch.TextValue == "Fancy")
                                            {
                                                Subtitles.Add($"{inventoryItems.First().item.name.Replace("(Clone)", "")} eaten");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (MainPatch.TextValue == "Standard")
                                        {
                                            ErrorMessage.AddWarning($"You Do Not Need To Eat, You're Not Hungry");
                                        }
                                        else if (MainPatch.TextValue == "Fancy")
                                        {
                                            Subtitles.Add($"You Do Not Need To Eat, You're Not Hungry");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (MainPatch.TextValue == "Standard")
                                {
                                    ErrorMessage.AddWarning($"You have Disabled The Food Hotkey");
                                }
                                else if (MainPatch.TextValue == "Fancy")
                                {
                                    Subtitles.Add($"You have Disabled The Food Hotkey");
                                }
                            }
                            if (Input.GetKeyDown(MainPatch.WaterHotKey) && MainPatch.EditNameCheck == false)
                            {
                                if (MainPatch.ToggleWaterHotKey)
                                {
                                    if (!comp.decomposes)
                                    {
                                        if (itemTypes.item.name != null)
                                        {
                                            if (Player.main.GetComponent<Survival>().water <= MainPatch.WaterPercentage)
                                            {
                                                itemT.ExecuteItemAction(ItemAction.Eat, inventoryItems.First());
                                                if (MainPatch.TextValue == "Standard")
                                                {
                                                    ErrorMessage.AddWarning($"{inventoryItems.First().item.name.Replace("(Clone)", "")} drank");
                                                }
                                                else if (MainPatch.TextValue == "Fancy")
                                                {
                                                    Subtitles.Add($"{inventoryItems.First().item.name.Replace("(Clone)", "")} drank");
                                                }
                                            }
                                            else
                                            {
                                                if (MainPatch.TextValue == "Standard")
                                                {
                                                    ErrorMessage.AddWarning($"You Do Not Need A Drink, You're Not Thirsty");
                                                }
                                                else if (MainPatch.TextValue == "Fancy")
                                                {
                                                    Subtitles.Add($"You Do Not Need A Drink, You're Not Thirsty");
                                                }
                                            }
                                            // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"ItemNameWater:{itemTypes.item.name}", null, false);
                                        }
                                        else
                                        {
                                            if (itemTypes.item.name == null)
                                            {
                                                if (MainPatch.TextValue == "Standard")
                                                {
                                                    ErrorMessage.AddWarning($"You Do Not Have Any Drinkable Items In your Inventory");
                                                }
                                                else if (MainPatch.TextValue == "Fancy")
                                                {
                                                    Subtitles.Add($"You Do Not Have Any Drinkable Items In your Inventory");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (MainPatch.TextValue == "Standard")
                                    {
                                        ErrorMessage.AddWarning($"You have Disabled The Water Hotkey");
                                    }
                                    else if (MainPatch.TextValue == "Fancy")
                                    {
                                        Subtitles.Add($"You have Disabled The Water Hotkey");
                                    }
                                }

                            }
                            else if (Input.GetKeyDown(MainPatch.MedHotKey) && MainPatch.EditNameCheck == false)
                            {
                                if (MainPatch.ToggleMedHotKey)
                                {
                                    if (Player.main.GetComponent<LiveMixin>().health <= MainPatch.HealthPercentage)
                                    {
                                        /*if (iItems != null)
                                        {
                                            itemT.ExecuteItemAction(ItemAction.Use, iItems); ;
                                            ErrorMessage.AddWarning("First Aid Kit Used");
                                            // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Med:{med}", null, true);
                                        }*/
                                    }
                                    else
                                    {
                                        if (MainPatch.TextValue == "Standard")
                                        {
                                            ErrorMessage.AddWarning($"You Do Not Need A Heal, You Have Enough Health");
                                        }
                                        else if (MainPatch.TextValue == "Fancy")
                                        {
                                            Subtitles.Add($"You Do Not Need A Heal, You Have Enough Health");
                                        }
                                    }
                                }
                                else
                                {
                                    if (MainPatch.TextValue == "Standard")
                                    {
                                        ErrorMessage.AddWarning($"You have Disabled The Medkit Hotkey");
                                    }
                                    else if (MainPatch.TextValue == "Fancy")
                                    {
                                        Subtitles.Add($"You have Disabled The Medkit Hotkey");
                                    }
                                }
                            }
                            // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Med:{med}", null, true);
                            // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Test:{comp.decomposes}", null, true); 


                        }
                    }
                }
                return true;
            }
        }
    }
}


