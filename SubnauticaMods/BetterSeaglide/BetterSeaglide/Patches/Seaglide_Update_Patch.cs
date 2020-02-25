using Harmony;
using UnityEngine;

namespace BetterSeaglide.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]

    internal class Seaglide_Update_Patch
    {
        public static bool Prefix(Seaglide __instance)
        {
            var seaGlide = __instance.toggleLights.lightsParent.GetComponentsInChildren<Light>();
            if (Config.ToggleColor)
            {
                if (seaGlide != null)
                {
                    foreach (var allLights in seaGlide)
                    {
                        if (allLights.gameObject.name.Contains("light_left"))
                        {
                            /*Debug.Log($"" +
                                $"Color is {allLights.color}\n" +
                                $"intensity is {allLights.intensity}\n" +
                                $"range is {allLights.range}\n" +
                                $"spotangle is {allLights.spotAngle}\n");*/
                            allLights.spotAngle = Config.spotAngle;
                            allLights.color = Config.FlashLightColor.ToColor(true);
                            allLights.intensity = Config.Intensity;
                            allLights.range = Config.Range;
                        }
                        break;
                    }
                }
            }
            else
            {

                if (seaGlide != null)
                {
                    foreach (var allLights in seaGlide)
                    {
                        allLights.color = Config.FlashLightColor.ToColor(false);
                        allLights.spotAngle = Config.spotAngle;
                        allLights.intensity = Config.Intensity;
                        allLights.range = Config.Range;

                    }
                }
            }
            return true;
        }
    }
}
