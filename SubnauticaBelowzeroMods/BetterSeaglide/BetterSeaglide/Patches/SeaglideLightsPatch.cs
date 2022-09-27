using HarmonyLib;
using System;
using UnityEngine;
using Logger = QModManager.Utility.Logger;

namespace BetterSeaglideBZ.Patches
{
    [HarmonyPatch(typeof(ToggleLights), nameof(ToggleLights.Update))]
    internal class Seaglide_Update_Patch
    {
        public static bool Prefix(ToggleLights __instance)
        {
            if (__instance.lightsParent != null)
            {
                var sgLight = __instance.GetComponentsInChildren<Light>();
                var sgColor = __instance.GetAllComponentsInChildren<SkinnedMeshRenderer>();
                var pickupsgColor = __instance.GetAllComponentsInChildren<MeshRenderer>();
                if (sgLight != null)
                {
                    foreach (var allLights in sgLight)
                    {
                        //ErrorMessage.AddDebug("Name: " + allLights.gameObject.name);
                        if (allLights.gameObject.name.Contains("Light"))
                        {
                            /*ErrorMessage.AddDebug($"" +
                                $"Color is {allLights.color}\n" +
                                $"intensity is {allLights.intensity}\n" +
                                $"range is {allLights.range}\n" +
                                $"spotangle is {allLights.spotAngle}\n" +
                                $"ToggleColor is {MainPatch.ToggleColor}\n");*/
                            if (MainPatch.ToggleColor)
                            {
                                allLights.color = MainPatch.FlashLightColor.LightToColor(true);
                                //ErrorMessage.AddDebug("LightToColor: " + MainPatch.FlashLightColor.LightToColor(true));
                            }
                            else
                            {
                                allLights.color = MainPatch.FlashLightColor.LightToColor(false);
                            }
                            if (MainPatch.SeaglideLightOptions)
                            {
                                allLights.spotAngle = MainPatch.spotAngle;
                                allLights.intensity = MainPatch.Intensity;
                                allLights.range = MainPatch.Range;
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
                if (sgColor != null)
                {
                    foreach (var seaglideColor in sgColor)
                    {
                        if (seaglideColor.name.Contains("SeaGlide_geo"))
                        {
                            if (MainPatch.SeaglideColor)
                            {
                                seaglideColor.material.color = MainPatch.SeaglideModelColor.ColorToColor(true);
                            }
                            else
                            {
                                seaglideColor.material.color = MainPatch.SeaglideModelColor.ColorToColor(false);
                            }
                            // Logger.Log(Logger.Level.Info, $"[LightColor] Color:{seaglideColor.material.color}  ");
                            // seaglideColor.material.color = new Color(SeaglideConfig.seagliderValue, SeaglideConfig.seaglidegValue, SeaglideConfig.seaglidebValue, 1);
                        }
                    }
                }
                if(pickupsgColor != null)
                {
                    foreach (var droppedseaglideColor in pickupsgColor)
                    {
                        if (droppedseaglideColor.name.Contains("SeaGlide_01_TP"))
                        {
                            if (MainPatch.SeaglideColor)
                            {
                                droppedseaglideColor.material.color = MainPatch.SeaglideModelColor.ColorToColor(true);
                            }
                            else
                            {
                                droppedseaglideColor.material.color = MainPatch.SeaglideModelColor.ColorToColor(false);
                            }
                            //Logger.Log(Logger.Level.Info, $"[LightColor] DroppedColor:{droppedseaglideColor.material.color}  ");
                            //droppedseaglideColor.material.color = new Color(SeaglideConfig.seagliderValue, SeaglideConfig.seaglidegValue, SeaglideConfig.seaglidebValue, 1);
                        }
                    }
                }
            }
            return true;
        }
    }
}
