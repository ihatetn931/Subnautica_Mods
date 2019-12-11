using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkey.Patches
{
    class Food_Patch
    {
        public static void Patch_Player_Food()
        {
            /*bool consoleOpened = (bool)typeof(DevConsole).GetField("state", BindingFlags.NonPublic |
            BindingFlags.Instance).GetValue(typeof(DevConsole).GetField("instance", BindingFlags.NonPublic |
            BindingFlags.Static).GetValue(null));*/

            Inventory pInventory = Inventory.main;

            IList<InventoryItem> cookedBladderFish = pInventory.container.GetItems(TechType.CookedBladderfish);
            IList<InventoryItem> cookedBoomerang = pInventory.container.GetItems(TechType.CookedBoomerang);
            IList<InventoryItem> cookedEyeeye = pInventory.container.GetItems(TechType.CookedEyeye);
            IList<InventoryItem> cookedGarryFish = pInventory.container.GetItems(TechType.CookedGarryFish);
            IList<InventoryItem> cookedHoleFish = pInventory.container.GetItems(TechType.CookedHoleFish);
            IList<InventoryItem> cookedHoopFish = pInventory.container.GetItems(TechType.CookedHoopfish);
            IList<InventoryItem> cookedHoverFish = pInventory.container.GetItems(TechType.CookedHoverfish);
            IList<InventoryItem> cookedLavaBoomerang = pInventory.container.GetItems(TechType.CookedLavaBoomerang);
            IList<InventoryItem> cookedLavaEyeeye = pInventory.container.GetItems(TechType.CookedLavaEyeye);
            IList<InventoryItem> cookedOculus = pInventory.container.GetItems(TechType.CookedOculus);
            IList<InventoryItem> cookedPeeper = pInventory.container.GetItems(TechType.CookedPeeper);
            IList<InventoryItem> cookedReginald = pInventory.container.GetItems(TechType.CookedReginald);
            IList<InventoryItem> cookedSpadeFish = pInventory.container.GetItems(TechType.CookedSpadefish);
            IList<InventoryItem> cookedSpineFish = pInventory.container.GetItems(TechType.CookedSpinefish);
            IList<InventoryItem> curedBladderFish = pInventory.container.GetItems(TechType.CuredBladderfish);
            IList<InventoryItem> curedBoomerang = pInventory.container.GetItems(TechType.CuredBoomerang);
            IList<InventoryItem> curedEyeeye = pInventory.container.GetItems(TechType.CuredEyeye);
            IList<InventoryItem> curedGarryFish = pInventory.container.GetItems(TechType.CuredGarryFish);
            IList<InventoryItem> curedHoleFish = pInventory.container.GetItems(TechType.CuredHoleFish);
            IList<InventoryItem> curedHoopFish = pInventory.container.GetItems(TechType.CuredHoopfish);
            IList<InventoryItem> curedHoverFish = pInventory.container.GetItems(TechType.CuredHoverfish);
            IList<InventoryItem> curedLavaBoomerang = pInventory.container.GetItems(TechType.CuredLavaBoomerang);
            IList<InventoryItem> curedLavaEyeeye = pInventory.container.GetItems(TechType.CuredLavaEyeye);
            IList<InventoryItem> curedOculus = pInventory.container.GetItems(TechType.CuredOculus);
            IList<InventoryItem> curedPeeper = pInventory.container.GetItems(TechType.CuredPeeper);
            IList<InventoryItem> curedReginald = pInventory.container.GetItems(TechType.CuredReginald);
            IList<InventoryItem> curedSpadeFish = pInventory.container.GetItems(TechType.CuredSpadefish);
            IList<InventoryItem> curedSpineFish = pInventory.container.GetItems(TechType.CuredSpinefish);
            IList<InventoryItem> bulboTreeFruit = pInventory.container.GetItems(TechType.BulboTreePiece);
            IList<InventoryItem> chinaPotato = pInventory.container.GetItems(TechType.PurpleVegetable);
            IList<InventoryItem> laternFruit = pInventory.container.GetItems(TechType.HangingFruit);
            IList<InventoryItem> marbleMelon = pInventory.container.GetItems(TechType.Melon);
            IList<InventoryItem> nutBlock = pInventory.container.GetItems(TechType.NutrientBlock);
            IList<InventoryItem> snacks1 = pInventory.container.GetItems(TechType.Snack1);
            IList<InventoryItem> snacks2 = pInventory.container.GetItems(TechType.Snack2);
            IList<InventoryItem> snacks3 = pInventory.container.GetItems(TechType.Snack3);
            if (Input.GetKeyDown(Config.FoodHotKey) && Config.ToggleFoodHotKey == false)
            {
                if (Config.TextValue == 0)
                {
                    ErrorMessage.AddWarning("You have Disabled The Food Hotkey");
                }
                else if (Config.TextValue == 1)
                {
                    Subtitles.main.Add("You Have Disabled The Food Hotkey");
                }
            }
            else if (Input.GetKeyDown(Config.FoodHotKey) && Config.ToggleFoodHotKey == true && !MainPatch.EditNameCheck)
            {
                if (Player.main.GetComponent<Survival>().food <= Config.FoodPercentage)
                {
                    if (cookedBladderFish != null)
                    {
                        pInventory.UseItem(cookedBladderFish.First());
                    }
                    else if (cookedBoomerang != null)
                    {
                        pInventory.UseItem(cookedBoomerang.First());
                    }
                    else if (cookedEyeeye != null)
                    {
                        pInventory.UseItem(cookedEyeeye.First());
                    }
                    else if (cookedGarryFish != null)
                    {
                        pInventory.UseItem(cookedGarryFish.First());
                    }
                    else if (cookedHoleFish != null)
                    {
                        pInventory.UseItem(cookedHoleFish.First());
                    }
                    else if (cookedHoopFish != null)
                    {
                        pInventory.UseItem(cookedHoopFish.First());
                    }
                    else if (cookedHoverFish != null)
                    {
                        pInventory.UseItem(cookedHoverFish.First());
                    }
                    else if (cookedLavaBoomerang != null)
                    {
                        pInventory.UseItem(cookedLavaBoomerang.First());
                    }
                    else if (cookedLavaEyeeye != null)
                    {
                        pInventory.UseItem(cookedLavaEyeeye.First());
                    }
                    else if (cookedOculus != null)
                    {
                        pInventory.UseItem(cookedOculus.First());
                    }
                    else if (cookedPeeper != null)
                    {
                        pInventory.UseItem(cookedPeeper.First());
                    }
                    else if (cookedReginald != null)
                    {
                        pInventory.UseItem(cookedReginald.First());
                    }
                    else if (cookedSpadeFish != null)
                    {
                        pInventory.UseItem(cookedSpadeFish.First());
                    }
                    else if (cookedSpineFish != null)
                    {
                        pInventory.UseItem(cookedSpineFish.First());
                    }
                    else if (curedBladderFish != null)
                    {
                        pInventory.UseItem(curedBladderFish.First());
                    }
                    else if (curedBoomerang != null)
                    {
                        pInventory.UseItem(curedBoomerang.First());
                    }
                    else if (curedEyeeye != null)
                    {
                        pInventory.UseItem(curedEyeeye.First());
                    }
                    else if (curedGarryFish != null)
                    {
                        pInventory.UseItem(curedGarryFish.First());
                    }
                    else if (curedHoleFish != null)
                    {
                        pInventory.UseItem(curedHoleFish.First());
                    }
                    else if (curedHoopFish != null)
                    {
                        pInventory.UseItem(curedHoopFish.First());
                    }
                    else if (curedHoverFish != null)
                    {
                        pInventory.UseItem(curedHoverFish.First());
                    }
                    else if (curedLavaBoomerang != null)
                    {
                        pInventory.UseItem(curedLavaBoomerang.First());
                    }
                    else if (curedLavaEyeeye != null)
                    {
                        pInventory.UseItem(curedLavaEyeeye.First());
                    }
                    else if (curedOculus != null)
                    {
                        pInventory.UseItem(curedOculus.First());
                    }
                    else if (curedPeeper != null)
                    {
                        pInventory.UseItem(curedPeeper.First());
                    }
                    else if (curedReginald != null)
                    {
                        pInventory.UseItem(curedReginald.First());
                    }
                    else if (curedSpadeFish != null)
                    {
                        pInventory.UseItem(curedSpadeFish.First());
                    }
                    else if (curedSpineFish != null)
                    {
                        pInventory.UseItem(curedSpineFish.First());
                    }
                    else if (bulboTreeFruit != null)
                    {
                        pInventory.UseItem(bulboTreeFruit.First());
                    }
                    else if (chinaPotato != null)
                    {
                        pInventory.UseItem(chinaPotato.First());
                    }
                    else if (laternFruit != null)
                    {
                        pInventory.UseItem(laternFruit.First());
                    }
                    else if (marbleMelon != null)
                    {
                        pInventory.UseItem(marbleMelon.First());
                    }
                    else if (nutBlock != null)
                    {
                        pInventory.UseItem(nutBlock.First());
                    }
                    else if (snacks1 != null)
                    {
                        pInventory.UseItem(snacks1.First());
                    }
                    else if (snacks2 != null)
                    {
                        pInventory.UseItem(snacks2.First());
                    }
                    else if (snacks3 != null)
                    {
                        pInventory.UseItem(snacks3.First());
                    }
                    else
                    {
                        if (Config.TextValue == 0)
                        {
                            ErrorMessage.AddWarning("You Do Not Have Any Eatable Items In your Inventory");
                        }
                        else if (Config.TextValue == 1)
                        {
                            Subtitles.main.Add("You Do Not Have Any Eatable Items In your Inventory");
                        }
                    }
                }
                else
                {
                    if (Config.TextValue == 0)
                    {
                        ErrorMessage.AddWarning("You Do Not Need Too Eat, You're Not Hungry");
                    }
                    else if (Config.TextValue == 1)
                    {
                        Subtitles.main.Add("You Do Not Need Too Eat, You're Not Hungry");
                    }
                }
            }
        }
    }
}
