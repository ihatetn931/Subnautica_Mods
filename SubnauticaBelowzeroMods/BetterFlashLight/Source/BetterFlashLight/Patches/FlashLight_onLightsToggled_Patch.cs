
using HarmonyLib;
using UnityEngine;

namespace BetterFlashLightBZ.Patches
{
    [HarmonyPatch(typeof(FlashLight))]
    [HarmonyPatch("onLightsToggled")]
    internal class FlashLight_onLightsToggled_Patch
    {
        public static bool Prefix(FlashLight __instance)
        {
            if (__instance.toggleLights.lightsParent != null)
            {
                var flashLight = __instance.toggleLights.lightsParent.GetComponentsInChildren<Light>();
                if (flashLight != null)
                {
                    foreach (var allLights in flashLight)
                    {
                        if (allLights.gameObject.name.Contains("x_flashlightCone"))
                        {
                            if (MainPatch.ToggleColor && MainPatch.ToggleOptions)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(true);
                                allLights.intensity = MainPatch.Intensity;
                                allLights.range = MainPatch.Range;
                            }
                            if (MainPatch.ToggleColor && MainPatch.ToggleOptions == false)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(true);
                                allLights.intensity = 1.000f;
                                allLights.range = 50.000f;
                            }
                            if (MainPatch.ToggleOptions && MainPatch.ToggleColor == false)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(false);
                                allLights.intensity = MainPatch.Intensity;
                                allLights.range = MainPatch.Range;
                            }
                            if (MainPatch.ToggleOptions == false && MainPatch.ToggleColor == false)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(false);
                                allLights.intensity = 1.000f;
                                allLights.range = 50.000f;
                            }
                        }
                        else
                        {
                            if (MainPatch.ToggleColor && MainPatch.ToggleOptions)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(true);
                                allLights.intensity = MainPatch.Intensity;
                                allLights.range = MainPatch.Range;
                            }
                            if (MainPatch.ToggleColor && MainPatch.ToggleOptions == false)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(true);
                                allLights.intensity = 1.000f;
                                allLights.range = 50.000f;
                            }
                            if (MainPatch.ToggleOptions && MainPatch.ToggleColor == false)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(false);
                                allLights.intensity = MainPatch.Intensity;
                                allLights.range = MainPatch.Range;
                            }
                            if (MainPatch.ToggleOptions == false && MainPatch.ToggleColor == false)
                            {
                                allLights.color = MainPatch.FlashLightColor.ToColor(false);
                                allLights.intensity = 1.000f;
                                allLights.range = 50.000f;
                            }
                        }
                        break;
                    }
                }

            }
/*            else
            {
                var flashLight = __instance.toggleLights.lightsParent.GetComponentsInChildren<Light>();
                if (flashLight != null)
                {
                    foreach (var allLights in flashLight)
                    {
                        if (allLights.gameObject.name.Contains("x_flashlightCone"))
                        {
                            allLights.color = FlashLightConfig.FlashLightColor.ToColor(false);
                            allLights.intensity = 1.000f;
                            allLights.range = 50.000f;
                        }
                        else
                        {
                            allLights.color = FlashLightConfig.FlashLightColor.ToColor(false);
                            allLights.intensity = 1.000f;
                            allLights.range = 50.000f;
                        }
                        break;
                    }
                }
            }*/
            return true;
        }
    }
}
