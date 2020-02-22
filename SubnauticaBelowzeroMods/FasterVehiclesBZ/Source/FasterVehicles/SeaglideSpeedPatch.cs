using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using static RootMotion.FinalIK.RagdollUtility;

namespace FasterSeaglideBZ
{
    class SeaglideSpeedPatch
    {
        [HarmonyPatch(typeof(Seaglide))]
        [HarmonyPatch("Update")]
        internal static class Seaglide_Start_Patch
        {
            static bool Prefix(Seaglide __instance)
            {
                __instance.engineRPMManager.AccelerateInput(2f);
                return true;
            }
        }
    }
}
