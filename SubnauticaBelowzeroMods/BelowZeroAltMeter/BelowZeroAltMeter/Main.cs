using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BelowZeroAltMeter
{
    public class MainPatch
    {
        public static void FirstStart()
        {
           SecondStart();
        }
        public static void SecondStart()
        {
            HarmonyInstance.Create("BelowZeroAltMeter.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
