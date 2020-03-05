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
            //var radar = __instance.GetAllComponentsInChildren<VehicleInterface_MapController>();
            foreach (var seaglideColor in sgColor)
            {
                if (seaglideColor.name.Contains("SeaGlide_geo"))
                {
                    if (MainPatch.othermods == false)
                    {
                        seaglideColor.material.color = new Color32(Convert.ToByte(Menus.Config.seagliderValue), Convert.ToByte(Menus.Config.seaglidegValue), Convert.ToByte(Menus.Config.seaglidebValue), 1);
                    }
                    else
                    {
                        seaglideColor.material.color = new Color32(Convert.ToByte(Menus.ConfigWhiteLights.seagliderValue), Convert.ToByte(Menus.ConfigWhiteLights.seaglidegValue), Convert.ToByte(Menus.ConfigWhiteLights.seaglidebValue), 1);
                    }
                }
            }
            foreach(var droppedseaglideColor in pickupablesgColor)
            {
                if (droppedseaglideColor.name.Contains("SeaGlide_01_TP"))
                {
                    if (MainPatch.othermods == false)
                    {
                        droppedseaglideColor.material.color = new Color32(Convert.ToByte(Menus.Config.seagliderValue), Convert.ToByte(Menus.Config.seaglidegValue), Convert.ToByte(Menus.Config.seaglidebValue), 100);
                    }
                    else
                    {
                        droppedseaglideColor.material.color = new Color32(Convert.ToByte(Menus.ConfigWhiteLights.seagliderValue), Convert.ToByte(Menus.ConfigWhiteLights.seaglidegValue), Convert.ToByte(Menus.ConfigWhiteLights.seaglidebValue), 100);
                    }
                }
            }
            return true;
        }
    }
}
