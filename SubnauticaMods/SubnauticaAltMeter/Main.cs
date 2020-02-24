using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SubnauticaAltMeter
{
    public class MainPatch
    {
        public static void FirstStart()
        {
           SecondStart();
        }
        public static void SecondStart()
        {
            HarmonyInstance.Create("SubnauticaAltMeter.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
