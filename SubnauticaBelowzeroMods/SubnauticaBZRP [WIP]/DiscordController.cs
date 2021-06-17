using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;
using CUE.NET;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using CUE.NET.Devices.Mouse;
using CUE.NET.Devices.Mouse.Enums;
using CUE.NET.Devices.Generic;
using CUE.NET.Brushes;

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
        private static GameObject discordGameObject;
        public static PlayerState state;
        private static string largeImage;
        private static string pState;
        private static string pDetails;
        private static string smallImage;
        private static string currentSceneName;
        private static bool dBug = false;

        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public static void Load()
        {
            discordGameObject = new GameObject("DiscordController");
            discordGameObject.AddComponent<DiscordController>();
            discordGameObject.AddComponent<SceneCleanerPreserve>();
            DontDestroyOnLoad(discordGameObject);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private static void SceneManager_sceneLoaded(Scene scene, LoadSceneMode scenemode)
        {
            if (scene.name != null)
            {
                currentSceneName = scene.name;
                Console.WriteLine("Loaded Scene: " + currentSceneName);
                if (currentSceneName.ToLower().Contains("menu"))
                    state = PlayerState.Menu;
                if (discordGameObject == null)
                {
                    discordGameObject = new GameObject("DiscordController").AddComponent<DiscordController>().gameObject;
                }
            }
        }

        private void Update()
        {
            Main.discord.RunCallbacks();
            UpdateState();
            UpdateAll();
           // CueSDK.UpdateMode = UpdateMode.Continuous;
        }

        private void UpdateState()
        {
            if (currentSceneName != null)
            {
                if (currentSceneName.ToLower().Contains("menu"))
                    state = PlayerState.Menu;
                else if (uGUI.main.loading.IsLoading || !uGUI.main)
                    state = PlayerState.Loading;
                else
                    state = PlayerState.Playing;
            }
        }

        private void UpdateAll()
        {
            var activityManager = Main.discord.GetActivityManager();
            var main = new DiscordControl.Activity
            {
                Details = pDetails,
                State = pState,
                Assets =
                {
                    LargeImage = largeImage,
                    SmallImage = smallImage
                },
            };

            activityManager.UpdateActivity(main, (res) =>
            {
                if (res == DiscordControl.Result.Ok)
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
                largeImage = "main";
                smallImage = "";
                pState = "";
                return;
            }

            largeImage = "";

            var biome = BiomeList.GetBiomeDisplayName(Player.main.GetBiomeString().ToLower());
            var stringName = BiomeList.GetBiomeStringName(biome);

            pDetails = "Exploring " + textInfo.ToTitleCase(biome.Replace("_", " "));

            largeImage = biome;

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
                smallImage = "";
            }
            else if (exoSuit)
            {
                var type = exoSuit.GetType().Equals(typeof(Exosuit)) ? "Prawn Suit" : "Prawn Suit";
                pState = "Piloting " + type;
                smallImage = type.ToLower();
            }
            else if (seatruck)
            {
                var type = seatruck.GetType().Equals(typeof(SeaTruckMotor)) ? "Seatruck" : "Seatruck";
                pState = "Piloting " + type;
                smallImage = type.ToLower();

            }
            else if (snowfox)
            {
                var type = snowfox.GetType().Equals(typeof(Hoverbike)) ? "Snowfox" : "Snowfox";
                pState = "Piloting " + type;
                smallImage = type.ToLower();
            }
            else if (seaglide)
            {
                var type = seaglide.GetType().Equals(typeof(Seaglide)) ? "Seaglide" : "Seaglide";
                pState = "Piloting " + type;
                smallImage = type.ToLower();
            }
            else if (Player.main.IsUnderwaterForSwimming())
            {
                pState = "Swimming";
                smallImage = "fins";
            }
            else if (!Player.main.IsSwimming())
            {
                pState = "On Foot ";
                smallImage = "";
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


