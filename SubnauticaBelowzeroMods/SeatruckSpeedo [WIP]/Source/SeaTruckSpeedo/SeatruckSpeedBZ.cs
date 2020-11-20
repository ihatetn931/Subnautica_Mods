using System;
using SMLHelper.V2.Utility;
using System.IO;
using System.Reflection;
using Harmony;
using UnityEngine;
using UnityEngine.UI;

namespace SeatruckSpeedoBZ
{
    
    public class MainPatch
    {
        public static bool animationsEnabled = true;
        public static bool imagesEnabled = true;
        public static byte imageAlpha = 255;

        public static GameObject BiomeHUD { get; set; }

        private const string modFolder = "./QMods/SeatruckSpeedoBZ/";
        private const string assetFolder = modFolder + "Assets/";
        private const string assetBundle = assetFolder + "biomehudchip";

        public static int speed { get;  set; }
        public static string getText { get; set; }
        public static bool pilotingSeaTruck = false;
        public static bool pilotingExoSuit = false;
        //public static bool pilotingSnowfox = false;
        //public static bool pilotingSeaglide = false;
        public static void FirstStart()
        {
            //Config.Load();
            //OptionsPanelHandler.RegisterModOptions(new Options());
            AssetBundle ab = AssetBundle.LoadFromFile(assetBundle);
            SecondStart();
        }
        public static void SecondStart()
        {
            HarmonyInstance.Create("SeatruckSpeedoBZ.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Update")]
    internal static class Player_Update_Patch
    {
        [HarmonyPrefix]

        static bool Prefix(Player __instance)
        {

            if (__instance.IsPilotingSeatruck())
            {

                MainPatch.pilotingSeaTruck = true;
            }
            else
            {
                MainPatch.pilotingSeaTruck = false;
            }
            if (__instance.GetVehicle() != null)
            {
                if (__instance.GetVehicle().name.Contains("Exosuit"))
                {
                    MainPatch.pilotingExoSuit = true;
                }
            }
            else
            {
                MainPatch.pilotingExoSuit = false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(SeaTruckMotor))]
    [HarmonyPatch("Update")]
    internal static class SeaTruckMotor_Update_Patch
    {
        static void Postfix(SeaTruckMotor __instance)
        {
            if (MainPatch.pilotingSeaTruck)
            {
                if (__instance.useRigidbody != null)
                {
                    MainPatch.speed = Mathf.FloorToInt(__instance.useRigidbody.velocity.magnitude);
                    ErrorMessage.AddMessage($"Speed SeaTruck: {MainPatch.speed}");
                    
                }
            }
        }
    }
    [HarmonyPatch(typeof(Exosuit))]
    [HarmonyPatch("Update")]
    internal static class Exosuit_Update_Patch
    {
        static void Postfix(Exosuit __instance)
        {
            if (MainPatch.pilotingExoSuit)
            {
                if (__instance.useRigidbody != null)
                {
                    MainPatch.speed = Mathf.FloorToInt(__instance.useRigidbody.velocity.magnitude);
                    ErrorMessage.AddMessage($"Speed Exo: {MainPatch.speed}");
                }
            }
        }
    }
    /*[HarmonyPatch(typeof(Hoverbike))]
    [HarmonyPatch("Update")]
    internal static class Hoverbike_Update_Patch
    {
        static void Postfix(Hoverbike __instance)
        {
            if (MainPatch.pilotingSnowfox)
            {
                if (__instance.rb != null)
                {
                    MainPatch.speed = Mathf.FloorToInt(__instance.rb.velocity.magnitude);
                    Subtitles.Add($"Speed SnowFox: {MainPatch.speed}");
                }
            }
        }
    }
    [HarmonyPatch(typeof(Seaglide))]
    [HarmonyPatch("Update")]
    internal static class Seaglide_Update_Patch
    {
        static void Postfix(Seaglide __instance)
        {
            if (MainPatch.pilotingSeaglide)
            {
                if (__instance.rb != null)
                {
                    MainPatch.speed = Mathf.FloorToInt(__instance..velocity.magnitude);
                    Subtitles.Add($"Speed SnowFox: {MainPatch.speed}");
                }
            }
        }
    }*/
}
