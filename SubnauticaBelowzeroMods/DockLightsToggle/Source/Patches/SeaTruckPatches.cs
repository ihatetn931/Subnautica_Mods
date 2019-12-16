using Harmony;
using System;
using UnityEngine;
using SMLHelper.V2.Handlers;

namespace DockLightsToggleBZ.Patches
{
    [Serializable]
    [HarmonyPatch(typeof(SeaTruckLights))]
    [HarmonyPatch("Update")]
    public class SeaTruckLights_Update_Patch
    {
        private static bool Prefix(SeaTruckLights __instance)
        {
            //Debug.Log($"[DockingLightsToggle] 1 {MainPatch.seaTruckIsDocked}");
            if (MainPatch.seaTruckIsDocked == true)
            {
                //Debug.Log("[DockingLightsToggle] 2");
                if (__instance.lightsActive == true)
                {
                    //Debug.Log($"[DockingLightsToggle] 3 {MainPatch.state.SeaTruckLightState}");
                    MainPatch.state.SeaTruckLightState = true;
                    Config.ToggleValue = true;
                    //Debug.Log($"[DockingLightsToggle] 4");
                    ConfigFile.AttemptToSave(MainPatch.state.SeaTruckLightState);
                    //Debug.Log("[DockingLightsToggle] 5");
                    __instance.lightsActive = false;
                    //Debug.Log("[DockingLightsToggle] 6");

                }
            }
            else
            {
                if (MainPatch.state.SeaTruckLightState == true)
                {
                    //Debug.Log("[DockingLightsToggle] 7");
                    if (__instance.transform.Find("floodlight") != null)
                    {
                        //Debug.Log("[DockingLightsToggle] 8");
                        var seaTruckLight = __instance.transform.Find("floodlight").GetComponentsInChildren<Light>(false);
                        //Debug.Log("[DockingLightsToggle] 9");
                        MainPatch.state.SeaTruckLightState = false;
                        Config.ToggleValue = false;
                        //Debug.Log("[DockingLightsToggle] 10");
                        ConfigFile.AttemptToSave(MainPatch.state.SeaTruckLightState);
                        //Debug.Log("[DockingLightsToggle] 11");

                        if (seaTruckLight != null)
                        {
                            //Debug.Log("[DockingLightsToggle] 12");
                            foreach (var allLights in seaTruckLight)
                            {
                                //Debug.Log("[DockingLightsToggle] 13");
                                if (allLights.gameObject.name.Contains("left"))
                                {
                                    //Debug.Log("[DockingLightsToggle] 14");
                                    __instance.lightsActive = true;
                                }
                                else
                                {
                                    //Debug.Log("[DockingLightsToggle] 15");
                                    __instance.lightsActive = true;
                                }

                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
