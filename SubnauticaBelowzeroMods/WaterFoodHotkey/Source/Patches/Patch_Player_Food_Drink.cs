using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WaterFoodHotkeyBZ.Patches
{
    class PlayerFood_Patch
    {
        public static void Patch_Player_Food_Drink()
        {
            Inventory pInventory = Inventory.main;
            List<InventoryItem> foodDrink = new List<InventoryItem>();

            if (pInventory.container.itemsMap != null)
            {
                foreach (var test in pInventory.container.itemsMap)
                {
                    var itemAction = pInventory.GetAllItemActions(test);
                    if (test != null)
                    {
                        if (itemAction == ItemAction.Eat)
                        {
                            if (!test.item.GetComponent<Thermos>())
                            {
                                foodDrink.Add(test);
                            }
                        }

                    }
                }
            }
            if (!MainPatch.EditNameCheck)
            {
                if (Input.GetKeyDown(MainPatch.FoodDrinkHotKey))
                {
                    if (MainPatch.ToggleFoodDrink)
                    {
                        if (Player.main.GetComponent<Survival>().food <= MainPatch.FoodDrinkPercentage || Player.main.GetComponent<Survival>().water <= MainPatch.FoodDrinkPercentage)
                        {
                            if (foodDrink.Count > 0)
                            {
                                pInventory.ExecuteItemAction(ItemAction.Eat, foodDrink.First());
                            }
                            else
                            {
                                if (MainPatch.TextValue == "Standard")
                                {
                                    ErrorMessage.AddWarning("You Do Not Have Any Eatable/Drinkable Items In your Inventory");
                                }
                                else if (MainPatch.TextValue == "Subtitles")
                                {
                                    Subtitles.Add("You Do Not Have Any Eatable/Drinkable Items In your Inventory");
                                }
                            }
                        }
                        else
                        {
                            if (MainPatch.TextValue == "Standard")
                            {
                                ErrorMessage.AddWarning($"You Do Not Need To Eat Or Drink, Your Food And Drink is Already Above {MainPatch.FoodDrinkPercentage}");
                            }
                            else if (MainPatch.TextValue == "Subtitles")
                            {
                                Subtitles.Add($"You Do Not Need To Eat Or Drink, Your Food And Drink is Already Above {MainPatch.FoodDrinkPercentage}");
                            }
                        }
                    }
                    else
                    {
                        if (MainPatch.TextValue == "Standard")
                        {
                            ErrorMessage.AddWarning("You have Disabled The Food/Drink Hotkey");
                        }
                        else if (MainPatch.TextValue == "Subtitles")
                        {
                            Subtitles.Add("You Have Disabled The Food/Drink Hotkey");
                        }
                    }
                }
            }
        }
    }
}



