using Harmony;
using System;
using System.Reflection;
using UnityEngine;


namespace BetterSeaglideBZ.Patches
{

    class SeaglideSpeedPatch
    {
        [HarmonyPatch(typeof(Seaglide))]
        [HarmonyPatch("UpdatePropFX")]

        internal class Seaglide_UpdatePropFx_Patch
        {
            // private static readonly FieldInfo EngineRpmSFXManager__topClampSpeed = typeof(EngineRpmSFXManager).GetField("topClampSpeed", BindingFlags.NonPublic | BindingFlags.Instance);
            public static bool Prefix(Seaglide __instance)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    
                    Subtitles.Add($"smoothedmovespeed is {__instance._smoothedMoveSpeed}");
                    __instance._smoothedMoveSpeed = 200;
                    //topSpeed += 500;
                }
                else
                {
                    __instance._smoothedMoveSpeed = 0;
                }


                return true;
            }
        }

    }
}
