using HarmonyLib;
using SMLHelper.V2.Handlers;
using System.Reflection;


namespace MapRoomCameraLightsBZ
{
    public class MainPatch
    {
        internal static Config CamLights { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        public static float Intensity;
        public static float Range;
        public static float spotAngle;

        public static bool Toggle;

        public static void FirstStart()
        {
            Toggle = CamLights.ToggleScannerRoomCameraLughts;
            Intensity = CamLights.MapIntensity;
            Range = CamLights.MapRange;
            spotAngle = CamLights.MapspotAngle;
           // Config.Load();
          //  OptionsPanelHandler.RegisterModOptions(new Options());
            SecondStart();
        }
        public static void SecondStart()
        {
            //HarmonyInstance.Create("MapRoomCameraLights.mod").PatchAll(Assembly.GetExecutingAssembly());
            Harmony harmony = new Harmony("MapRoomCameraLightsBZ.mod");
            harmony.PatchAll();
        }
    }
}
