using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MapRoomCameraLights
{
    [HarmonyPatch(typeof(MapRoomCamera))]
    [HarmonyPatch("Update")]

    internal class MapRoomLightUpdatePatch
    {
        public static bool Prefix(MapRoomCamera __instance)
        {
            var mapLights = __instance.lightsParent.GetComponentsInChildren<Light>();
            if (mapLights != null)
            {
                foreach (var allLights in mapLights)
                {
                    allLights.spotAngle = Config.MapspotAngle;
                    //allLights.color = Config.MapRoomLights.ToColor(true);
                    allLights.intensity = Config.MapIntensity;
                    allLights.range = Config.MapRange;
                    //break;
                }
            }
            return true;
        }
    }
}
