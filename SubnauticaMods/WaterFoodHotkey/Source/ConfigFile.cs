using System;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
//public static bool dBug = false;
namespace WaterFoodHotkey
{
    [Serializable]
    public class WaterFoodHotKeyStates
    {
        public bool UseThisConfig;
        public string WaterHotKey;
        public string FoodHotKey;
        public int TextValue;
        public bool ToggleWaterHotKey;
        public bool ToggleFoodHotKey;
        public float WaterPercentage;
        public float FoodPercentage;
    }


    public class ConfigFile
    {

        private static readonly string LightsState = "waterfoodhotkeysettings.json";
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

        private bool ValidateValues(WaterFoodHotKeyStates cfg, out KeyCode selectedKey)
        {
            selectedKey = KeyCode.None;

            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                Debug.Log($"[WaterFoodHotKey] Key: {key}");
                if (String.Equals(key.ToString(), cfg.WaterHotKey, StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log($"[WaterFoodHotKey] WaterKey: {key}");
                    selectedKey = key;

                    break;
                }
                if (String.Equals(key.ToString(), cfg.FoodHotKey, StringComparison.OrdinalIgnoreCase))
                {
                    selectedKey = key;
                    Debug.Log($"[WaterFoodHotKey] FoodKey: {key}");
                    break;
                }
            }

            if (selectedKey != KeyCode.None)
            {
                return true;
            }

            return false;
        }

        internal bool AttemptToLoad()
        {
            try
            {
                if (File.Exists(lightStatePath))
                {
                    string settingsJson = File.ReadAllText(lightStatePath);
                    WaterFoodHotKeyStates settingFromFile = JsonUtility.FromJson<WaterFoodHotKeyStates>(settingsJson);
                    MainPatch.settings = settingFromFile;
                    if (!this.ValidateValues(settingFromFile, out KeyCode validatedKeyCode))
                    {
                        QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"validatedKeyCode: {validatedKeyCode}", null, true);
                        return false;
                    }
                    else
                    {
                        QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"else validatedKeyCode: {validatedKeyCode}", null, true);
                    }
                    HarmonyPatches.FirstAidHotkey = validatedKeyCode;
                }
            }
            return true;
        }
        internal bool AttemptToCreate()
        {
            if (!File.Exists(lightStatePath))
            {
                WaterFoodHotKeyStates myObject = new WaterFoodHotKeyStates();
                myObject.UseThisConfig = false;
                myObject.WaterHotKey = "K"; 
                myObject.FoodHotKey = "L";
                myObject.TextValue = 0;
                myObject.ToggleFoodHotKey = true;
                myObject.ToggleWaterHotKey = true;
                myObject.WaterPercentage = 50.0f;
                myObject.FoodPercentage = 50.0f;
                // myObject.HoveBikeLightState = false;
                string json = JsonUtility.ToJson(myObject, true);
                File.WriteAllText(lightStatePath, json);
                // AttemptToLoad();
            }
            return true;
        }
        /*  public static bool AttemptToSave(bool state)
          {
              if (File.Exists(lightStatePath))
              {
                  WaterFoodHotKeyStates myObject = new WaterFoodHotKeyStates
                  {
                      SeaTruckLightState = state,
                      //HoveBikeLightState = state
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
          }*/
    }
}
