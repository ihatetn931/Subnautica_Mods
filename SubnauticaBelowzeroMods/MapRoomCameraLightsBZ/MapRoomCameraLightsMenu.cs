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
      /*  //public static SerializableColor MapRoomLights = new Color(0.016f, 1.0f, 1.0f);
        //public static float rValue;
        //public static float gValue;
        //public static float bValue;
        public static float MapIntensity;
        public static float MapRange;
        //public static bool ToggleColor;
        public static float MapspotAngle;

        public static void Load()
        {
            //rValue = PlayerPrefs.GetFloat("R", 0.016f);
            //gValue = PlayerPrefs.GetFloat("G", 1.000f);
            //bValue = PlayerPrefs.GetFloat("B", 1.000f);
            MapIntensity = PlayerPrefs.GetFloat("MapLightIntensity", 0.9f);
            MapRange = PlayerPrefs.GetFloat("MapLightRange", 40f);
            MapspotAngle = PlayerPrefs.GetFloat("MapLightSize", 70f);
            //ToggleColor = PlayerPrefsExtra.GetBool("ToggleColor", false);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Map Room Camera Lights Settings")
        {
            SliderChanged += Options_SliderChanged;
            ToggleChanged += Options_ToggleChanged;
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
            { 
          /*  if (e.Id == "toggleColor")
            {
                Config.ToggleColor = e.Value;
                PlayerPrefsExtra.SetBool("ToggleColor", e.Value);
            }
        }

        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            /*if (e.Id == "r")
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
            if (e.Id == "maplightintensity")
            {
                Config.MapIntensity = e.Value;
                PlayerPrefs.SetFloat("MapLightIntensity", e.Value);
            }
            else if (e.Id == "maplightrange")
            {
                Config.MapRange = e.Value;
                PlayerPrefs.SetFloat("MapLightRange", e.Value);
            }
            else if (e.Id == "maplightsize")
            {
                Config.MapspotAngle = e.Value;
                PlayerPrefs.SetFloat("MapLightSize", e.Value);
            }
        }

        public override void BuildModOptions()
        {
            AddSliderOption("maplightintensity", "Light Brightness", 0.000f, 1.999f, Config.MapIntensity);
            AddSliderOption("maplightrange", "Light Range", 40f, 100f, Config.MapRange);
            AddSliderOption("maplightsize", "Light Cone Size", 70f, 130f, Config.MapspotAngle);
            Config.Load();

        }
    }
}*/