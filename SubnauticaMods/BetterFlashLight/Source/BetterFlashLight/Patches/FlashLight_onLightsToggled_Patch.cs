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
            if (Config.ToggleColor)
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
                                allLights.color = Config.FlashLightColor.ToColor(true);
                                allLights.intensity = Config.Intensity;
                                allLights.range = Config.Range;
                            }
                            else
                            {
                                allLights.color = Config.FlashLightColor.ToColor(true);
                                allLights.intensity = Config.Intensity;
                                allLights.range = Config.Range;
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
                            allLights.color = Config.FlashLightColor.ToColor(false);
                            allLights.intensity = 1.000f;
                            allLights.range = 50.000f;
                        }
                        else
                        {
                            allLights.color = Config.FlashLightColor.ToColor(false);
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
