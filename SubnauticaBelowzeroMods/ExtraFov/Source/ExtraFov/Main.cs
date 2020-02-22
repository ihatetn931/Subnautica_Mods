using Harmony;
using System.Reflection;
using UnityEngine;


namespace ExtraFov
{
    public class MainPatch
    {
        public static void FirstStart()
        {
            //Config.Load();
            //OptionsPanelHandler.RegisterModOptions(new Options());
            SecondStart();
        }
        public static void SecondStart()
        { 
            HarmonyInstance.Create("ExtraFov.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }

}
[HarmonyPatch(typeof(PlayerMask))]
[HarmonyPatch("Start")]
internal static class PlayerMask_Start_Patch
{
    static bool Prefix(PlayerMask __instance)
    {
        Debug.Log($"[ExtraFov] __instance is {__instance.referenceFov}");
        //__instance.referenceFov += 200.0f;
        return true;
    }
}