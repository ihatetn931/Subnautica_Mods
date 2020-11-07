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
            // if (!(__instance.subRoot is BaseRoot))
            // return true ;
            bool flag = __instance.subRoot is BaseRoot;
           // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"Flag: {flag}", null, true);
            bool flag2 = flag;
            if (flag2)
            {
               // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"Flag2: {flag2}",null, true);
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
               // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"__instance: {__instance}", null, true);
                Dockable docked = __instance.GetDockedObject();

                if (docked != null)
                {
                    //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"docked: {docked}", null, true);
                    if (docked.name.Contains("SeaTruck"))
                    {
                       // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, "Seatruck Docked", null, true);
                        MainPatch.seaTruckIsDocked = true;
                    }
                    else if (docked.name.Contains("Exosuit"))
                    {
                       // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, "Exosuit Docked", null, true);
                        MainPatch.exoSuitIsDocked = true;
                    }
                }
                else
                {
                   // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, "Nothing Docked", null, true);
                    MainPatch.seaTruckIsDocked = false;
                    MainPatch.exoSuitIsDocked = false;
                }
            }
            return false;
        }
    }
}
