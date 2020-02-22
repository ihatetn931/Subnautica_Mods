using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace BetterSeaglideBZ.Patches
{
    [HarmonyPatch(typeof(VehicleInterface_Terrain))]
    [HarmonyPatch("Update")]

    internal class VehicleInterface_Terrain_Update_Patch
    {
        private static readonly FieldInfo VehicleInterface_MapController_materialInstance = typeof(VehicleInterface_Terrain).GetField("materialInstance", BindingFlags.NonPublic | BindingFlags.Instance);


        public static bool Prefix(VehicleInterface_Terrain __instance)
        {
            Material matInstance = (Material)VehicleInterface_MapController_materialInstance.GetValue(__instance);
            if (__instance.active)
            {
                if (Config.ToggleMapColor)
                {
                    matInstance.color = Config.MapColor.MapToColor(true);// new Color32(Convert.ToByte(Config.maprValue), Convert.ToByte(Config.mapgValue), Convert.ToByte(Config.mapbValue), Convert.ToByte(Config.mapAlpha));
                }
                else
                {
                    matInstance.color = Config.MapColor.MapToColor(false);
                }
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(VehicleInterface_MapController))]
    [HarmonyPatch("Update")]

    internal class VehicleInterface_MapController_Update_Patch
    {
        public static bool Prefix(VehicleInterface_MapController __instance)
        { 
            var playerDot = __instance.playerDot.GetAllComponentsInChildren<MeshRenderer>();
            var lightfx = __instance.lightVfx.GetAllComponentsInChildren<LineRenderer>();

            if (__instance.enabled)
            {
                foreach (var tests1 in playerDot)
                {
                    foreach (var tests2 in lightfx)
                    {
                        if (Config.ToggleMapColor)
                        {
                            tests1.material.color = Config.MapColor.MapToColor(true); // new Color32(Convert.ToByte(Config.maprValue), Convert.ToByte(Config.mapgValue), Convert.ToByte(Config.mapbValue), Convert.ToByte(Config.mapAlpha));
                            tests2.material.color = Config.MapColor.MapToColor(true);//new Color32(Convert.ToByte(Config.maprValue), Convert.ToByte(Config.mapgValue), Convert.ToByte(Config.mapbValue), Convert.ToByte(Config.mapAlpha));
                        }
                        else
                        {
                            tests1.material.color = Config.MapColor.MapToColor(false);
                            tests2.material.color = Config.MapColor.MapToColor(false);
                        }
                    }
                }
            }
            return true;
        }
    }
}
