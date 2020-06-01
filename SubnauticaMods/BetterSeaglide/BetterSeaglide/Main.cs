using System;
using System.IO;
using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace BetterSeaglide
{
    public class MainPatch
    {
        public static bool othermods;
        internal const string bsg = "BetterSeaglide";
        private static readonly string WhiteLightsDll = "../WhiteLights/WhiteLights.dll";
        public static string whiteLightsPath = Path.Combine(GetAssemblyDirectory, WhiteLightsDll);
        public static bool pGlide;

        private static string GetAssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        public static void FirstStart()
        {
            //if RandyKnapp WhiteLights is installed disable my light color change
            //Debug.Log($"whiteLightsPath is {File.Exists(whiteLightsPath)}");
            if (File.Exists(whiteLightsPath))
            {
                othermods = true;
            }
            else
            {
                othermods = false;
            }
            PrefabHandler.RegisterPrefab(new BetterSeaglide());
            if (othermods)
            {
                Menus.ConfigWhiteLights.Load();
                OptionsPanelHandler.RegisterModOptions(new Menus.OptionsWhiteLights());
                SecondStart();
            }
            //if RandyKnapp WhiteLights is not installed enable my light color change
            else
            {
                Menus.Config.Load();
                OptionsPanelHandler.RegisterModOptions(new Menus.Options());
                SecondStart();
            }

        }
        public static void SecondStart()
        {
            HarmonyInstance.Create("BetterSeaglide.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}