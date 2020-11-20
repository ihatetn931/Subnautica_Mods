using HarmonyLib;
using QModManager.API.ModLoading;
using UnityEngine;

namespace BelowZeroAltMeter
{
    class AltMeter
    {
        [HarmonyPatch(typeof(uGUI_DepthCompass))]
        [HarmonyPatch("UpdateDepth")]

        internal class uGUI_DepthCompass_UpdateDepth_Patch
        {
            [QModPrePatch]
            public static bool Prefix(uGUI_DepthCompass __instance)
            {

                if (Player.main != null)
                {
                    int altitude = (int)Player.main.transform.position.y;
                    var depth = Mathf.FloorToInt(Player.main.GetDepth());
                    if (altitude != 0 && depth == 0)
                    {
                        /*Debug.Log($"" +
                            $"suffixText.text is {__instance.suffixText.text}");*/
                        __instance.suffixText.text = "m ^";
                        __instance.depthText.text = altitude.ToString();
                    }
                }
                return true;
            }
        }
    }
}


