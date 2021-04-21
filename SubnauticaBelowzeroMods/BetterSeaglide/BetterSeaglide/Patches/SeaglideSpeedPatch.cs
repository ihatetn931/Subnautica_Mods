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
            //var myvalue = Traverse.Create(__instance).Field("_smoothedMoveSpeed").GetValue();

            // For example to get the value "allAvailableItems" of the class ItemManager we can do that :
            
            if (usingSeaglide)
            {
                if (__instance.powerGlideActive)
                {

                    if (__instance.HasEnergy())
                    {
                        __instance.powerGlideForce = MainPatch.boostSpeed;

                        num = Mathf.Clamp(__instance.GetComponent<Rigidbody>().velocity.magnitude / 5f, 0f, 1f);
                        
                        // QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info,$"shit: {}", ex: null, showOnScreen: true);
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
    [HarmonyPatch(typeof(PlayerTool))]
    [HarmonyPatch("OnDraw")]
    class PlayerTooldOnDrawPatch
    {
        public static bool Prefix(PlayerTool __instance)
        {
            if (__instance != null)
            {
                //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Debug, $"playerTool:{__instance}", null, true);
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
                            __instance.GetComponent<EnergyMixin>().ConsumeEnergy(0.005f);
                            __instance.animator.speed = speed;
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.3f);
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.3f);
                            Traverse.Create(__instance).Field("_smoothedMoveSpeed").SetValue(MainPatch.boostSpeed);
                            MainPatch.pGlide = true;
                        }
                        else
                        {
                            __instance.powerGlideActive = false;
                            __instance.animator.speed = 1;
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.0f);
                            __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.0f);
                            Traverse.Create(__instance).Field("_smoothedMoveSpeed").SetValue(0f);
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
                    Traverse.Create(__instance).Field("_smoothedMoveSpeed").SetValue(0f);
                    MainPatch.pGlide = false;
                }
            }
            else
            {
                __instance.powerGlideActive = false;
                __instance.animator.speed = 1;
                __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setPitch(1.0f);
                __instance.engineRPMManager.engineRpmSFX.GetEventInstance().setVolume(1.0f);
                Traverse.Create(__instance).Field("_smoothedMoveSpeed").SetValue(0f);
                MainPatch.pGlide = false;
            }
            return true;
        }
    }
}
