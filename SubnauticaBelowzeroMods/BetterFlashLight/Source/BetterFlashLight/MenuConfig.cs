using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BetterFlashLightBZ
{
    public static class ConfigMenu
    {
        public static SerializableColor FlashLightColor = Color.white;
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;

        public static void Load()
        {
            rValue = PlayerPrefs.GetFloat("R", 0.996f);
            gValue = PlayerPrefs.GetFloat("G", 0.942f);
            bValue = PlayerPrefs.GetFloat("B", 0.819f);
            Intensity = PlayerPrefs.GetFloat("Intensity", 1.000f);
            Range = PlayerPrefs.GetFloat("Range", 50.000f);
            ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Flash Light Color")
        {
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            if (e.Id == "toggleColor")
            {
                ConfigMenu.ToggleColor = e.Value;
                PlayerPrefsExtra.SetBool("ToggleColor", e.Value);
            }
        }

        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "r")
            {
                ConfigMenu.rValue = e.Value;
                PlayerPrefs.SetFloat("R", e.Value);
            }
            else if (e.Id == "g")
            {
                ConfigMenu.gValue = e.Value;
                PlayerPrefs.SetFloat("G", e.Value);
            }
            else if (e.Id == "b")
            {
                ConfigMenu.bValue = e.Value;
                PlayerPrefs.SetFloat("B", e.Value);
            }
            else if (e.Id == "intensity")
            {
                ConfigMenu.Intensity = e.Value;
                PlayerPrefs.SetFloat("Intensity", e.Value);
            }
            else if (e.Id == "range")
            {
                ConfigMenu.Range = e.Value;
                PlayerPrefs.SetFloat("Range", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            if (ConfigMenu.ToggleColor)
            {
                AddToggleOption("toggleColor", "Better Flashlight Enabled", ConfigMenu.ToggleColor);
                AddSliderOption("r", "Red", 0.0f, 1.000f, (float)Math.Ceiling(ConfigMenu.rValue));
                AddSliderOption("g", "Green", 0.0f, 1.000f, (float)Math.Ceiling(ConfigMenu.gValue));
                AddSliderOption("b", "Blue", 0.0f, 1.000f, (float)Math.Ceiling(ConfigMenu.bValue));
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, ConfigMenu.Intensity);
                AddSliderOption("range", "Light Range", 50.000f, 100.000f, ConfigMenu.Range);
                ConfigMenu.Load();
            }
            else
            {
                AddToggleOption("toggleColor", "Better Flashlight Enabled", ConfigMenu.ToggleColor);
                ConfigMenu.Load();
            }
        }
    }
}