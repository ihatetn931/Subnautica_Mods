using HarmonyLib;
using QModManager.API.ModLoading;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
namespace DockLightsToggleBZ.Patches
{

    [HarmonyPatch(typeof(VehicleDockingBay))]
    [HarmonyPatch("Start")]
    public class VehicleDockingBay_Start_Patch
    {
        [QModPrePatch]
        private static void Postfix(VehicleDockingBay __instance)
        {
            bool flag = __instance.subRoot is BaseRoot;
            bool flag2 = flag;
            if (flag2)
            {
                __instance.CancelInvoke("OnUndockingStart");
                __instance.InvokeRepeating("OnUndockingStart", 0.0f, 1f);
            }

        }
    }
    [HarmonyPatch(typeof(VehicleDockingBay))]
    [HarmonyPatch("OnUndockingStart")]
    public class VehicleDockingBay_OnUndockingStart_Patch
    {
        [QModPrePatch]
        private static bool Prefix(VehicleDockingBay __instance)
        {
            if (__instance != null)
            {
                Dockable docked = __instance.GetDockedObject();

                if (docked != null)
                {
                    if (docked.name.Contains("SeaTruck"))
                    {
                        MainPatch.seaTruckIsDocked = true;
                    }
                    else if (docked.name.Contains("Exosuit"))
                    {
                        MainPatch.exoSuitIsDocked = true;
                    }
                }
                else
                {
                    MainPatch.seaTruckIsDocked = false;
                    MainPatch.exoSuitIsDocked = false;
                }
            }
            return false;
        }
    }
}
