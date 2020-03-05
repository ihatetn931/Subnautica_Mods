using Harmony;
using SMLHelper.V2.Handlers;
using System;
using UnityEngine;

namespace BetterSeaglide.Patches
{
    
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]

    internal class SeaglideLightColorPatch
    {
        public static bool Prefix(Seaglide __instance)
        {
            var seaGlide = __instance.toggleLights.lightsParent.GetComponentsInChildren<Light>();
            if (MainPatch.othermods)
            {
                if (seaGlide != null)
                {
                    foreach (var allLights in seaGlide)
                    {
                        if (allLights.gameObject.name.Contains("light_"))
                        {
                            /*Debug.Log($"" +
                                $"Color is {allLights.color}\n" +
                                $"intensity is {allLights.intensity}\n" +
                                $"range is {allLights.range}\n" +
                                $"spotangle is {allLights.spotAngle}\n");*/

                            allLights.spotAngle = Menus.ConfigWhiteLights.spotAngle;
                            allLights.intensity = Menus.ConfigWhiteLights.Intensity;
                            allLights.range = Menus.ConfigWhiteLights.Range;

                        }
                        break;
                    }
                }
            }
            else
            {
                if (Menus.Config.ToggleColor)
                {
                    if (seaGlide != null)
                    {
                        foreach (var allLights in seaGlide)
                        {
                            if (allLights.gameObject.name.Contains("light_"))
                            {
                                /*Debug.Log($"" +
                                    $"Color is {allLights.color}\n" +
                                    $"intensity is {allLights.intensity}\n" +
                                    $"range is {allLights.range}\n" +
                                    $"spotangle is {allLights.spotAngle}\n");*/

                                    allLights.spotAngle = Menus.Config.spotAngle;
                                    allLights.color = Menus.Config.FlashLightColor.ToColor(true);
                                    allLights.intensity = Menus.Config.Intensity;
                                    allLights.range = Menus.Config.Range;
                            }
                            else
                            {
                                allLights.color = Menus.Config.FlashLightColor.ToColor(false);
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
    }
}
