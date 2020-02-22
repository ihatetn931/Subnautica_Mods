using Harmony;
using System;
using UnityEngine;
using SMLHelper.V2.Handlers;

namespace DockLightsToggleBZ.Patches
{
    [Serializable]
    [HarmonyPatch(typeof(Hoverbike))]
    [HarmonyPatch("Update")]
    public class Hoverbike_Update_Patch
    {
        private static bool Prefix(Hoverbike __instance)
        {

            if (MainPatch.snowfoxIsDocked == true)
            {
                if (__instance.toggleLights.enabled == true)
                {
                    MainPatch.state.HoveBikeLightState = true;
                    Config.ToggleValue = true;
                    ConfigFile.AttemptToSave(MainPatch.state.HoveBikeLightState);
                    __instance.toggleLights.enabled = false;
                }
            }
            else
            {
                if (MainPatch.state.HoveBikeLightState == true)
                {
                    //Debug.Log($"Hoverbike Lights link not working hoveBikeLight is {hoverbikeLight}");
                    if (__instance.transform.Find("Deployed").transform.Find("Lights") != false)
                    {
                        Debug.Log("It found the lights");
                        var hoverbikeLight = __instance.transform.Find("Deployed").transform.Find("Lights").GetComponentsInChildren<Light>(false);
                        Debug.Log("[Speedo] 1");
                        MainPatch.state.HoveBikeLightState = false;
                        Config.ToggleValue = false;
                        ConfigFile.AttemptToSave(MainPatch.state.HoveBikeLightState);
                        if (hoverbikeLight != null)
                        {
                            foreach (var light in hoverbikeLight)
                            {
                                if (light.gameObject.name.Contains("Light_Main") != false)
                                {
                                    if (light.gameObject.name.Contains("x_FakeVolumletricLight") != false)
                                    {
                                        Debug.Log("[Speedo] 2");
                                        __instance.toggleLights.enabled = true;
                                    }
                                    else
                                    {
                                        Debug.Log("[Speedo] 3 x_FakeVolumletricLight is false");
                                    }
                                }
                                else
                                {
                                    Debug.Log("[Speedo] 3 Light_Main is false");
                                    //__instance.toggleLights.enabled = true;
                                    //__instance.toggleLights.lightsActive = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Hoverbike Lights link not working");
                    }
                }
            }
            return true;
        }
    }
}
