using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterFoodHotkeyBZ.Patches
{
    class Patch_uGUI_InputGroup
    {
        public static void Patch_uGUI_InputGroup_OnSelect()
        {
            MainPatch.EditNameCheck = true;
        }

        public static void Patch_uGUI_InputGroup_OnDeselect()
        {
            MainPatch.EditNameCheck = false;
        }

        public static void Patch_uGUI_InputGroup_Deselect()
        {
            MainPatch.EditNameCheck = false;
        }
    }
}
