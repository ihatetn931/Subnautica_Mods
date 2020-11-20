using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BetterFlashLightBZ
{

    using HarmonyLib;
    using SMLHelper.V2.Interfaces;
    using SMLHelper.V2.Json;
    using SMLHelper.V2.Options;
    using SMLHelper.V2.Options.Attributes;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Logger = QModManager.Utility.Logger;

        [Menu("BetterFlashLight Options", SaveOn = MenuAttribute.SaveEvents.ChangeValue)]
        //[ConfigFile("betterseaglideoptions")]
        public class FlashLightConfig : ConfigFile
        {
            [Toggle("Enable Flashlight Options", Id = "FlashLightOptions"), OnChange(nameof(CheckboxToggleEvent))]
            public bool ToggleFlashLightOptions = false;
            [Toggle("Enable Flashlight RGB", Id = "FlashLightColor"), OnChange(nameof(CheckboxToggleEvent))]
            public bool ToggleFlashLightColor = false;

            [Slider("FlashLight Brightness", 0.000f, 1.999f, DefaultValue = 0.9f, Id = "FlashLightBrightness", Step = 0.001f, Tooltip = "Test", Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
            public float LightBrightness = 1.0f;
            [Slider("FlashLight Range", 40, 100, DefaultValue = 50, Id = "FlashLightRange"), OnChange(nameof(SliderChangeEvent))]
            public float LightRange = 50;

            [Slider("FlashLight Red", 0.001f, 1.000f, DefaultValue = 0.016f, Id = "FlashLightRed", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
            public float SeaglideLightRed = 1.000f;
            [Slider("FlashLight Green", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "FlashLightGreen", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
            public float SeaglideLightGreen = 1.000f;
            [Slider("FlashLight Blue", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "FlashLightBlue", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
            public float SeaglideLightBlue = 1.000f;



            private void CheckboxToggleEvent(ToggleChangedEventArgs e)
            {
                switch (e.Id)
                {
                    case "FlashLightColor":
                    MainPatch.ToggleColor = e.Value;
                        //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                        break;
                    case "FlashLightOptions":
                    MainPatch.ToggleOptions = e.Value;
                        //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                        break;
                }
            }

            private void SliderChangeEvent(SliderChangedEventArgs e)
            {
                switch (e.Id)
                {
                    case "FlashLightBrightness":
                    MainPatch.Intensity = e.Value;
                        break;
                    case "FlashLightRange":
                    MainPatch.Range = e.Value;
                        break;
                    case "FlashLightRed":
                    MainPatch.rValue = e.Value;
                        break;
                    case "FlashLightGreen":
                    MainPatch.gValue = e.Value;
                        break;
                    case "FlashLightBlue":
                    MainPatch.bValue = e.Value;
                        break;
                }
            }
        }
    }
   /* public static class ConfigMenu
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
}*/