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
            var speed = Mathf.FloorToInt(Player.main.rigidBody.velocity.magnitude);
            int boostSpeed = 1800;
            if (usingSeaglide)
            {
                if (__instance.powerGlideActive)
                {
                    if (__instance.HasEnergy())
                    {
                        __instance.powerGlideForce = boostSpeed; // the for that is applied
                        __instance.energyMixin.ConsumeEnergy(0.0001f);// For energy Consumption
                        __instance._smoothedMoveSpeed = speed; //* 4000; The moving effects
                        __instance.engineRPMManager.engineRpmSFX.evt.setPitch(1.3f); //sets the sound pitch
                        __instance.engineRPMManager.engineRpmSFX.evt.setVolume(2.0f);//Change the volume
                        __instance.animator.speed = speed;// Prop Animation speed
                        //MainPatch.pGlide = true;
                    }

                }
                else
                {
                    __instance.engineRPMManager.engineRpmSFX.evt.setPitch(1);
                    __instance._smoothedMoveSpeed = 0;
                    __instance.powerGlideActive = false;
                    __instance.animator.speed = 1;
                    __instance.engineRPMManager.engineRpmSFX.evt.setVolume(1);
                    MainPatch.pGlide = false;
                }
            }
            return true;
        }
    }


    [HarmonyPatch(typeof(VehicleInterface_EnergyBar))]
    [HarmonyPatch("Update")]
    class VehicleInterface_EnergyBarUpdatePatch
    {
        public static bool Prefix(VehicleInterface_EnergyBar __instance)
        {
            if (__instance.enabled)
            {
                var speed = Mathf.FloorToInt(Player.main.rigidBody.velocity.magnitude);
                __instance.energyBarMat.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                //__instance.energyBarMat.
                __instance.energyBar.transform.localRotation = new Quaternion(Menus.Config.x, Menus.Config.y, Menus.Config.z, Menus.Config.w);
                __instance.energyBar.transform.localPosition = new Vector3(0.0f, Menus.Config.y1, Menus.Config.z1);
                //ErrorMessage.AddWarning($"{__instance.energyMixin.GetEnergyScalar()}");
                //test.material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(Fabricator))]
    [HarmonyPatch("Start")]
    class FabricatorStartPatch
    {
        public static bool Prefix(Fabricator __instance)
        {
            //__instance.CancelInvoke("LateUpdate");
            __instance.InvokeRepeating("LateUpdate", 0.0f, 1);
            return true;
        }
    }
    [HarmonyPatch(typeof(Fabricator))]
    [HarmonyPatch("LateUpdate")]
    class FabricatorLateUpdatePatch
    {
        public static bool Prefix(Fabricator __instance)
        {

            var ghostModel = __instance.ghost.GetAllComponentsInChildren<CrafterGhostModel>();
            foreach (var model in ghostModel)
            {
                ErrorMessage.AddWarning($"ghostModel is {model.ghostMaterials}");
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
            //ErrorMessage.AddWarning($" {Mathf.FloorToInt(Player.main.rigidBody.velocity.magnitude)}");
            var batteryMeter = __instance.gameObject.GetAllComponentsInChildren<VehicleInterface_EnergyBar>();
            float speed = Mathf.FloorToInt(Player.main.rigidBody.velocity.magnitude);
            if (!usingSeaglide)
            {
                foreach (var bat in batteryMeter)
                {
                    bat.energyBar.SetActive(true);
                    bat.gameObject.SetActive(true);
                    __instance.engineRPMManager.engineRpmSFX.evt.setPitch(1);
                    __instance._smoothedMoveSpeed = 0;
                    __instance.powerGlideActive = false;
                    __instance.animator.speed = 1;
                    __instance.engineRPMManager.engineRpmSFX.evt.setVolume(1);
                    MainPatch.pGlide = false;
                }
            }
            else if (usingSeaglide)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (speed > 5)
                    {
                        __instance.powerGlideActive = true;
                        MainPatch.pGlide = true;
                    }
                    foreach (var bat in batteryMeter)
                    {
                        if (__instance.HasEnergy())
                        {
                            bat.energyBar.SetActive(true);
                            bat.gameObject.SetActive(true);
                        }
                        else
                        {
                            bat.energyBar.SetActive(false);
                            bat.gameObject.SetActive(false);
                            __instance.powerGlideActive = false;
                            MainPatch.pGlide = false;

                        }
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
}
