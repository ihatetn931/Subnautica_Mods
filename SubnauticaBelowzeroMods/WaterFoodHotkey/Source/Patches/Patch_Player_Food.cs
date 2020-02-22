using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkeyBZ.Patches
{
    class PlayerFood_Patch
    {
        public static void Patch_Player_Food()
        {
            /*bool consoleOpened = (bool)typeof(DevConsole).GetField("state", BindingFlags.NonPublic |
            BindingFlags.Instance).GetValue(typeof(DevConsole).GetField("instance", BindingFlags.NonPublic |
            BindingFlags.Static).GetValue(null));*/

            Inventory pInventory = Inventory.main;
            //CookedFood
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
            IList<InventoryItem> cookedPeeper = pInventory.container.GetItems(TechType.CookedArcticPeeper);
            IList<InventoryItem> cookedReginald = pInventory.container.GetItems(TechType.CookedReginald);
            IList<InventoryItem> cookedSpadeFish = pInventory.container.GetItems(TechType.CookedSpadefish);
            IList<InventoryItem> cookedSpineFish = pInventory.container.GetItems(TechType.CookedSpinefish);
            IList<InventoryItem> cookedArrowRay = pInventory.container.GetItems(TechType.CookedArrowRay);
            IList<InventoryItem> cookedFeatherFish = pInventory.container.GetItems(TechType.CookedFeatherFish);
            IList<InventoryItem> cookedFeatherFishRed = pInventory.container.GetItems(TechType.CookedFeatherFishRed);
            IList<InventoryItem> cookedNootFish = pInventory.container.GetItems(TechType.CookedNootFish);
            IList<InventoryItem> cookedSpinnerFish = pInventory.container.GetItems(TechType.CookedSpinnerfish);
            IList<InventoryItem> cookedSymbiote = pInventory.container.GetItems(TechType.CookedSymbiote);
            IList<InventoryItem> cookedTriops = pInventory.container.GetItems(TechType.CookedTriops);
            //Cured Food
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
            IList<InventoryItem> curedarcticPeeper = pInventory.container.GetItems(TechType.CuredArcticPeeper);
            IList<InventoryItem> curedReginald = pInventory.container.GetItems(TechType.CuredReginald);
            IList<InventoryItem> curedSpadeFish = pInventory.container.GetItems(TechType.CuredSpadefish);
            IList<InventoryItem> curedSpineFish = pInventory.container.GetItems(TechType.CuredSpinefish);
            IList<InventoryItem> curedArrowRay = pInventory.container.GetItems(TechType.CuredArrowRay);
            IList<InventoryItem> curedFeatherFish = pInventory.container.GetItems(TechType.CuredFeatherFish);
            IList<InventoryItem> curedFeatherFishRed = pInventory.container.GetItems(TechType.CuredFeatherFishRed);
            IList<InventoryItem> curedNootFish = pInventory.container.GetItems(TechType.CuredNootFish);
            IList<InventoryItem> curedSpinnerFish = pInventory.container.GetItems(TechType.CuredSpinnerfish);
            IList<InventoryItem> curedSymbiote = pInventory.container.GetItems(TechType.CuredSymbiote);
            IList<InventoryItem> curedTriops = pInventory.container.GetItems(TechType.CuredTriops);

            //Vegies and fruits
            IList<InventoryItem> bulboTreeFruit = pInventory.container.GetItems(TechType.BulboTreePiece);
            IList<InventoryItem> chinaPotato = pInventory.container.GetItems(TechType.PurpleVegetable);
            IList<InventoryItem> laternFruit = pInventory.container.GetItems(TechType.HangingFruit);
            IList<InventoryItem> marbleMelon = pInventory.container.GetItems(TechType.Melon);
            //Snacks and Nutrient Block
            IList<InventoryItem> nutBlock = pInventory.container.GetItems(TechType.NutrientBlock);
            IList<InventoryItem> snacks1 = pInventory.container.GetItems(TechType.Snack1);
            IList<InventoryItem> snacks2 = pInventory.container.GetItems(TechType.Snack2);
            IList<InventoryItem> snacks3 = pInventory.container.GetItems(TechType.Snack3);
            if (Input.GetKeyDown(Config.FoodHotKey) && Config.ToggleFoodHotKey == false && !MainPatch.EditNameCheck)
            {
                if (Config.TextValue == 0)
                {
                    ErrorMessage.AddWarning("You have Disabled The Food Hotkey");
                }
                else if (Config.TextValue == 1)
                {
                    Subtitles.Add("You Have Disabled The Food Hotkey");
                }
            }
            else if (Input.GetKeyDown(Config.FoodHotKey) && Config.ToggleFoodHotKey == true && !MainPatch.EditNameCheck)
            {
                if (Player.main.GetComponent<Survival>().food <= Config.FoodPercentage)
                {
                    //Cooked
                    if (cookedBladderFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedBladderFish.First());
                    }
                    else if (cookedBoomerang != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedBoomerang.First());
                    }
                    else if (cookedEyeeye != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedEyeeye.First());
                    }
                    else if (cookedGarryFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedGarryFish.First());
                    }
                    else if (cookedHoleFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedHoleFish.First());
                    }
                    else if (cookedHoopFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedHoopFish.First());
                    }
                    else if (cookedHoverFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedHoverFish.First());
                    }
                    else if (cookedLavaBoomerang != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedLavaBoomerang.First());
                    }
                    else if (cookedLavaEyeeye != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedLavaEyeeye.First());
                    }
                    else if (cookedOculus != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedOculus.First());
                    }
                    else if (cookedPeeper != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedPeeper.First());
                    }
                    else if (cookedReginald != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedReginald.First());
                    }
                    else if (cookedSpadeFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedSpadeFish.First());
                    }
                    else if (cookedSpineFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedSpineFish.First());
                    }
                    else if (cookedArrowRay != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedArrowRay.First());
                    }
                    else if (cookedFeatherFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedFeatherFish.First());
                    }
                    else if (cookedFeatherFishRed != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedFeatherFishRed.First());
                    }
                    else if (cookedNootFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedNootFish.First());
                    }
                    else if (cookedFeatherFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedFeatherFish.First());
                    }
                    else if (cookedSpinnerFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedSpinnerFish.First());
                    }
                    else if (cookedSymbiote != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedSymbiote.First());
                    }
                    else if (cookedTriops != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedTriops.First());
                    }
                    //Cured
                    else if (curedBladderFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedBladderFish.First());
                    }
                    else if (curedBoomerang != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedBoomerang.First());
                    }
                    else if (curedEyeeye != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedEyeeye.First());
                    }
                    else if (curedGarryFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedGarryFish.First());
                    }
                    else if (curedHoleFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedHoleFish.First());
                    }
                    else if (curedHoopFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedHoopFish.First());
                    }
                    else if (curedHoverFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedHoverFish.First());
                    }
                    else if (curedLavaBoomerang != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedLavaBoomerang.First());
                    }
                    else if (curedLavaEyeeye != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedLavaEyeeye.First());
                    }
                    else if (curedOculus != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedOculus.First());
                    }
                    else if (curedPeeper != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedPeeper.First());
                    }
                    else if (curedReginald != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedReginald.First());
                    }
                    else if (curedSpadeFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedSpadeFish.First());
                    }
                    else if (curedSpineFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedSpineFish.First());
                    }
                    else if (cookedArrowRay != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedArrowRay.First());
                    }
                    else if (cookedFeatherFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedFeatherFish.First());
                    }
                    else if (cookedFeatherFishRed != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedFeatherFishRed.First());
                    }
                    else if (cookedNootFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, cookedNootFish.First());
                    }
                    else if (curedFeatherFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedFeatherFish.First());
                    }
                    else if (curedSpinnerFish != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedSpinnerFish.First());
                    }
                    else if (curedSymbiote != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedSymbiote.First());
                    }
                    else if (curedTriops != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedTriops.First());
                    }
                    else if (curedarcticPeeper != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, curedarcticPeeper.First());
                    }
                    //Vegies and Fruit
                    else if (bulboTreeFruit != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, bulboTreeFruit.First());
                    }
                    else if (chinaPotato != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, chinaPotato.First());
                    }
                    else if (laternFruit != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, laternFruit.First());
                    }
                    else if (marbleMelon != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, marbleMelon.First());
                    }
                    else if (nutBlock != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, nutBlock.First());
                    }
                    else if (snacks1 != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, snacks1.First());
                    }
                    else if (snacks2 != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, snacks2.First());
                    }
                    else if (snacks3 != null)
                    {
                        pInventory.ExecuteItemAction(ItemAction.Eat, snacks3.First());
                    }
                    else
                    {
                        if (Config.TextValue == 0)
                        {
                            ErrorMessage.AddWarning("You Do Not Have Any Eatable Items In your Inventory");
                        }
                        else if (Config.TextValue == 1)
                        {
                            Subtitles.Add("You Do Not Have Any Eatable Items In your Inventory");
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
                        Subtitles.Add("You Do Not Need Too Eat, You're Not Hungry");
                    }
                }
            }
        }
    }
}
