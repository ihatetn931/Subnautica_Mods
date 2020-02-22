
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WaterFoodHotkey.Patches
{
    public static class Water_Patch
    {
        public static void Patch_Player_Water()
        {

            /*bool consoleOpened = (bool)typeof(DevConsole).GetField("state", BindingFlags.NonPublic |
            BindingFlags.Instance).GetValue(typeof(DevConsole).GetField("instance", BindingFlags.NonPublic |
            BindingFlags.Static).GetValue(null));*/

            Inventory pInventory = Inventory.main;

            IList<InventoryItem> filteredWater = pInventory.container.GetItems(TechType.FilteredWater);
            IList<InventoryItem> stillSuitWater = pInventory.container.GetItems(TechType.StillsuitWater);
            IList<InventoryItem> disinfectedWater = pInventory.container.GetItems(TechType.DisinfectedWater);
            IList<InventoryItem> bigfilteredWater = pInventory.container.GetItems(TechType.BigFilteredWater);
            IList<InventoryItem> cOffee = pInventory.container.GetItems(TechType.Coffee);

            if (Input.GetKeyDown(Config.WaterHotKey) && Config.ToggleWaterHotKey == false && !MainPatch.EditNameCheck)
            {
                if (Config.TextValue == 0)
                {
                    ErrorMessage.AddWarning("You have Disabled The Water Hotkey");
                }
                else if (Config.TextValue == 1)
                {
                    Subtitles.main.Add("You Have Disabled The Water Hotkey");
                }
            }
            else if (Input.GetKeyDown(Config.WaterHotKey) && Config.ToggleWaterHotKey && !MainPatch.EditNameCheck)
            {
                if (Player.main.GetComponent<Survival>().water <= Config.WaterPercentage)
                {
                    if (filteredWater != null)
                    {
                        pInventory.UseItem(filteredWater.First());
                    }
                    else if (stillSuitWater != null)
                    {
                        pInventory.UseItem(stillSuitWater.First());
                    }
                    else if (disinfectedWater != null)
                    {
                        pInventory.UseItem(disinfectedWater.First());
                    }
                    else if (bigfilteredWater != null)
                    {
                        pInventory.UseItem(bigfilteredWater.First());
                    }
                    else if (cOffee != null)
                    {
                        pInventory.UseItem(cOffee.First());
                    }
                    else
                    {
                        if (Config.TextValue == 0)
                        {
                            ErrorMessage.AddWarning("You Do Not Have Any Drinkable Items In your Inventory");
                        }
                        else if (Config.TextValue == 1)
                        {
                            Subtitles.main.Add("You Do Not Have Any Drinkable Items In your Inventory");
                        }
                    }
                }

                else
                {
                    if (Config.TextValue == 0)
                    {
                        ErrorMessage.AddWarning("You Do Not Need A Drink, You're Not Thirsty");
                    }
                    else if (Config.TextValue == 1)
                    {
                        Subtitles.main.Add("You Do Not Need A Drink, You're Not Thirsty");
                    }
                }
            }
        }
    }
}
