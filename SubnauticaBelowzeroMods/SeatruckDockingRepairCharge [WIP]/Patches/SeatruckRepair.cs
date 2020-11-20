using HarmonyLib;
using QModManager.API;
using QModManager.API.ModLoading;
using SeatruckDockRepairCharge;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Timers;
using UnityEngine;
namespace SeatruckDockingRepairCharge.Patches
{
    public class Patches
    {
        /* [HarmonyPatch(typeof(SeaTruckSegment))]
         [HarmonyPatch("Start")]
         public class SeaTruckSegment_Start_Patch
         {
             [QModPrePatch]
             private static bool Prefix(SeaTruckSegment __instance)
             {
                 List<SeaTruckSegment> chain = new List<SeaTruckSegment>();
                 __instance.rearCamera.enabled = false;
                 DevConsole.RegisterConsoleCommand(__instance, "killvehicle", false, false);

               //  __instance.CancelInvoke("GetTruckChain");
              //   __instance.InvokeRepeating("GetTruckChain", 1, 5);
                 QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"{__instance.IsInvoking("GetTruckChain")}", null, true);


                 return false;
             }
         }*/
        /*  [HarmonyPatch(typeof(SeaTruckDockingBay))]
          [HarmonyPatch("OnHoverEjectDocked")]
          public class SeaTruckDockingBay_Update_Patch
          {
              [QModPrePatch]
              private static bool Prefix(HandTargetEventData eventData, SeaTruckDockingBay __instance)
              {
                  HandReticle.main.SetIcon(HandReticle.IconType.Interact, 1f);
                  HandReticle.main.SetText(HandReticle.TextType.Hand, $"Eject Exosuit \n ExosuitCharge: {SeaTruckSegment_GetTruckChain_Patch.exoPower} \n ExosuitMaxCharge: {SeaTruckSegment_GetTruckChain_Patch.exoMaxPower}", true, GameInput.Button.LeftHand);
                  HandReticle.main.SetText(HandReticle.TextType.HandSubscript, string.Empty, false, GameInput.Button.None);
                  //QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"{__instance.}", null, true);


                  return false;
              }
          }*/


        [HarmonyPatch(typeof(SeaTruckSegment))]
        [HarmonyPatch("GetTruckChain")]
        public class SeaTruckSegment_GetTruckChain_Patch
        {
            public static float exoPower;
            public static float exoMaxPower;
            [QModPrePatch]
            private static bool Prefix(List<SeaTruckSegment> chain, SeaTruckSegment __instance)
            {
                chain.Clear();
                SeaTruckSegment seaTruckSegment = __instance;

                while (seaTruckSegment != null)
                {
                    chain.Add(seaTruckSegment);
                    SeaTruckConnection seaTruckConnection = seaTruckSegment.rearConnection;
                    seaTruckSegment = ((seaTruckConnection != null && seaTruckConnection.occupied) ? seaTruckConnection.GetConnection().truckSegment : null);
                }
                foreach (SeaTruckSegment segment in chain)
                {
                    if (segment.name.Equals("SeaTruckDockingModule(Clone)"))
                    {
                        foreach (Dockable dock in segment.GetAllComponentsInChildren<Dockable>())
                        {
                            foreach (EnergyMixin ener in dock.energyInterface.sources)
                            {
                                if (dock.vehicle != null)
                                {
                                    if (ener.charge < ener.capacity && segment.relay.GetPower() > 200.0f && MainPatch.ChargeValue != 0)
                                    {
                                        float maxPower;
                                        segment.relay.ConsumeEnergy(MainPatch.ChargeValue, out maxPower);
                                        QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"Seatruck Energy/MaxEnergy: {segment.relay.GetPower()}/{segment.relay.GetMaxPower()}", null, true);
                                        ener.AddEnergy(MainPatch.ChargeValue);

                                        QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"Exosuit Energy/MaxEnergy: {ener.charge}/{ener.capacity}", null, true);

                                        exoPower = ener.charge;
                                        exoMaxPower = ener.capacity;
                                    }
                                    if (dock.vehicle.liveMixin.health < dock.vehicle.liveMixin.maxHealth && MainPatch.RepairValue != 0)
                                    {
                                        dock.vehicle.liveMixin.AddHealth(MainPatch.RepairValue);

                                        float maxPower;
                                        segment.relay.ConsumeEnergy(MainPatch.RepairValue / 2, out maxPower);
                                        QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"Exosuit Health/MaxHealth: {dock.vehicle.liveMixin.health }/{dock.vehicle.liveMixin.maxHealth}", null, true);
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }

        }
    }
}

