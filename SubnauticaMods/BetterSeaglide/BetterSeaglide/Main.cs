using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;
using UnityEngine;

namespace BetterSeaglide
{
    public class MainPatch
    {
        public static void FirstStart()
        {
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options());
            SecondStart();
        }
        public static void SecondStart()
        {
            HarmonyInstance.Create("BetterSeaglide.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}