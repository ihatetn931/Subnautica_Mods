using System.Reflection;
using Harmony;
using SMLHelper.V2.Handlers;

namespace BetterSeaglideBZ
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
            HarmonyInstance.Create("BetterSeaglideBZ.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}