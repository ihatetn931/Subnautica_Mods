using SMLHelper.V2.Interfaces;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace WaterFoodHotkeyBZ
{
    [Menu("Water/Food/Health Hotkeys", SaveOn = MenuAttribute.SaveEvents.ChangeValue, LoadOn = MenuAttribute.LoadEvents.MenuRegistered)]
    public class Config : ConfigFile
    {
        [Toggle("Toggle Water Hotkey", Id = "WaterHotKey"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleWater = true;
        [Toggle("Toggle Food Hotkey", Id = "FoodHotKey"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleFood = true;
        [Toggle("Toggle Healthpack Hotkey", Id = "MedicHotKey"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleHealth = true;

        [Keybind("Water Hotkey", Id = "WaterHotKey"), OnChange(nameof(KeyBindChangeEvent))]
        public KeyCode SetWaterHotkey = KeyCode.K;
        [Keybind("Food Hotkey", Id = "FoodHotKey"), OnChange(nameof(KeyBindChangeEvent))]
        public KeyCode SetFoodHotkey = KeyCode.L;
        [Keybind("Medic Hotkey", Id = "MedicHotKey"), OnChange(nameof(KeyBindChangeEvent))]
        public KeyCode SetMedHotkey = KeyCode.H;

        [Choice("Text Style", "Standard", "Fancy"), OnChange(nameof(TextStyleChangeEvent))]
        public string Text = "Standard";

        [Slider("Water %", 1, 100, DefaultValue = 50, Id = "WaterPercentage"), OnChange(nameof(SliderChangeEvent))]
        public float WaterPercent = 50;
        [Slider("Food %", 1, 100, DefaultValue = 50, Id = "FoodPercentage"), OnChange(nameof(SliderChangeEvent))]
        public float FoodPercent = 50;
        [Slider("Health %", 1, 100, DefaultValue = 50, Id = "HealthPercentage"), OnChange(nameof(SliderChangeEvent))]
        public float HealthPercent = 50;

        private void CheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "WaterHotKey":
                    MainPatch.ToggleWaterHotKey = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
                case "FoodHotKey":
                    MainPatch.ToggleFoodHotKey = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
                case "MedicHotKey":
                    MainPatch.ToggleMedHotKey = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
            }
        }

        private void KeyBindChangeEvent(KeybindChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "WaterHotKey":
                    MainPatch.WaterHotKey = e.Key;
                    break;
                case "FoodHotKey":
                    MainPatch.FoodHotKey = e.Key;
                    break;
                case "MedHotKey":
                    MainPatch.MedHotKey = e.Key;
                    break;
            }
        }

        private void SliderChangeEvent(SliderChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "WaterPercentage":
                    MainPatch.WaterPercentage = e.Value;
                    break;
                case "FoodPercentage":
                    MainPatch.FoodPercentage = e.Value;
                    break;
                case "HealthPercentage":
                    MainPatch.HealthPercentage = e.Value;
                    break;
            }
        }

        private void TextStyleChangeEvent(ChoiceChangedEventArgs e)
        {
            switch(e.Value)
            {
                case "Standard":
                    MainPatch.TextValue = "Standard";
                    break;
                case "Fancy":
                    MainPatch.TextValue = "Fancy";
                    break;
            }
        }
       /* private void MyGenericValueChangedEvent(IModOptionEventArgs e)
        {
            QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, "Generic value changed!");
            QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"{e.Id}: {e.GetType()}");

            switch (e)
            {
                case KeybindChangedEventArgs keybindChangedEventArgs:
                    QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, keybindChangedEventArgs.KeyName);
                    break;
                case ChoiceChangedEventArgs choiceChangedEventArgs:
                    QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, $"{choiceChangedEventArgs.Index}: {choiceChangedEventArgs.Value}");
                    break;
                case SliderChangedEventArgs sliderChangedEventArgs:
                    QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, sliderChangedEventArgs.Value.ToString());
                    break;
                case ToggleChangedEventArgs toggleChangedEventArgs:
                    QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, toggleChangedEventArgs.Value.ToString());
                    break;
            }
        }*/
    }
}
/*public static class Config
    {

        public static KeyCode WaterHotKey;
        public static KeyCode FoodHotKey;
        public static KeyCode MedHotKey;

        public static int TextValue;

        public static bool ToggleWaterHotKey;
        public static bool ToggleFoodHotKey;
        public static bool ToggleMedHotKey;

        public static float WaterPercentage;
        public static float FoodPercentage;
        public static float HealthPercentage;

        public static void Load()
        {
            //ChoiceIndex = PlayerPrefs.GetInt("SMLHelperExampleModChoice", 0);

            WaterHotKey = PlayerPrefsExtra.GetKeyCode("WaterHotKey", KeyCode.K);
            FoodHotKey = PlayerPrefsExtra.GetKeyCode("FoodHotKey", KeyCode.L);
            MedHotKey = PlayerPrefsExtra.GetKeyCode("MedHotKey", KeyCode.H);

            TextValue = PlayerPrefs.GetInt("TextValue", 0);

            ToggleWaterHotKey = PlayerPrefsExtra.GetBool("ToggleWaterHotKey", true);
            ToggleFoodHotKey = PlayerPrefsExtra.GetBool("ToggleFoodHotKey", true);
            ToggleMedHotKey = PlayerPrefsExtra.GetBool("ToggleMedHotKey", true);

            WaterPercentage = PlayerPrefs.GetFloat("WaterPercentage", 99);
            FoodPercentage = PlayerPrefs.GetFloat("FoodPercentage", 99);
            HealthPercentage = PlayerPrefs.GetFloat("HealthPercentage", 50);
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
        else if (e.Id == "medhotkey")
        {
            Config.MedHotKey = e.Key;
            PlayerPrefsExtra.SetKeyCode("MedHotKey", e.Key);
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
        else if (e.Id == "healthpercentage")
        {
            Config.HealthPercentage = e.Value;
            PlayerPrefs.SetFloat("HealthPercentage", e.Value);
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
        else if (e.Id == "togglemedhotkey")
        {
            Config.ToggleMedHotKey = e.Value;
            PlayerPrefsExtra.SetBool("ToggleMedHotKey", e.Value);
        }
    }

    public override void BuildModOptions()
    {

        AddKeybindOption("waterhotkey", "Water Hotkey", GameInput.Device.Keyboard, Config.WaterHotKey);
        AddKeybindOption("foodhotkey", "Food Hotkey", GameInput.Device.Keyboard, Config.FoodHotKey);
        AddKeybindOption("medhotkey", "Med Hotkey", GameInput.Device.Keyboard, Config.MedHotKey);

        AddChoiceOption("textvalue", "Text Value", new string[] { "Default", "Fancy" }, Config.TextValue);

        AddToggleOption("togglewaterhotkey", "Toggle Water Hotkey", Config.ToggleWaterHotKey);
        AddToggleOption("togglefoodhotkey", "Toggle Food Hotkey", Config.ToggleFoodHotKey);
        AddToggleOption("togglemedhotkey", "Toggle Med Hotkey", Config.ToggleMedHotKey);

        AddSliderOption("waterpercentage", "Water Percentage", 1, 99, Config.WaterPercentage);
        AddSliderOption("foodpercentage", "Food Percentage", 1, 99, Config.FoodPercentage);
        AddSliderOption("healthpercentage", "Health Percentage", 1, 99, Config.HealthPercentage);
    }
}*/
