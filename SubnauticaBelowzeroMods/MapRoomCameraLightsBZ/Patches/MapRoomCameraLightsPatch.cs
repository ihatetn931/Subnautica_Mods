using HarmonyLib;
using UnityEngine;

namespace MapRoomCameraLightsBZ
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
                    allLights.spotAngle = MainPatch.spotAngle;
                    allLights.intensity = MainPatch.Intensity;
                    allLights.range = MainPatch.Range;
                }
            }
            return true;
        }
    }
}
