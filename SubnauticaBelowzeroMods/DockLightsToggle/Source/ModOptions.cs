using SMLHelper.V2.Handlers;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace DockLightsToggleBZ
{
    public static class Config
    {
        public static bool ToggleValue;

        public static void Load()
        {

            ToggleValue = MainPatch.state.SeaTruckLightState;
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Docking Lights Toggle")
        {
            ToggleChanged += Options_ToggleChanged;
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            if (e.Id == "lightstate")
            {
                Config.ToggleValue = e.Value;
                MainPatch.state.SeaTruckLightState = e.Value;

            }
        }

        public override void BuildModOptions()
        {
            AddToggleOption("lightstate", "Toggle Seatruck Light Sate on Undock", Config.ToggleValue);
        }
    }
}