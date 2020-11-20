namespace SeatruckDockRepairCharge
{

    using HarmonyLib;
    using SMLHelper.V2.Interfaces;
    using SMLHelper.V2.Json;
    using SMLHelper.V2.Options;
    using SMLHelper.V2.Options.Attributes;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Logger = QModManager.Utility.Logger;

    [Menu("Seaturck Docking Module Options")]
    [ConfigFile("settings")]
    public class MenuConfig : ConfigFile 
    {
       
       // public static bool Repair;
       // public static bool Charge;


        //    [Toggle("Toggle Repair", Id = "RepairToggle"), OnChange(nameof(CheckboxToggleEvent))]
        //   public bool ToggleRepair = true;
        //    [Toggle("Toggle Charge", Id = "ChargeToggle"), OnChange(nameof(CheckboxToggleEvent))]
        //    public bool ToggleCharge = true;

        [Slider("Repair Value", 0.001f, 1.000f, DefaultValue = 0.025f, Id = "RepairValue", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float RepairValueSetting = 0.025f;

        [Slider("Charge Value", 0.001f, 1.000f, DefaultValue = 0.025f, Id = "ChargeValue", Step = 0.001f, Format = "{0:F3}"), OnChange(nameof(SliderChangeEvent))]
        public float ChargeValueSetting = 0.025f;

    /*    private void CheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "RepairToggle":
                    Repair = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
                case "ChargeToggle":
                    Charge = e.Value;
                    //Logger.Log(Logger.Level.Info, $"[LightColor] Id:{e.Id}  Value:{e.Value}");
                    break;
            }
        }*/
        private void SliderChangeEvent(SliderChangedEventArgs e)
        {
            switch (e.Id)
            {
                case "RepairValue":
                    MainPatch.RepairValue = e.Value;
                    break;
                case "ChargeValue":
                    MainPatch.ChargeValue = e.Value;
                    break;
            }
           // MainPatch.DockingModule.SaveWithConverters();
        }
    }
}
