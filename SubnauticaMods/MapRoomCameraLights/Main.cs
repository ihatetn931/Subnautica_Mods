using Harmony;
using SMLHelper.V2.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MapRoomCameraLights
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
            HarmonyInstance.Create("MapRoomCameraLights.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
