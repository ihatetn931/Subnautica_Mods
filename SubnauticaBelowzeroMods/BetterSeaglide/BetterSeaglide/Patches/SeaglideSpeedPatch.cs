using HarmonyLib;
using QModManager.API.ModLoading;
using UnityEngine;

namespace BetterSeaglideBZ.Patches
{

    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("FixedUpdate")]

    class SeaglideSpeedFixedUpdatePatch
    {
        [QModPrePatch]
        public static bool Prefix(Seaglide __instance)
        {
            var usingSeaglide = Player.main.motorMode == Player.MotorMode.Seaglide;
            float num = 0f;            
            if (usingSeaglide)
            {
                if (__instance.powerGlideActive)
                {
                    if (__instance.HasEnergy())
                    {
                        __instance.powerGlideForce = MainPatch.boostSpeed;

                        num = Mathf.Clamp(__instance.GetComponent<Rigidbody>().velocity.magnitude / 5f, 0f, 1f);
                        
                        Player.main.gameObject.GetComponent<Rigidbody>().AddForce(__instance.gameObject.transform.forward * __instance.powerGlideForce, ForceMode.Force);
                        MainPatch.pGlide = true;
                    }
                }
                else
                {
                    __instance.powerGlideActive = false;
                    MainPatch.pGlide = false;
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]
    class SeaglideSpeedUpdatePatch
    {
        [QModPrePatch]
        public static bool Prefix(Seaglide __instance)
        {
            var usingSeaglide = Player.main.motorMode == Player.MotorMode.Seaglide;
            float speed = Mathf.FloorToInt(Player.main.rigidBody.velocity.magnitude);
            MainPatch.boostSpeed = speed + 2000;
            if (__instance.GetComponent<EnergyMixin>().charge >= 10)
            {
                if (Input.GetKey(MainPatch.BoostKey))
                {
                    if (usingSeaglide)
                    {
                        if (speed > 5)
                        {
                            __instance.powerGlideActive = true;
                            MainPatch.pGlide = true;
                            __instance.powerGlideForce = MainPatch.boostSpeed;//  MainPatch.boostSpeed;
                            __instance.GetComponent<EnergyMixin>().ConsumeEnergy(0.000005f);
                            __instance.animator.speed = speed;
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.1f);
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.1f);
                            __instance._smoothedMoveSpeed = MainPatch.boostSpeed;
                            MainPatch.pGlide = true;
                        }
                        else
                        {
                            __instance.powerGlideActive = false;
                            __instance.animator.speed = 1;
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.0f);
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.0f);
                            __instance._smoothedMoveSpeed = 0f;
                            MainPatch.pGlide = false;
                        }

                    }
                }
                else
                {
                    __instance.powerGlideActive = false;
                    __instance.animator.speed = 1;
                    __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.0f);
                    __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.0f);
                    __instance._smoothedMoveSpeed = 0;
                    MainPatch.pGlide = false;
                }
            }
            else
            {
                __instance.powerGlideActive = false;
                __instance.animator.speed = 1;
                __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.0f);
                __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.0f);
                __instance._smoothedMoveSpeed = 0;
                MainPatch.pGlide = false;
            }
            return true;
        }
    }
}
