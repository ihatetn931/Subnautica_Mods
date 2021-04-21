using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace WaterHealthFoodHotkeyBZ.Patches
{
    class Patch_uGUI_InputGroup
    {
        public static void Patch_uGUI_InputGroup_OnSelect()
        {
            MainPatch.EditNameCheck = true;
#if DEBUG
            QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Patch_uGUI_InputGroup_OnSelect is {MainPatch.EditNameCheck}", null, true);
#endif
        }

        public static void Patch_uGUI_InputGroup_OnDeselect()
        {
            MainPatch.EditNameCheck = false;
#if DEBUG
            QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Patch_uGUI_InputGroup_OnDeselect is {MainPatch.EditNameCheck}", null, true);
#endif
        }

        public static void Patch_uGUI_InputGroup_Deselect()
        {
            MainPatch.EditNameCheck = false;
#if DEBUG
            QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"Patch_uGUI_InputGroup_Deselect is {MainPatch.EditNameCheck}", null, true);
#endif
        }
    }
}
