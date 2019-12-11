using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace DockLightsToggle
{
    public static class Config
    {
        //public static int ChoiceIndex;
        //public static KeyCode KeybindKey;
        //public static float SliderValue;
        public static bool ToggleValue;

        public static void Load()
        {
            //ChoiceIndex = PlayerPrefs.GetInt("SMLHelperExampleModChoice", 0);
            //KeybindKey = PlayerPrefsExtra.GetKeyCode("SMLHelperExampleModKeybind", KeyCode.X);
            //SliderValue = PlayerPrefs.GetFloat("SMLHelperExampleModSlider", 50f);
            ToggleValue = MainPatch.state.SeaTruckLightState; //PlayerPrefsExtra.GetBool("SeaTruckLightState", false);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Docking Lights Toggle")
        {
            //ChoiceChanged += Options_ChoiceChanged;
            //KeybindChanged += Options_KeybindChanged;
            //SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }

        /*public void Options_ChoiceChanged(object sender, ChoiceChangedEventArgs e)
        {
            if (e.Id != "exampleChoice") return;
            Config.ChoiceIndex = e.Index;
            PlayerPrefs.SetInt("SMLHelperExampleModChoice", e.Index);
        }
        public void Options_KeybindChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id != "exampleKeybind") return;
            Config.KeybindKey = e.Key;
            PlayerPrefsExtra.SetKeyCode("SMLHelperExampleModKeybind", e.Key);
        }
        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id != "exampleSlider") return;
            Config.SliderValue = e.Value;
            PlayerPrefs.SetFloat("SMLHelperExampleModSlider", e.Value);
        }*/
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            if (e.Id == "lightstate")
            {
                Config.ToggleValue = e.Value;
                MainPatch.state.SeaTruckLightState = e.Value;
                //PlayerPrefsExtra.SetBool("SeaTruckLightState", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            //AddChoiceOption("exampleChoice", "Choice", new string[] { "Choice 1", "Choice 2", "Choice 3" }, Config.ChoiceIndex);
            //AddKeybindOption("exampleKeybind", "Keybind", GameInput.Device.Keyboard, Config.KeybindKey);
            //AddSliderOption("exampleSlider", "Slider", 0, 100, Config.SliderValue);
            AddToggleOption("lightstate", "Toggle Seatruck Light Sate on Undock", Config.ToggleValue);
        }
    }
}