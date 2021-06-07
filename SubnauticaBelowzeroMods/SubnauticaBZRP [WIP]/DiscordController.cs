using System;

using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections;
//using Oculus.Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
//using Oculus.Newtonsoft.Json.Linq;

namespace SubnauticaBZRP
{
    public enum PlayerState
    {
        Menu,
        Loading,
        Playing
    }

    public class DiscordController : MonoBehaviour
    {
        private static GameObject controllerGO;
        public static PlayerState state;
        private static string lImage;
        private static string pState;
        private static string pDetails;
        private static string sImage;
        private static string currentSceneName;
        private static bool dBug = false;
        public static bool FileCreated = false;
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        public static void Load()
        {
            controllerGO = new GameObject("DiscordController");
            controllerGO.AddComponent<DiscordController>();
            controllerGO.AddComponent<SceneCleanerPreserve>();
            DontDestroyOnLoad(controllerGO);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private static void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            currentSceneName = scene.name;
            Console.WriteLine("Loaded Scene: " + currentSceneName);
            if (currentSceneName.ToLower().Contains("menu"))
                state = PlayerState.Menu;
            if (controllerGO == null)
            {
                controllerGO = new GameObject("DiscordController").AddComponent<DiscordController>().gameObject;
            }
        }

        private void Update()
        {
            Main.discord.RunCallbacks();
            UpdateState();
            UpdateAll();
        }

        private void UpdateState()
        {
            if (currentSceneName.ToLower().Contains("menu"))
                state = PlayerState.Menu;
            else if (uGUI.main.loading.IsLoading || !uGUI.main)
                state = PlayerState.Loading;
            else
                state = PlayerState.Playing;
        }

        private void UpdateAll()
        {
            var activityManager = Main.discord.GetActivityManager();
            var main = new Discord.Activity
            {
                Details = pDetails,
                State = pState,
                Assets =
                {
                    LargeImage = lImage,
                    SmallImage = sImage
                },

            };

            activityManager.UpdateActivity(main, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    All();
                }
            });
        }
        void All()
        {
            if (state != PlayerState.Playing)
            {
                pDetails = (state == PlayerState.Menu) ? "In Menu" : "Loading";
                lImage = "main";
                sImage = "";
                pState = "";
                return;
            }
            lImage = "";

            var biome = Utility.GetBiomeDisplayName(Player.main.GetBiomeString().ToLower());
            var stringName = Utility.GetBiomeStringName(biome);
          //  Debug.Log("Biome: " + biome);
          //  Debug.Log("stringName: " + stringName);
          //  Debug.Log("BiomeString: " + Player.main.GetBiomeString());
            pDetails = "At " + textInfo.ToTitleCase(biome.Replace("_", " "));
            lImage = biome;

            if (Player.main.GetBiomeString() != null)
            {
                Json.AddNewBiome(Player.main.GetBiomeString());
            }
            else if (dBug)
            {
                ErrorMessage.AddDebug($"Biome is {biome}");
                ErrorMessage.AddDebug($"Player.main.GetBiomeString() is {Player.main.GetBiomeString()}");
                ErrorMessage.AddDebug($"StringName is {stringName}");
            }

            var subRoot = Player.main.IsInBase();
            var exoSuit = Player.main.inExosuit;
            var seatruck = Player.main.IsPilotingSeatruck();
            var snowfox = Player.main.inHovercraft;
            var seaglide = Player.main.motorMode == Player.MotorMode.Seaglide;
            var depth = Mathf.FloorToInt(Player.main.GetDepth());
            int altitude = (int)Player.main.transform.position.y;

            if (subRoot)
            {
                var type = subRoot.GetType().Equals(typeof(BaseRoot)) ? "Base" : "Base";
                pState = "In " + type;
                sImage = "";
            }
            else if (exoSuit)
            {
                var type = exoSuit.GetType().Equals(typeof(Exosuit)) ? "Prawn" : "Prawn";
                pState = "Piloting " + type;
                sImage = type.ToLower();
            }
            else if (seatruck)
            {
                var type = seatruck.GetType().Equals(typeof(SeaTruckMotor)) ? "SeaTruck" : "SeaTruck";
                pState = "Piloting " + type;
                sImage = type.ToLower();
            }
            else if (snowfox)
            {
                var type = snowfox.GetType().Equals(typeof(Hoverbike)) ? "SnowFox" : "SnowFox";
                pState = "Piloting " + type;
                sImage = type.ToLower();
            }
            else if (seaglide)
            {
                var type = seaglide.GetType().Equals(typeof(Seaglide)) ? "Seaglide" : "Seaglide";
                pState = "Piloting " + type;
                sImage = type.ToLower();
            }
            else if (Player.main.IsUnderwaterForSwimming())
            {
                pState = "Swimming";
                sImage = "fins";
            }
            else if (!Player.main.IsSwimming())
            {
                pState = "On Foot ";
                sImage = "";
            }

            if (pState != "")
            {
                if (depth != 0)
                {
                    pState += " (Depth: " + depth + "m)";
                }
                else if (altitude != 0)
                {
                    pState += " (Altitude: " + altitude + "m)";
                }

            }
        }
    }
}


