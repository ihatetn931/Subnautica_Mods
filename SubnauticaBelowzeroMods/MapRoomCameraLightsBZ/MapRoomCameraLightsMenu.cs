using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using UnityEngine;

namespace MapRoomCameraLightsBZ
{

    [Menu("Scanner Room Camera Lights", SaveOn = MenuAttribute.SaveEvents.ChangeValue, LoadOn = MenuAttribute.LoadEvents.MenuRegistered)]
    public class Config : ConfigFile
    {
        [Toggle("Scanner Room Camera Lights", Id = "ToggleScannerRoomLights"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleScannerRoomCameraLughts = true;

        [Slider("Scanner Room Camera Light Brightness", 0.000f, 1.999f, DefaultValue = 0.9f, Id = "ScannerCameraLightBrightness", Step = 0.001f, Tooltip = "Test", Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float MapIntensity = 0.9f;
        [Slider("Scanner Room Camera Light Range", 40, 100, DefaultValue = 40, Id = "ScannerCameraLightRange"), OnChange(nameof(SliderChangeEvent))]
        public float MapRange = 40;
        [Slider("Scanner Room Camera Light Cone Size", 70, 120, DefaultValue = 70, Id = "ScannerCameraLightConeSize"), OnChange(nameof(SliderChangeEvent))]
        public float MapspotAngle = 70;

        private void CheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "ToggleAltSymbol":
                    MainPatch.Toggle = e.Value;
                    break;
            }
        }

        private void SliderChangeEvent(SliderChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "ScannerCameraLightBrightness":
                    MainPatch.Intensity = e.Value;
                    break;
                case "ScannerCameraLightRange":
                    MainPatch.Range = e.Value;
                    break;
                case "ScannerCameraLightConeSize":
                    MainPatch.spotAngle = e.Value;
                    break;
            }
        }
    }
}