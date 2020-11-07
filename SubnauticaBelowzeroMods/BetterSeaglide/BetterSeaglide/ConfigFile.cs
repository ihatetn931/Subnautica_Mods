
using HarmonyLib;
using SMLHelper.V2.Interfaces;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using Logger = QModManager.Utility.Logger;

namespace BetterSeaglideBZ
{
    [Menu("BetterSeaglide Options",SaveOn =MenuAttribute.SaveEvents.ChangeValue)]
    //[ConfigFile("betterseaglideoptions")]
    public class SeaglideConfig : ConfigFile
    {
        public static SerializableColor FlashLightColor = new Color(0.016f, 1.000f, 1.000f);
        public static SerializableColor SeaglideModelColor = new Color(1.000f, 1.000f, 1.000f);
        public static SerializableColor MapColor = new Color(0.226f, 0.567f, 0.853f, 1.000f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float Intensity;
        public static float Range;
        public static bool ToggleColor;
        public static bool SeaglideColor;
        public static bool SeaglideLightOptions;
        public static float spotAngle;
        public static float seagliderValue;
        public static float seaglidegValue;
        public static float seaglidebValue;

        [Toggle("Enable Seaglide Light Options", Id = "LightOptions"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleSeaglideLightOptions = false;
        [Toggle("Enable Seaglide Light RGB", Id = "LightColor"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleLightColor = false;
        [Toggle("Enable Seaglide Color RGB", Id = "SeaglideColor"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleSeaglideColor = false;

        [Slider("Seaglide Light Brightness", 0.000f, 1.999f, DefaultValue = 0.9f, Id = "LightBrightness", Step = 0.001f, Tooltip = "Test", Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float LightBrightness = 0.9f;
        [Slider("Seaglide Light Range", 40, 100, DefaultValue = 40, Id = "LightRange"), OnChange(nameof(SliderChangeEvent))]
        public float LightRange = 40;
        [Slider("Seaglide Light Cone Size", 70, 120, DefaultValue = 70, Id = "LightConeSize"), OnChange(nameof(SliderChangeEvent))]
        public float LightConeSize = 70;

        [Slider("Seaglide Light Red", 0.001f, 1.000f, DefaultValue = 0.016f, Id = "LightRed", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float SeaglideLightRed = 1.000f;
        [Slider("Seaglide Light Green", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "LightGreen", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float SeaglideLightGreen = 1.000f;
        [Slider("Seaglide Light Blue", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "LightBlue", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float SeaglideLightBlue = 1.000f;

        [Slider("Seaglide Red", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "SeaglideRed", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float SeaglideRed = 1.000f;
        [Slider("Seaglide Green", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "SeaglideGreen", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float SeaglideGreen = 1.000f;
        [Slider("Seaglide Blue", 0.001f, 1.000f, DefaultValue = 1.000f, Id = "SeaglideBlue", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float SeaglideBlue = 1.000f;

        private void CheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "LightColor":
                    ToggleColor = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
                case "SeaglideColor":
                    SeaglideColor = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
                case "LightOptions":
                    SeaglideLightOptions = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
            }
        }

        private void SliderChangeEvent(SliderChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "LightBrightness":
                    Intensity = e.Value;
                    break;
                case "LightRange":
                    Range = e.Value;
                    break;
                case "LightConeSize":
                    spotAngle = e.Value;
                    break;
                case "SeaglideRed":
                    seagliderValue = e.Value;
                    break;
                case "SeaglideGreen":
                    seaglidegValue = e.Value;
                    break;
                case "SeaglideBlue":
                    seaglidebValue = e.Value;
                    break;
                case "LightRed":
                    rValue = e.Value;
                    break;
                case "LightGreen":
                    gValue = e.Value;
                    break;
                case "LightBlue":
                    bValue = e.Value;
                    break;
            }
        }
    }
}
