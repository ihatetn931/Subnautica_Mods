using HarmonyLib;
using QModManager.API.ModLoading;
using System;
using UnityEngine;

namespace BelowZeroAltMeter
{
    class AltMeter
    {
        [HarmonyPatch(typeof(uGUI_DepthCompass), nameof(uGUI_DepthCompass.UpdateDepth))]
        internal class uGUI_DepthCompass_UpdateDepth_Patch
        {
            [QModPrePatch]
            public static bool Prefix(uGUI_DepthCompass __instance)
            {
                if (Player.main != null)
                {
                    int altitude = (int)Player.main.transform.position.y;
                    var depth = Mathf.FloorToInt(Player.main.GetDepth());
                    var mainAlt = Math.Sign(altitude);
                    if (mainAlt >= 1 && depth == 0)
                    {
                        if (MainPatch.ToggleAltTextColor)
                        {
                            __instance.submersibleDepthSuffix.color = new Color(MainPatch.AltColorRed, MainPatch.AltColorGreen, MainPatch.AltColorBlue, 1);
                            __instance.suffixText.color = new Color(MainPatch.AltColorRed, MainPatch.AltColorGreen, MainPatch.AltColorBlue, 1);
                            __instance.depthText.color = new Color(MainPatch.AltColorRed, MainPatch.AltColorGreen, MainPatch.AltColorBlue, 1);
                        }
                        else
                        {
                            __instance.submersibleDepthSuffix.color = new Color(255, 255, 255, 1);
                            __instance.suffixText.color = new Color(255, 255, 255, 1);
                            __instance.depthText.color = new Color(255, 255, 255, 1);
                        }
                        if (MainPatch.ToggleSymbol)
                        {
                            __instance.submersibleDepthSuffix.text = "m ^";
                            __instance.submersibleDepth.text = altitude.ToString();
                            __instance.suffixText.text = "m ^";
                            __instance.depthText.text = altitude.ToString();
                        }
                        else
                        {
                            __instance.submersibleDepthSuffix.text = "m";
                            __instance.submersibleDepth.text = altitude.ToString();
                            __instance.suffixText.text = "m";
                            __instance.depthText.text = altitude.ToString();
                        }
                    }
                    else
                    {
                        __instance.submersibleDepthSuffix.text = "m";
                        if (MainPatch.ToggleDepthTextColor)
                        {
                            __instance.submersibleDepthSuffix.color = new Color(MainPatch.DepthTextColorRed, MainPatch.DepthTextColorGreen, MainPatch.DepthTextColorBlue, 1);
                            __instance.suffixText.color = new Color(MainPatch.DepthTextColorRed, MainPatch.DepthTextColorGreen, MainPatch.DepthTextColorBlue, 1);
                            __instance.depthText.color = new Color(MainPatch.DepthTextColorRed, MainPatch.DepthTextColorGreen, MainPatch.DepthTextColorBlue, 1);
                        }
                        else
                        {
                            __instance.submersibleDepthSuffix.color = new Color(255, 255, 255, 1);
                            __instance.suffixText.color = new Color(255, 255, 255, 1);
                            __instance.depthText.color = new Color(255, 255, 255, 1);
                        }
                    }
                }
                return true;
            }
        }
    }
}
