using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace BetterFlashLightBZ
{
    public static class Config
    {
        public static SerializableColor FlashLightColor = Color.white;
        //public static SerializableColor SeamothLeft = Color.white;
        //public static SerializableColor SeamothRight = Color.white;
        //public static SerializableColor PrawnsuitLeft = Color.white;
        //public static SerializableColor PrawnsuitRight = Color.white;
        //public static int ChoiceIndex;
        //public static KeyCode KeybindKey;
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float Range;
        //public static float intensity;
        public static bool ToggleColor;



        public static void Load()
        {
            //ChoiceIndex = PlayerPrefs.GetInt("SMLHelperExampleModChoice", 0);
            //KeybindKey = PlayerPrefsExtra.GetKeyCode("SMLHelperExampleModKeybind", KeyCode.X);
            rValue = PlayerPrefs.GetFloat("R", 0.996f);
            gValue = PlayerPrefs.GetFloat("G", 0.942f);
            bValue = PlayerPrefs.GetFloat("B", 0.819f);
            Range = PlayerPrefs.GetFloat("Range", 1.000f);
            //intensity = PlayerPrefs.GetFloat("Intensity", 1.000f);
            ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Flash Light Color")
        {
            //ChoiceChanged += Options_ChoiceChanged;
            //KeybindChanged += Options_KeybindChanged;
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }

        /*public void Options_ChoiceChanged(object sender, ChoiceChangedEventArgs e)
        {
            if (e.Id != "exampleChoice") return;
            Config.ChoiceIndex = e.Index;
            PlayerPrefs.SetInt("SMLHelperExampleModChoice", e.Index);
        }*/
            public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
            { 
            if (e.Id == "toggleColor")
            {
                Config.ToggleColor = e.Value;
                PlayerPrefsExtra.SetBool("ToggleColor", e.Value);
            }
        }
        /*public void Options_KeybindChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id != "exampleKeybind") return;
            Config.KeybindKey = e.Key;
            PlayerPrefsExtra.SetKeyCode("SMLHelperExampleModKeybind", e.Key);
        }*/
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
            else if (e.Id == "range")
            {
                Config.Range = e.Value;
                PlayerPrefs.SetFloat("Range", e.Value);
            }
            /*else if (e.Id == "intensity")
            {
                Config.intensity = e.Value;
                PlayerPrefs.SetFloat("Intensity", e.Value);
            }*/
        }

        public override void BuildModOptions()
        {
            if (Config.ToggleColor)
            {
                //AddChoiceOption("exampleChoice", "Choice", new string[] { "Choice 1", "Choice 2", "Choice 3" }, Config.ChoiceIndex);
                //AddKeybindOption("exampleKeybind", "Keybind", GameInput.Device.Keyboard, Config.KeybindKey);
                AddToggleOption("toggleColor", "Better Flashlight Enabled", Config.ToggleColor);
                AddSliderOption("r", "Red", 0.0f, 1.000f, Config.rValue);
                AddSliderOption("g", "Green", 0.0f, 1.000f, Config.gValue);
                AddSliderOption("b", "Blue", 0.0f, 1.000f, Config.bValue);
                AddSliderOption("range", "Light Brightness", 0.000f, 1.999f, Config.Range);
                //AddSliderOption("intensity", "Intensity", 0.0f, 2.000f, Config.intensity);
                //AddToggleOption("lightstate", "Toggle Seatruck Light Sate on Undock", Config.ToggleValue);
            }
            else
            {
                AddToggleOption("toggleColor", "Better Flashlight Enabled", Config.ToggleColor);

            }
        }
    }
}