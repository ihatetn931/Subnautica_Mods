using HarmonyLib;
using UnityEngine;

namespace JukeBoxMod
{
    public static class JukeboxConfig
    {
        public static bool JBColor;
        public static bool PartyMode;
        public static Color FlashColor0 = new Color(0f, 0f, 0f, 1f);
        public static Color FlashColor1 = new Color(1f, 0f, 0.7f, 1f);
        public static Color FlashColor2 = new Color(1f, 0.4f, 0f, 1f);
    }

    class JukeboxMenu
    {
        public static GameObject MainStoppedColor;
        public static GameObject MainColor;
        public static GameObject BeatColor;

        [HarmonyPatch(typeof(uGUI_OptionsPanel), nameof(uGUI_OptionsPanel.AddTabs))]
        class uGUI_OptionsPanel_AddTabs_Patch
        {
            static bool Prefix(uGUI_OptionsPanel __instance)
            {
                __instance.AddGeneralTab();
                __instance.AddGraphicsTab();
                if (GameInput.IsKeyboardAvailable())
                {
                    __instance.AddKeyboardTab();
                }
                if (GameInput.IsControllerAvailable())
                {
                    __instance.AddControllerTab();
                }
                __instance.AddAccessibilityTab();
                if (!PlatformUtils.isConsolePlatform)
                {
                    __instance.AddTroubleshootingTab();
                }
                if (__instance != null)
                {
                    AddJukeBoxTab(__instance);
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(GameSettings), nameof(GameSettings.SerializeSettings))]
        class GameSettings_SerializeVRSettings_Patch
        {
            static void Postfix(GameSettings.ISerializer serializer)
            {
                JukeboxConfig.JBColor = serializer.Serialize("Jukebox/ColorToggle", JukeboxConfig.JBColor);
                JukeboxConfig.FlashColor0 = serializer.Serialize("Jukebox/MainStoppedColor", JukeboxConfig.FlashColor0);
                JukeboxConfig.FlashColor2 = serializer.Serialize("Jukebox/MainColor", JukeboxConfig.FlashColor2);
                JukeboxConfig.FlashColor1 = serializer.Serialize("Jukebox/BeatColor", JukeboxConfig.FlashColor1);
                JukeboxConfig.PartyMode = serializer.Serialize("Jukebox/PartyMode", JukeboxConfig.PartyMode);
            }
        }

        public static void AddJukeBoxTab(uGUI_OptionsPanel oPanel)
        {
            if (oPanel != null)
            {
                int tabIndex = oPanel.AddTab("Jukebox");
                oPanel.AddHeading(tabIndex, "Jukebox Colors");
                oPanel.AddToggleOption(tabIndex, "Toggle Jukebox Colors", JukeboxConfig.JBColor, (bool v) => JukeboxConfig.JBColor = ToggleColorChange(v), "Allows you to change the colors of the jukebox lights");
                MainStoppedColor = oPanel.AddColorOption(tabIndex, "Color 1", JukeboxConfig.FlashColor0, (Color Color0) => JukeboxConfig.FlashColor0 = Color0);
                MainColor = oPanel.AddColorOption(tabIndex, "Color 2", JukeboxConfig.FlashColor2, (Color Color2) => JukeboxConfig.FlashColor2 = Color2);
                BeatColor = oPanel.AddColorOption(tabIndex, "Color 3", JukeboxConfig.FlashColor1, (Color Color1) => JukeboxConfig.FlashColor1 = Color1);
                oPanel.AddHeading(tabIndex, "Jukebox Options");
                oPanel.AddToggleOption(tabIndex, "Toggle Party Mode", JukeboxConfig.PartyMode, (bool partyMode) => JukeboxConfig.PartyMode = partyMode,"Turns the rooms lights off the jukebox is in while playing");
                ToggleColorChange(JukeboxConfig.JBColor);
            }
        }

        public static bool ToggleColorChange(bool value)
        {
            MainStoppedColor.SetActive(value);
            MainColor.SetActive(value);
            BeatColor.SetActive(value);
            if (value == false)
            {
                JukeboxConfig.FlashColor0 = new Color(0f, 0f, 0f, 1f);
                JukeboxConfig.FlashColor1 = new Color(1f, 0f, 0.7f, 1f);
                JukeboxConfig.FlashColor2 = new Color(1f, 0.4f, 0f,1f);
            }
            return value;
        }
    }
}


