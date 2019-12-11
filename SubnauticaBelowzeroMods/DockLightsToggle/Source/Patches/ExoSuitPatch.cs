
using System;
using System.Reflection;
using Harmony;
using UnityEngine;

namespace DockLightsToggle.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    [HarmonyPatch("Update")]
    class Exosuit_Update_Patch
    {
        private static bool Prefix(Exosuit __instance)
        {
            var exosuitLights = __instance.transform.Find("lights_parent").GetComponentsInChildren<Light>();
            foreach (var light in exosuitLights)
            {
                if (MainPatch.exoSuitIsDocked == true)
                {
                    if (light.gameObject.name.Contains("left"))
                    {
                        light.enabled = false;
                    }
                    else
                    {
                        light.enabled = false;
                    }
                }
                else
                {
                    if (light.gameObject.name.Contains("left"))
                    {
                        light.enabled = true;
                    }
                    else
                    {
                        light.enabled = true;
                    }
                }
                /*if(MainPatch.exuSuitIsDockOnSeaTruck == true)
                {
                    if (MainPatch.seaTruckDock.PrawnSuitSeaTruckDockToggle == true)
                    {
                        if (light.gameObject.name.Contains("left"))
                        {
                            light.enabled = false;
                        }
                        else
                        {
                            light.enabled = false;
                        }
                    }
                }*/
            }
            return true;
        }
    }
}
