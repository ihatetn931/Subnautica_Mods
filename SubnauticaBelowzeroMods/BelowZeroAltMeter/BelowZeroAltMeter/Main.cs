
using HarmonyLib;
using QModManager.API.ModLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BelowZeroAltMeter
{
    [QModCore]
    public class MainPatch
    {
        public static void FirstStart()
        {
           SecondStart();
        }
        [QModPatch]
        public static void SecondStart()
        {
           // HarmonyInstance.Create("BelowZeroAltMeter.mod").PatchAll(Assembly.GetExecutingAssembly());
            Harmony harmony = new Harmony("BelowZeroAltMeter.mod");
            harmony.PatchAll();
        }
    }
}
