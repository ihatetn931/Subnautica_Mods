using Harmony;
using UnityEngine;

namespace BetterFlashLightBZ.Patches
{
    [HarmonyPatch(typeof(FlashLight))]
    [HarmonyPatch("onLightsToggled")]
    internal class FlashLight_onLightsToggled_Patch
    {
        public static bool Prefix(FlashLight __instance)
        {
            if (ConfigMenu.ToggleColor)
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
                                allLights.color = ConfigMenu.FlashLightColor.ToColor(true);
                                allLights.intensity = ConfigMenu.Intensity;
                                allLights.range = ConfigMenu.Range;
                            }
                            else
                            {
                                allLights.color = ConfigMenu.FlashLightColor.ToColor(true);
                                allLights.intensity = ConfigMenu.Intensity;
                                allLights.range = ConfigMenu.Range;
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                var flashLight = __instance.toggleLights.lightsParent.GetComponentsInChildren<Light>();
                if (flashLight != null)
                {
                    foreach (var allLights in flashLight)
                    {
                        if (allLights.gameObject.name.Contains("x_flashlightCone"))
                        {
                            allLights.color = ConfigMenu.FlashLightColor.ToColor(false);
                            allLights.intensity = 1.000f;
                            allLights.range = 50.000f;
                        }
                        else
                        {
                            allLights.color = ConfigMenu.FlashLightColor.ToColor(false);
                            allLights.intensity = 1.000f;
                            allLights.range = 50.000f;
                        }
                        break;
                    }
                }
            }
            return true;
        }
    }
}
