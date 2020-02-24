using Harmony;
using UnityEngine;

namespace SubnauticaAltMeter
{
    class AltMeter
    {
        [HarmonyPatch(typeof(uGUI_DepthCompass))]
        [HarmonyPatch("UpdateDepth")]

        internal class uGUI_DepthCompass_UpdateDepth_Patch
        {
            [HarmonyPrefix]
            public static bool Prefix(uGUI_DepthCompass __instance)
            {

                if (Player.main != null)
                {
                    int altitude = (int)Player.main.transform.position.y;
                    var depth = Mathf.FloorToInt(Player.main.GetDepth());
                    if (altitude != 0 && depth == 0)
                    {
                        __instance.depthText.text = altitude.ToString();
                        __instance.suffixText.text = "m↑";
                    }
                }
                return true;
            }
        }
    }
}


