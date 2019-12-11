using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkey.Patches
{
    class Patch_uGUI_InputGroup
    {
        public static void Patch_uGUI_InputGroup_OnSelect()
        {
            MainPatch.EditNameCheck = true;
#if DEBUG
            Debug.Log($"[WaterDrinkHotkey] :: Patch_uGUI_InputGroup_OnSelect is {MainPatch.EditNameCheck}");
#endif
        }

        public static void Patch_uGUI_InputGroup_OnDeselect()
        {
            MainPatch.EditNameCheck = false;
#if DEBUG
            Debug.Log($"[WaterDrinkHotkey] :: Patch_uGUI_InputGroup_OnDeselect is {MainPatch.EditNameCheck}");
#endif
        }

        public static void Patch_uGUI_InputGroup_Deselect()
        {
            MainPatch.EditNameCheck = false;
#if DEBUG
            Debug.Log($"[WaterDrinkHotkey] :: Patch_uGUI_InputGroup_Deselect is {MainPatch.EditNameCheck}");
#endif
        }
    }
}
