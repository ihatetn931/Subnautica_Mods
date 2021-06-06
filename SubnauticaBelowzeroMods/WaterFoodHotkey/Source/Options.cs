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
        [Toggle("Toggle Food/Drink Hotkey", Id = "ToggleFoodDrinkHotKey"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleFoodDrink = true;
        [Toggle("Toggle Healthpack Hotkey", Id = "ToggleMedicHotKey"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleHealth = true;
        [Toggle("Toggle Heat Hotkey", Id = "ToggleHeatHotKey"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleHeat = true;

        [Keybind("Food/Drink Hotkey", Id = "FoodDrinkHotKey"), OnChange(nameof(KeyBindChangeEvent))]
        public KeyCode SetFoodDrinkHotKey = KeyCode.K;
        [Keybind("Medic Hotkey", Id = "MedicHotKey"), OnChange(nameof(KeyBindChangeEvent))]
        public KeyCode SetMedHotkey = KeyCode.H;
        [Keybind("Heat Hotkey", Id = "HeatHotKey"), OnChange(nameof(KeyBindChangeEvent))]
        public KeyCode SetHeatHotKey = KeyCode.L;

        [Choice("Text Style", "Standard", "Subtitles"), OnChange(nameof(TextStyleChangeEvent))]
        public string Text = "Standard";

        [Slider("Food/Drink %", 1, 100, DefaultValue = 50, Id = "FoodDrinkPercentage"), OnChange(nameof(SliderChangeEvent))]
        public float FoodDrinkPercent = 50;
        [Slider("Health %", 1, 100, DefaultValue = 50, Id = "HealthPercentage"), OnChange(nameof(SliderChangeEvent))]
        public float HealthPercent = 50;
        [Slider("Heat %", 1, 100, DefaultValue = 50, Id = "HeatPercentage"), OnChange(nameof(SliderChangeEvent))]
        public float HeatPercent = 50;

        private void CheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "ToggleFoodDrinkHotKey":
                    MainPatch.ToggleFoodDrink = e.Value;
                    break;
                case "ToggleMedicHotKey":
                    MainPatch.ToggleMedHotKey = e.Value;
                    break;
                case "ToggleHeatHotKey":
                    MainPatch.ToggleHeatHotKey = e.Value;
                    break;
            }
        }

        private void KeyBindChangeEvent(KeybindChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "WaterHotKey":
                    MainPatch.FoodDrinkHotKey = e.Key;
                    break;
                case "MedHotKey":
                    MainPatch.MedHotKey = e.Key;
                    break;
                case "HeatHotKey":
                    MainPatch.HeatHotkey = e.Key;
                    break;
            }
        }

        private void SliderChangeEvent(SliderChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "WaterPercentage":
                    MainPatch.FoodDrinkPercentage = e.Value;
                    break;
                case "HealthPercentage":
                    MainPatch.HealthPercentage = e.Value;
                    break;
                case "HeatPercentage":
                    MainPatch.HeatPercentage = e.Value;
                    break;
            }
        }

        private void TextStyleChangeEvent(ChoiceChangedEventArgs e)
        {
            switch (e.Value)
            {
                case "Standard":
                    MainPatch.TextValue = "Standard";
                    break;
                case "Subtitles":
                    MainPatch.TextValue = "Fancy";
                    break;
            }
        }
    }
}