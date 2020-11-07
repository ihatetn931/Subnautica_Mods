/*using QModManager.API.ModLoading;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using UnityEngine;
using Logger = QModManager.Utility.Logger;

namespace BetterSeaglideBZ
{
    public class Options : ModOptions
    {
        public static SerializableColor FlashLightColor = new Color(0.016f, 1.0f, 1.0f);
        public static SerializableColor MapColor = new Color(0.226f, 0.567f, 0.853f, 1.0f);
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
        public Options() : base("BetterSeaglide Options")
        {
            ToggleChanged += Options_ToggleChanged;
            SliderChanged += Options_SliderChanged;
        }

        /*public override void BuildModOptions()
        {
            AddToggleOption("toggle_id", "My toggle", true);
            AddSliderOption("test_id", "Test", 0.001f, 1.999f, 0.9f);
        }

        public override void BuildModOptions()
        {
            if (ToggleColor && SeaGlideColor == false)
            {
                AddToggleOption("toggleColor", "BetteSeaglide Light Color Enabled", ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", SeaGlideColor);
                AddSliderOption("r", "Red", 0, 255, rValue);
                AddSliderOption("g", "Green", 0, 255, gValue);
                AddSliderOption("b", "Blue", 0, 255, bValue);
                // AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0f, 1, Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, spotAngle);
                //Load();

            }
            else if (SeaGlideColor && ToggleColor == false)
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", SeaGlideColor);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255,seaglidebValue);
                //AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0, 1, Intensity);
                AddSliderOption("range", "Light Range", 40, 100, Range);
                AddSliderOption("size", "Light Cone Size", 70, 120, spotAngle);
               // Config.Load();
            }
            else if (ToggleColor & SeaGlideColor)
            {
                AddToggleOption("toggleColor", "Better Seaglide Light Color Enabled", ToggleColor);
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", SeaGlideColor);
                AddSliderOption("r", "Red", 0, 255, rValue);
                AddSliderOption("g", "Green", 0, 255, gValue);
                AddSliderOption("b", "Blue", 0, 255, bValue);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255, seaglidebValue);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Intensity);
                AddSliderOption("range", "Light Range", 40, 100, Range);
                AddSliderOption("size", "Light Cone Size", 70, 120, spotAngle);
                //Config.Load();

            }
            else
            {
                AddToggleOption("toggleColor", "BetterSeaglide Show/Enable Light RGB Sliders", ToggleColor);
                AddToggleOption("seaglidecolor", "BetterSeaglide Show Color RGB Sliders", SeaGlideColor);
                //AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, Config.Intensity);
                AddSliderOption("intensity", "Light Brightness", 0, 1, Intensity);
                AddSliderOption("range", "Light Range", 40, 100, Range);
                AddSliderOption("size", "Light Cone Size", 70, 120, spotAngle);
                //Config.Load();
            }
        }

        private void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            //Logger.Log(Logger.Level.Info, "checkbox was toggled!");
           // Logger.Log(Logger.Level.Info, $"{e.Id}");

            switch (e.Id)
            {
                case "toggleColor":
                    ToggleColor = e.Value;
                   // Logger.Log(Logger.Level.Info, $"My toggleColor new value: {ToggleColor}");
                    break;
                case "seaglidecolor":
                    SeaGlideColor = e.Value;
                  //  Logger.Log(Logger.Level.Info, $"My seaglidecolor new value: {SeaGlideColor}");
                    break;
            }
        }

        private void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            //Logger.Log(Logger.Level.Info, "slider was slid!");
           // Logger.Log(Logger.Level.Info, $"{e.Id}");

            switch (e.Id)
            {
                case "r":
                    seagliderValue = e.Value;
                    Logger.Log(Logger.Level.Info, $"My SeaglideR new value: {seagliderValue}");
                    break;
                case "g":
                    seaglidegValue = e.Value;
                    Logger.Log(Logger.Level.Info, $"My SeaglideG new value: {seaglidegValue}");
                    break;
                case "b":
                    seaglidebValue = e.Value;
                    Logger.Log(Logger.Level.Info, $"My SeaglideB new value: {e.Value}");
                    break;
            }
        }
    }
}*/