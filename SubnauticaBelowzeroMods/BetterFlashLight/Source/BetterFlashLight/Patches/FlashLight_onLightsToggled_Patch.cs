
using HarmonyLib;
using UnityEngine;

namespace BetterFlashLightBZ.Patches
{
    [HarmonyPatch(typeof(ToggleLights), nameof(ToggleLights.Update))]
    internal class FlashLight_onLightsToggled_Patch
    {
        public static bool Prefix(ToggleLights __instance)
        {
            if (__instance.lightsParent != null)
            {
                var flashLight = __instance.lightsParent.GetComponentsInChildren<Light>();
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
            return true;
        }
    }
}
