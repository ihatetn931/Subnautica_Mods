using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace BetterSeaglide.Menus
{
    public static class ConfigWhiteLights
    {
        public static float seagliderValue;
        public static float seaglidegValue;
        public static float seaglidebValue;
        public static float Intensity;
        public static float Range;
        public static float spotAngle;
        public static bool SeaGlideColor;

        public static void Load()
        {
            seagliderValue = PlayerPrefs.GetFloat("SeaglideR", 0.016f);
            seaglidegValue = PlayerPrefs.GetFloat("SeaglideG", 1.000f);
            seaglidebValue = PlayerPrefs.GetFloat("SeaglideB", 1.000f);
            Intensity = PlayerPrefs.GetFloat("Intensity", 0.9f);
            Range = PlayerPrefs.GetFloat("Range", 40f);
            spotAngle = PlayerPrefs.GetFloat("Size", 70f);
            SeaGlideColor = PlayerPrefsExtra.GetBool("SeaGlideColor", false);
        }
    }

    public class OptionsWhiteLights : ModOptions
    {
        public OptionsWhiteLights() : base("BetterSeaglide Settings")
        {
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
            { 

            if (e.Id == "seaglidecolor")
            {
                ConfigWhiteLights.SeaGlideColor = e.Value;
                PlayerPrefsExtra.SetBool("SeaGlideColor", e.Value);
            }
        }

        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {

            if (e.Id == "intensity")
            {
                ConfigWhiteLights.Intensity = e.Value;
                PlayerPrefs.SetFloat("Intensity", e.Value);
            }
            else if (e.Id == "range")
            {
                ConfigWhiteLights.Range = e.Value;
                PlayerPrefs.SetFloat("Range", e.Value);
            }
            else if (e.Id == "size")
            {
                ConfigWhiteLights.spotAngle = e.Value;
                PlayerPrefs.SetFloat("Size", e.Value);
            }
            if (e.Id == "seaglider")
            {
                ConfigWhiteLights.seagliderValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideR", e.Value);
            }
            else if (e.Id == "seaglideg")
            {
                ConfigWhiteLights.seaglidegValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideG", e.Value);
            }
            else if (e.Id == "seaglideb")
            {
                ConfigWhiteLights.seaglidebValue = e.Value;
                PlayerPrefs.SetFloat("SeaglideB", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            if(ConfigWhiteLights.SeaGlideColor)
            {
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", ConfigWhiteLights.SeaGlideColor);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, ConfigWhiteLights.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, ConfigWhiteLights.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, ConfigWhiteLights.spotAngle);
                AddSliderOption("seaglider", "Seaglide Red", 0, 255, ConfigWhiteLights.seagliderValue);
                AddSliderOption("seaglideg", "Seaglide Green", 0, 255, ConfigWhiteLights.seaglidegValue);
                AddSliderOption("seaglideb", "Seaglide Blue", 0, 255, ConfigWhiteLights.seaglidebValue);
                ConfigWhiteLights.Load();
            }
            else
            {
                AddToggleOption("seaglidecolor", "Show BetterSeaglide Color RGB Sliders", ConfigWhiteLights.SeaGlideColor);
                AddSliderOption("intensity", "Light Brightness", 0.000f, 1.999f, ConfigWhiteLights.Intensity);
                AddSliderOption("range", "Light Range", 40f, 100f, ConfigWhiteLights.Range);
                AddSliderOption("size", "Light Cone Size", 70f, 120f, ConfigWhiteLights.spotAngle);
                ConfigWhiteLights.Load();
            }
        }
    }
}