using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaterFoodHotkey.Patches
{
    class Gui_Patch
    {
        public static void Patch_uGUI_InputGroup_OnSelect()
        {
            MainPatch.EditNameCheck = true;
            //Debug.Log($"[WaterDrinkHotkey] :: Patch_uGUI_InputGroup_OnSelect is {EditNameCheck}");
        }

        public static void Patch_uGUI_InputGroup_OnDeselect()
        {
            MainPatch.EditNameCheck = false;
            //Debug.Log($"[WaterDrinkHotkey] :: Patch_uGUI_InputGroup_OnDeselect is {EditNameCheck}");
        }

        public static void Patch_uGUI_InputGroup_Deselect()
        {
            MainPatch.EditNameCheck = false;
            //Debug.Log($"[WaterDrinkHotkey] :: Patch_uGUI_InputGroup_Deselect is {EditNameCheck}");
        }
    }
}
