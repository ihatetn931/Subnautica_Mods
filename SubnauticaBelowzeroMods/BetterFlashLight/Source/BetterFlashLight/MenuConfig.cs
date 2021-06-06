using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using UnityEngine.UI;

namespace BetterFlashLightBZ
{
    [Menu("BetterFlashLight Options", SaveOn = MenuAttribute.SaveEvents.ChangeValue)]
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
                    break;
                case "FlashLightOptions":
                    MainPatch.ToggleOptions = e.Value;
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
  