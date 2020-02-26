/*using Harmony;
using UnityEngine;

namespace BetterSeaglide.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]

    internal class Seaglide_Speed_Patch
    {
        public static bool Prefix(Seaglide __instance)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                __instance.powerGlideActive = true;
            }
            else
            {
                __instance.powerGlideActive = false;
            }
            return true;
        }
    }
}*/
