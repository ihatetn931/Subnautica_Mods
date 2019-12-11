using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace WaterFoodHotkey
{
    public static class Config
    {

        public static KeyCode WaterHotKey;
        public static KeyCode FoodHotKey;

        public static int TextValue;

        public static bool ToggleWaterHotKey;
        public static bool ToggleFoodHotKey;

        public static float WaterPercentage;
        public static float FoodPercentage;

        public static void Load()
        {
            //ChoiceIndex = PlayerPrefs.GetInt("SMLHelperExampleModChoice", 0);

            WaterHotKey = PlayerPrefsExtra.GetKeyCode("WaterHotKey", KeyCode.K);
            FoodHotKey = PlayerPrefsExtra.GetKeyCode("FoodHotKey", KeyCode.L);

            TextValue = PlayerPrefs.GetInt("TextValue", 0);

            ToggleWaterHotKey = PlayerPrefsExtra.GetBool("ToggleWaterHotKey", true);
            ToggleFoodHotKey = PlayerPrefsExtra.GetBool("ToggleFoodHotKey", true);

            WaterPercentage = PlayerPrefs.GetFloat("WaterPercentage", 99.0f);
            FoodPercentage = PlayerPrefs.GetFloat("FoodPercentage", 99.0f);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("WaterFoodHotKey")
        {
            ChoiceChanged += Options_ChoiceChanged;
            KeybindChanged += Options_KeybindChanged;
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }

        public void Options_ChoiceChanged(object sender, ChoiceChangedEventArgs e)
        {
            if (e.Id == "textvalue")
            {
                Config.TextValue = e.Index;
                PlayerPrefs.SetInt("TextValue", e.Index);
            }
        }
        public void Options_KeybindChanged(object sender, KeybindChangedEventArgs e)
        {
            if (e.Id == "waterhotkey")
            {
                Config.WaterHotKey = e.Key;
                PlayerPrefsExtra.SetKeyCode("WaterHotKey", e.Key);
            }
            else if (e.Id == "foodhotkey")
            {
                Config.FoodHotKey = e.Key;
                PlayerPrefsExtra.SetKeyCode("FoodHotKey", e.Key);
            }
        }
        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "waterpercentage")
            {
                Config.WaterPercentage = e.Value;
                PlayerPrefs.SetFloat("WaterPercentage", e.Value);
            }
            else if (e.Id == "foodpercentage")
            {
                Config.FoodPercentage = e.Value;
                PlayerPrefs.SetFloat("FoodPercentage", e.Value);
            }
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            if (e.Id == "togglewaterhotkey")
            {
                Config.ToggleWaterHotKey = e.Value;
                PlayerPrefsExtra.SetBool("ToggleWaterHotKey", e.Value);
            }
            else if (e.Id == "togglefoodhotkey")
            {
                Config.ToggleFoodHotKey = e.Value;
                PlayerPrefsExtra.SetBool("ToggleFoodHotKey", e.Value);
            }
        }

        public override void BuildModOptions()
        {

            AddKeybindOption("waterhotkey", "Water Hotkey", GameInput.Device.Keyboard, Config.WaterHotKey);
            AddKeybindOption("foodhotkey", "Food Hotkey", GameInput.Device.Keyboard, Config.FoodHotKey);

            AddChoiceOption("textvalue", "Text Value", new string[] { "Default", "Fancy" }, Config.TextValue);

            AddToggleOption("togglewaterhotkey", "Toggle Water Hotkey", Config.ToggleWaterHotKey);
            AddToggleOption("togglefoodhotkey", "Toggle Food Hotkey", Config.ToggleFoodHotKey);

            AddSliderOption("waterpercentage", "Water Percentage", 1, 99, Config.WaterPercentage);
            AddSliderOption("foodpercentage", "Food Percentage", 1, 99, Config.FoodPercentage);

        }
    }
}
