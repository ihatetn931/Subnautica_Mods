using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BetterSeaglide.Patches
{
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("FixedUpdate")]
    class SeaglideSpeedFixedUpdatePatch
    {
        public static bool Prefix(Seaglide __instance)
        {
            var usingSeaglide = Player.main.motorMode == Player.MotorMode.Seaglide;
            int boostSpeed = 1300;
            if (usingSeaglide)
            {
                if (__instance.powerGlideActive)
                {
                    if (__instance.HasEnergy())
                    {
                        __instance.powerGlideForce = __instance.animator.speed;
                        __instance.energyMixin.ConsumeEnergy(0.0001f);
                        __instance._smoothedMoveSpeed = __instance.powerGlideForce; //* 4000;
                        __instance.engineRPMManager.engineRpmSFX.evt.setPitch(1.3f);
                        __instance.animator.speed = boostSpeed;
                    }
                }
            }
            else
            {
                __instance.engineRPMManager.engineRpmSFX.evt.setPitch(1);
                __instance._smoothedMoveSpeed = 0;
                __instance.powerGlideActive = false;
                __instance.animator.speed = 1;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]
    class SeaglideSpeedUpdatePatch
    {
        public static bool Prefix(Seaglide __instance)
        {
            var usingSeaglide = Player.main.motorMode == Player.MotorMode.Seaglide;
            if (usingSeaglide)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    __instance.powerGlideActive = true;
                }
                else
                {
                    __instance.powerGlideActive = false;
                    __instance.engineRPMManager.engineRpmSFX.evt.setPitch(1);
                    __instance._smoothedMoveSpeed = 0;
                    __instance.powerGlideForce = 0;
                    __instance.animator.speed = 1;
                }
            }
            return true;
        }
    }
}
