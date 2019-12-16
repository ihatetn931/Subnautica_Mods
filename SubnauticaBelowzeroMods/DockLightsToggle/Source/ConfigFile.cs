﻿using System;
using System.IO;
using System.Reflection;
using UnityEngine;
//public static bool dBug = false;
namespace DockLightsToggleBZ
{
    [Serializable]
    public class LightState
    {
        public bool SeaTruckLightState;// { get; set; }
    }

    public static class ConfigFile
    {
        private static readonly string LightsState = "seatrucklightstate.json";
        private static string GetAssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        public static string lightStatePath = Path.Combine(GetAssemblyDirectory, LightsState);
        public static bool AttemptToLoad()
        {
            
            if (File.Exists(lightStatePath))
            {
                string settingsJson = File.ReadAllText(lightStatePath);
                LightState settingFromFile = JsonUtility.FromJson<LightState>(settingsJson);
                MainPatch.state = settingFromFile;
            }
            else
            {
                AttemptToCreate();
                //Debug.Log("[DockingLightsToggle] Mod was not loaded missing settings.json");
                //return false;
            }
            return true;
        }
        public static bool AttemptToCreate()
        {

            if (!File.Exists(lightStatePath))
            {
                LightState myObject = new LightState();
                string json = JsonUtility.ToJson(myObject);
                myObject.SeaTruckLightState = false;
                File.WriteAllText(lightStatePath, json);
                AttemptToLoad();


            }
            else
            {
                AttemptToLoad();
            }
            return true;
        }
        public static bool AttemptToSave(bool state)
        {
            if (File.Exists(lightStatePath))
            {
                LightState myObject = new LightState
                {
                    SeaTruckLightState = state
                };
                string toJson = JsonUtility.ToJson(myObject);
                JsonUtility.FromJsonOverwrite(toJson, myObject);
                File.WriteAllText(lightStatePath, toJson);
            }
            else
            {
                Debug.Log("[DockingLightsToggle] Where is LightState.json");
            }
            return true;
        }
    }
}
