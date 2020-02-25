using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace BetterSeaglide
{
    public static class Config
    {
        public static SerializableColor FlashLightColor = new Color(0.016f, 1.0f, 1.0f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static float spotAngle;
        public static float seaglideSpeed;
        public static void Load()
        {
            rValue = PlayerPrefs.GetFloat("R", 0.016f);
            gValue = PlayerPrefs.GetFloat("G", 1.000f);
            bValue = PlayerPrefs.GetFloat("B", 1.000f);
            Intensity = PlayerPrefs.GetFloat("Intensity", 0.9f);
            Range = PlayerPrefs.GetFloat("Range", 40);
            spotAngle = PlayerPrefs.GetFloat("Size", 70);
            ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Seaglide Light Settings")
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
        }

        public override void BuildModOptions()
        {
            if (Config.ToggleColor)
            {
                AddToggleOption("toggleColor", "Better Seaglide Color Enabled", Config.ToggleColor);
                AddSliderOption("r", "Red", 0.0f, 1.000f, Config.rValue);
                AddSliderOption("g", "Green", 0.0f, 1.000f, Config.gValue);
                AddSliderOption("b", "Blue", 0.0f, 1.000f, Config.bValue);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                Config.Load();
            }
            else
            {
                AddToggleOption("toggleColor", "Better Seaglide Color Enabled", Config.ToggleColor);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Config.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, Config.spotAngle);
                Config.Load();
            }
        }
    }
}