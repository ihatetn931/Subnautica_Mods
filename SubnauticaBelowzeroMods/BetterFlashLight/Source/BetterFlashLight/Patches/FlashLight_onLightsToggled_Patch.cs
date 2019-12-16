using Harmony;
using UnityEngine;

namespace BetterFlashLight.Patches
{
    [HarmonyPatch(typeof(FlashLight))]
    [HarmonyPatch("onLightsToggled")]
    internal class FlashLight_onLightsToggled_Patch
    {
        public static bool Prefix(FlashLight __instance)
        {
            if (BetterFlashLightBZ.Config.ToggleColor)
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
                                allLights.color = BetterFlashLightBZ.Config.FlashLightColor.ToColor(true);
                                allLights.intensity = BetterFlashLightBZ.Config.Range;
                            }
                            else
                            {
                                allLights.color = BetterFlashLightBZ.Config.FlashLightColor.ToColor(true);
                                allLights.intensity = BetterFlashLightBZ.Config.Range;
                            }
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
                            allLights.color = BetterFlashLightBZ.Config.FlashLightColor.ToColor(false);
                            allLights.range = 50.000f;
                            allLights.intensity = 1.000f;
                        }
                        else
                        {
                            allLights.color = BetterFlashLightBZ.Config.FlashLightColor.ToColor(false);
                            allLights.range = 50.000f;
                            allLights.intensity = 1.000f;
                        }
                    }
                }
            }
            return true;
        }
    }
}
