using SMLHelper.V2.Interfaces;
using SMLHelper.V2.Json;
using SMLHelper.V2.Options;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace BelowZeroAltMeter
{
    [Menu("Altitude Meter", SaveOn = MenuAttribute.SaveEvents.ChangeValue, LoadOn = MenuAttribute.LoadEvents.MenuRegistered)]
    public class Config : ConfigFile
    {
        [Toggle("Toggle Altitude Symbol", Id = "ToggleAltSymbol"), OnChange(nameof(CheckboxToggleEvent))]
        public bool ToggleAltSymbol = true;

        private void CheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "ToggleAltSymbol":
                    MainPatch.ToggleSymbol = e.Value;
                    break;
            }
        }

    }
}