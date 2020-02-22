using Harmony;
using System;
using System.Reflection;
using UnityEngine;


namespace BetterSeaglideBZ.Patches
{

    class SeaglideSpeedPatch
    {
        [HarmonyPatch(typeof(Seaglide))]
        [HarmonyPatch("Update")]

        internal class Seaglide_UpdatePropFx_Patch
        {
            private static readonly FieldInfo Seaglide___smoothedMoveSpeed = typeof(Seaglide).GetField("_smoothedMoveSpeed", BindingFlags.NonPublic | BindingFlags.Instance);
           // private static readonly FieldInfo EngineRpmSFXManager__topClampSpeed = typeof(EngineRpmSFXManager).GetField("topClampSpeed", BindingFlags.NonPublic | BindingFlags.Instance);
            public static bool Prefix(Seaglide __instance)
            {
                //int speed = (int)Seaglide__fmodIndexPowerglide.GetValue(__instance);
                 Single topSpeed = (Single)Seaglide___smoothedMoveSpeed.GetValue(__instance);

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Debug.Log($"smoothedmovespeed is {topSpeed}");
                        topSpeed += 500;
                    }
                

                return true;
            }
        }

    }
}
