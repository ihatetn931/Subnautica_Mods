using Harmony;
using UnityEngine;
namespace DockLightsToggleBZ.Patches
{
    [HarmonyPatch(typeof(VehicleDockingBay))]
    [HarmonyPatch("Start")]
    public class VehicleDockingBay_Start_Patch
    {
        private static void Postfix(VehicleDockingBay __instance)
        {
            if (!(__instance.subRoot is BaseRoot))
                return;
            (__instance).CancelInvoke("GetDockedObject");
            (__instance).InvokeRepeating("GetDockedObject", 0.0f, 1f);
        }
    }
    [HarmonyPatch(typeof(VehicleDockingBay))]
    [HarmonyPatch("GetDockedObject")]
    public class VehicleDockingBay_GetDockedObject_Patch
    {
        private static bool Prefix(VehicleDockingBay __instance)
        {
            if (__instance.GetDockedObject() != null)
            {
                if (__instance.GetDockedObject().name.Contains("SeaTruck"))
                {
                    MainPatch.seaTruckIsDocked = true;
                }
                else if (__instance.GetDockedObject().name.Contains("Exosuit"))
                {
                    MainPatch.exoSuitIsDocked = true;
                }
            }
            else
            {
                    MainPatch.seaTruckIsDocked = false;
                    MainPatch.exoSuitIsDocked = false;
            }
            return false;
        }
    }
}
