using System.Reflection;
using System;
using Harmony;
using SMLHelper.V2.Handlers;
using UnityEngine;

using UnityEngine.Events;
using UnityEngine.UI;

namespace BetterFlashLightBZ
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
            HarmonyInstance.Create("BetterFlashLight.mod").PatchAll(Assembly.GetExecutingAssembly());


        }
    }
    //var flashLight = __instance.transform.Find("lights_parent").GetComponentsInChildren<Light>(false);
    //Color fLcolor = new Color(Config.rValue, Config.rValue, Config.rValue, 1.000f);
    //__instance.flashLight.color = fLcolor;
}