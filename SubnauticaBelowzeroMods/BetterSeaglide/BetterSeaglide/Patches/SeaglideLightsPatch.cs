using HarmonyLib;
using System;
using UnityEngine;
using Logger = QModManager.Utility.Logger;

namespace BetterSeaglideBZ.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]

    internal class Seaglide_Update_Patch
    {
        public static bool Prefix(Seaglide __instance)
        {
            var seaGlide = __instance.toggleLights.GetComponentsInChildren<Light>();
            var sgColor = __instance.GetAllComponentsInChildren<SkinnedMeshRenderer>();
            var pickupablesgColor = __instance.GetAllComponentsInChildren<MeshRenderer>();
            if (__instance.toggleLights.lightsParent != null)
            {
                if (seaGlide != null)
                {
                    foreach (var allLights in seaGlide)
                    {
                        if (allLights.gameObject.name.Contains("Light"))
                        {
                            /*Debug.Log($"" +
                                $"Color is {allLights.color}\n" +
                                $"intensity is {allLights.intensity}\n" +
                                $"range is {allLights.range}\n" +
                                $"spotangle is {allLights.spotAngle}\n");*/
                            if (SeaglideConfig.ToggleColor)
                            {
                                allLights.color = SeaglideConfig.FlashLightColor.LightToColor(true);
                            }
                            else
                            {
                                allLights.color = SeaglideConfig.FlashLightColor.LightToColor(false);
                            }
                            if (SeaglideConfig.SeaglideLightOptions)
                            {
                                allLights.spotAngle = SeaglideConfig.spotAngle;
                                allLights.intensity = SeaglideConfig.Intensity;
                                allLights.range = SeaglideConfig.Range;
                            }
                            else
                            {
                                //Logger.Log(Logger.Level.Error, $"[LightColor] Consize:{allLights.spotAngle}");
                                //Logger.Log(Logger.Level.Error, $"[LightColor] Brighness:{allLights.intensity}");
                                //Logger.Log(Logger.Level.Error, $"[LightColor] Range:{allLights.range}");
                                allLights.spotAngle = 70;
                                allLights.intensity = 0.9f;
                                allLights.range = 40;
                            }
                        }
                        break;
                    }
                }
            }
            foreach (var seaglideColor in sgColor)
            {
                if (seaglideColor.name.Contains("SeaGlide_geo"))
                {
                    if(SeaglideConfig.SeaglideColor)
                    {
                        seaglideColor.material.color = SeaglideConfig.SeaglideModelColor.ColorToColor(true);
                    }
                    else
                    {
                        seaglideColor.material.color = SeaglideConfig.SeaglideModelColor.ColorToColor(false);
                    }
                   // Logger.Log(Logger.Level.Info, $"[LightColor] Color:{seaglideColor.material.color}  ");
                   // seaglideColor.material.color = new Color(SeaglideConfig.seagliderValue, SeaglideConfig.seaglidegValue, SeaglideConfig.seaglidebValue, 1);
                }
            }
            foreach (var droppedseaglideColor in pickupablesgColor)
            {
                if (droppedseaglideColor.name.Contains("SeaGlide_01_TP"))
                {
                    if (SeaglideConfig.SeaglideColor)
                    {
                        droppedseaglideColor.material.color = SeaglideConfig.SeaglideModelColor.ColorToColor(true);
                    }
                    else
                    {
                        droppedseaglideColor.material.color = SeaglideConfig.SeaglideModelColor.ColorToColor(false);
                    }
                    //Logger.Log(Logger.Level.Info, $"[LightColor] DroppedColor:{droppedseaglideColor.material.color}  ");
                    //droppedseaglideColor.material.color = new Color(SeaglideConfig.seagliderValue, SeaglideConfig.seaglidegValue, SeaglideConfig.seaglidebValue, 1);
                }
            }
            return true;
        }
    }
}
