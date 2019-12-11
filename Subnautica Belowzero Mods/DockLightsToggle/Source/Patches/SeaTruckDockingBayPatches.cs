









/*using Harmony;
using UnityEngine;
namespace DockLightsToggle.Patches
{
    [HarmonyPatch(typeof(SeaTruckDockingBay))]
    [HarmonyPatch("Start")]
    public class SeaTruckDockingBay_Start_Patch
    {
        private static void Postfix(VehicleDockingBay __instance)
        {
            if (!(__instance.subRoot is BaseRoot))
                return;
            (__instance).CancelInvoke("Update");
            (__instance).InvokeRepeating("Update", 0.0f, 1f);
        }
    }
    [HarmonyPatch(typeof(SeaTruckDockingBay))]
    [HarmonyPatch("Update")]
    public class SeaTruckDockingBay_GetDockedObject_Patch
    {
        private static bool Prefix(SeaTruckDockingBay __instance)
        {
            if (__instance.gameObject.GetComponent<VehicleDockingBay>().GetDockedObject() != null)
            {
                if (__instance.GetComponent<VehicleDockingBay>().GetDockedObject().name.Contains("Exosuit"))
                {
                    MainPatch.exuSuitIsDockOnSeaTruck = true;
                }
            }
            else
            {
                MainPatch.exuSuitIsDockOnSeaTruck = false;
            }
            return false;
        }
    }
}*/
