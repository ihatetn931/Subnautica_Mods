/*using Harmony;
using UnityEngine;

namespace BetterSeaglideBZ.Patches
{
    class SeaglideSpeedPatch
    {
        [HarmonyPatch(typeof(PlayerController))]
        [HarmonyPatch("UpdateController")]

        internal class Seaglide_onLightsToggled_Patch
        {
            public static bool Prefix(PlayerController __instance)
            {
                __instance.seaglideForwardMaxSpeed += Config.seaglideSpeed;
                //__instance.seaglideSwimDrag = 2.5f;
                Debug.Log($"forwordmaxspeed is {__instance.seaglideForwardMaxSpeed}\n" +
                    $"instance backwardmaxspeed is  {__instance.seaglideBackwardMaxSpeed}\n" +
                    $"instance strafemaxspeed is {__instance.seaglideStrafeMaxSpeed}\n" +
                    $"instance swimdrag is  {__instance.seaglideSwimDrag}\n" +
                    $"instance z is  {__instance}\n"
                    /*$"{__instance.gameObject.transform.forward.}");
                return true;
            }
        }
    }
}*/
