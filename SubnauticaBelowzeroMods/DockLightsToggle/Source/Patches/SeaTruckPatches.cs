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

            if (MainPatch.seaTruckIsDocked == true)
            {
                if (__instance.lightsActive == true)
                {
                    MainPatch.state.SeaTruckLightState = true;
                    Config.ToggleValue = true;
                    ConfigFile.AttemptToSave(MainPatch.state.SeaTruckLightState);
                    __instance.lightsActive = false;
                }
            }
            else
            {
                if (MainPatch.state.SeaTruckLightState == true)
                {

                    if (__instance.transform.Find("floodlight") != null)
                    {
                        var seaTruckLight = __instance.transform.Find("floodlight").GetComponentsInChildren<Light>(false);
                        MainPatch.state.SeaTruckLightState = false;
                        Config.ToggleValue = false;
                        ConfigFile.AttemptToSave(MainPatch.state.SeaTruckLightState);
                        if (seaTruckLight != null)
                        {
                            foreach (var allLights in seaTruckLight)
                            {
                                if (allLights.gameObject.name.Contains("left"))
                                {
                                    __instance.lightsActive = true;
                                }
                                else
                                {
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
