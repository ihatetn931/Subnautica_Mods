using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using System;
using UnityEngine;

namespace BetterSeaglideBZ
{
    public static class Config
    {
        public static SerializableColor FlashLightColor = new Color(0.016f,1.0f,1.0f);
        public static SerializableColor MapColor = new Color (0.226f, 0.567f, 0.853f, 1.0f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float maprValue;
        public static float mapgValue;
        public static float mapbValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static float spotAngle;
        public static float seaglideSpeed;
        public static float mapAlpha;
        public static bool ToggleMapColor;
        public static void Load()
        {
            rValue = PlayerPrefs.GetFloat("R", 0.016f);
            gValue = PlayerPrefs.GetFloat("G", 1.000f);
            bValue = PlayerPrefs.GetFloat("B", 1.000f);
            Intensity = PlayerPrefs.GetFloat("Intensity", 0.9f);
            Range = PlayerPrefs.GetFloat("Range", 40f);
            spotAngle = PlayerPrefs.GetFloat("Size", 70f);
            seaglideSpeed = PlayerPrefs.GetFloat("Speed", 1f);
            ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);

            maprValue = PlayerPrefs.GetFloat("MapR", 0.226f);
            mapgValue = PlayerPrefs.GetFloat("MapG", 0.567f);
            mapbValue = PlayerPrefs.GetFloat("MapB", 0.853f);
            mapAlpha = PlayerPrefs.GetFloat("MapAlpha", 1.0f);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Seaglide Settings")
        {
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
            { 
            if (e.Id == "toggleColor")
            {
                Config.ToggleColor = e.Value;
                PlayerPrefsExtra.SetBool("ToggleColor", e.Value);
            }
            if (e.Id == "toggleMapColor")
            {
                Config.ToggleMapColor = e.Value;
                PlayerPrefsExtra.SetBool("ToggleMapColor", e.Value);
            }
        }

        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "r")
            {
                Config.rValue = e.Value;
                PlayerPrefs.SetFloat("R", e.Value);
            }
            else if (e.Id == "g")
            {
                Config.gValue = e.Value;
                PlayerPrefs.SetFloat("G", e.Value);
            }
            else if (e.Id == "b")
            {
                Config.bValue = e.Value;
                PlayerPrefs.SetFloat("B", e.Value);
            }
            else if (e.Id == "intensity")
            {
                Config.Intensity = e.Value;
                PlayerPrefs.SetFloat("Intensity", e.Value);
            }
            else if (e.Id == "range")
            {
                Config.Range = e.Value;
                PlayerPrefs.SetFloat("Range", e.Value);
            }
            else if (e.Id == "size")
            {
                Config.spotAngle = e.Value;
                PlayerPrefs.SetFloat("Size", e.Value);
            }
            else if (e.Id == "speed")
            {
                Config.seaglideSpeed = e.Value;
                PlayerPrefs.SetFloat("Speed", e.Value);
            }
            else if (e.Id == "mapr")
            {
                Config.maprValue = e.Value;
                PlayerPrefs.SetFloat("MapR", e.Value);
            }
            else if (e.Id == "mapg")
            {
                Config.mapgValue = e.Value;
                PlayerPrefs.SetFloat("MapG", e.Value);
            }
            else if (e.Id == "mapb")
            {
                Config.mapbValue = e.Value;
                PlayerPrefs.SetFloat("MapB", e.Value);
            }
            else if (e.Id == "mapalpha")
            {
                Config.mapAlpha = e.Value;
                PlayerPrefs.SetFloat("MapAlpha", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            if (Config.ToggleColor && Config.ToggleMapColor == false)
            {
                AddToggleOption("toggleColor", "BetteSeaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("toggleMapColor", "BetterSeaglide Map Color Enabled", Config.ToggleMapColor);
                AddSliderOption("r", "Red", 0, 255, Config.rValue);
                AddSliderOption("g", "Green", 0, 255, Config.gValue);
                AddSliderOption("b", "Blue", 0, 255, Config.bValue);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                AddSliderOption("speed", "Seaglide Speed", 1f, 10000f, Config.seaglideSpeed);
                Config.Load();

            }
            else if(Config.ToggleMapColor && Config.ToggleColor == false)
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("toggleMapColor", "Better Seaglide Map Color Enabled", Config.ToggleMapColor);
                AddSliderOption("mapr", "Map Red", 0, 255, Config.maprValue);
                AddSliderOption("mapg", "Map Green", 0, 255, Config.mapgValue);
                AddSliderOption("mapb", "Map Blue", 0, 255, Config.mapbValue);
                AddSliderOption("mapalpha", "Seaglide Map Alpha", 1, 100, Config.mapAlpha);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                AddSliderOption("speed", "Seaglide Speed", 1f, 10000f, Config.seaglideSpeed);
                Config.Load();
            }
            else if( Config.ToggleColor & Config.ToggleMapColor)
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("toggleMapColor", "Better Seaglide Map Color Enabled", Config.ToggleMapColor);
                AddSliderOption("r", "Red", 0, 255, Config.rValue);
                AddSliderOption("g", "Green", 0, 255, Config.gValue);
                AddSliderOption("b", "Blue", 0, 255, Config.bValue);
                AddSliderOption("mapr", "Map Red", 0, 255, Config.maprValue);
                AddSliderOption("mapg", "Map Green", 0, 255, Config.mapgValue);
                AddSliderOption("mapb", "Map Blue", 0, 255, Config.mapbValue);
                AddSliderOption("mapalpha", "Seaglide Map Alpha", 1, 100, Config.mapAlpha);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                AddSliderOption("speed", "Seaglide Speed", 1f, 10000f, Config.seaglideSpeed);
                Config.Load();

            }
            else
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("toggleMapColor", "Better Seaglide Map Color Enabled", Config.ToggleMapColor);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                AddSliderOption("speed", "Seaglide Speed", 1f, 10000f, Config.seaglideSpeed);
                Config.Load();
            }
        }
    }
}