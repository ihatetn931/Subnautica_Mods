using Harmony;
using System;
using UnityEngine;

namespace BetterSeaglide.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]

    internal class Seaglide_Color_Patch
    {
        public static bool Prefix(Seaglide __instance)
        {

            var sgColor = __instance.GetAllComponentsInChildren<SkinnedMeshRenderer>();
            var pickupablesgColor = __instance.GetAllComponentsInChildren<MeshRenderer>();

            foreach (var seaglideColor in sgColor)
            {
                if (seaglideColor.name.Contains("SeaGlide_geo"))
                {
                    seaglideColor.material.color = new Color32(Convert.ToByte(Config.seagliderValue), Convert.ToByte(Config.seaglidegValue), Convert.ToByte(Config.seaglidebValue), 1);
                }
            }
            foreach(var droppedseaglideColor in pickupablesgColor)
            {
                if (droppedseaglideColor.name.Contains("SeaGlide_01_TP"))
                {
                    droppedseaglideColor.material.color = new Color32(Convert.ToByte(Config.seagliderValue), Convert.ToByte(Config.seaglidegValue), Convert.ToByte(Config.seaglidebValue), 100);
                }
            }
            return true;
        }
    }
}
