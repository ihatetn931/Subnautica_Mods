using HarmonyLib;
using SMLHelper.V2.Handlers;
using System.Reflection;
using UnityEngine;

namespace JukeBoxMod
{
    public class MainPatch
    {
        public static bool isPlaying;
        public static bool isPaused;
        public static void FirstStart()
        {
            SecondStart();
        }
        public static void SecondStart()
        {
            Harmony harmony = new Harmony("JukeBoxMod.mod");
            harmony.PatchAll();
        }
    }
}
