/*using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using System;
using UnityEngine;
using QModManager.API;


namespace BetterSeaglideBZ
{
    public static class Config
    {
        public static SerializableColor FlashLightColor = new Color(0.016f,1.0f,1.0f);
        public static SerializableColor MapColor = new Color (0.226f, 0.567f, 0.853f, 1.0f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float seagliderValue;
        public static float seaglidegValue;
        public static float seaglidebValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static float spotAngle;
        public static bool SeaGlideColor;
        public static void Load()
        {
            rValue = PlayerPrefs.GetFloat("R", 0.016f);
            gValue = PlayerPrefs.GetFloat("G", 1.000f);
            bValue = PlayerPrefs.GetFloat("B", 1.000f);
            //Intensity = PlayerPrefs.GetFloat("Intensity", 0.9f);
            Intensity = PlayerPrefs.GetFloat("Intensity", 9f);
            Range = PlayerPrefs.GetFloat("Range", 40f);
            spotAngle = PlayerPrefs.GetFloat("Size", 70f);
            ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);
            SeaGlideColor = PlayerPrefsExtra.GetBool("SeaGlideColor", false);
            seagliderValue = PlayerPrefs.GetFloat("SeaglideR", 0.016f);
            seaglidegValue = PlayerPrefs.GetFloat("SeaglideG", 1.000f);
            seaglidebValue = PlayerPrefs.GetFloat("SeaglideB", 1.000f);

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
            else if (e.Id == "seaglidecolor")
            {
                Config.SeaGlideColor = e.Value;
                PlayerPrefsExtra.SetBool("SeaGlideColor", e.Value);
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
                QModServices.Main.AddCriticalMessage($"Intensity: {e.Value}");
                PlayerPrefs.SetFloat("Intensity", e.Value);
            }
            else if (e.Id == "range")
            {
                Config.Range = e.Value;
                QModServices.Main.AddCriticalMessage($"Range: {e.Value}");
                PlayerPrefs.SetFloat("Range", e.Value);
            }
            else if (e.Id == "size")
            {
                Config.spotAngle = e.Value;
                QModServices.Main.AddCriticalMessage($"spotAngle: {e.Value}");
                PlayerPrefs.SetFloat("Size", e.Value);
            }
            else if (e.Id == "seaglider")
            {
                Config.seagliderValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideR", e.Value);
            }
            else if (e.Id == "seaglideg")
            {
                Config.seaglidegValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideG", e.Value);
            }
            else if (e.Id == "seaglideb")
            {
                Config.seaglidebValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideB", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            if (Config.ToggleColor && Config.SeaGlideColor == false)
            {
                AddToggleOption("toggleColor", "BetteSeaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("r", "Red", 0, 255, Config.rValue);
                AddSliderOption("g", "Green", 0, 255, Config.gValue);
                AddSliderOption("b", "Blue", 0, 255, Config.bValue);
               // AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0f, 1f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                Config.Load();

            }
            else if(Config.SeaGlideColor && Config.ToggleColor == false)
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, Config.seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, Config.seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255, Config.seaglidebValue);
                //AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0f, 1f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                Config.Load();
            }
            else if( Config.ToggleColor & Config.SeaGlideColor)
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                AddSliderOption("r", "Red", 0, 255, Config.rValue);
                AddSliderOption("g", "Green", 0, 255, Config.gValue);
                AddSliderOption("b", "Blue", 0, 255, Config.bValue);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, Config.seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, Config.seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255, Config.seaglidebValue);
               // AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0f, 1f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                Config.Load();

            }
            else
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", Config.ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", Config.SeaGlideColor);
                //AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0f, 1f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                Config.Load();
            }
        }
    }
}*/