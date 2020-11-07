/*using Harmony;
using UnityEngine;
namespace DockLightsToggleBZ.Patches
{
    [HarmonyPatch(typeof(Hoverpad))]
    [HarmonyPatch("Update")]
    public class Hovepad_Start_Patch
    {
        private static void Postfix(Hoverpad __instance)
        {
            //Debug.Log($"MainPatch snowfoxDocked is {MainPatch.snowfoxIsDocked}");
            if (__instance.isBikeDocked)
            {
                MainPatch.snowfoxIsDocked = true;
            }
            else
            {
                MainPatch.snowfoxIsDocked = false;
            }
        }
     
    }

}*/
