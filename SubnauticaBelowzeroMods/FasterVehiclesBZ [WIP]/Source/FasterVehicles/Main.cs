using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FasterSeaglideBZ
{
    public class MainPatch
    {
        public static void FirstStart()
        {
            SecondStart();
        }
        public static void SecondStart()
        {
            HarmonyInstance.Create("FasterSeaglideBZ.mod").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
