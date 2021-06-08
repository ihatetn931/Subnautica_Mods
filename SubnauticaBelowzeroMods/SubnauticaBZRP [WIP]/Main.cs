using System;
using System.Collections.Generic;
using HarmonyLib;
namespace SubnauticaBZRP
{
    public class Main
    {
        public static DiscordControl.Discord discord;

        public static void FirstStart()
        {
                SecondStart();
        }

        public static void SecondStart()
        {
            discord = new DiscordControl.Discord(658097781482848257, (UInt64)DiscordControl.CreateFlag.Default);
            DiscordController.Load();
        }
    }

    public class BiomeList
    {
        public static List<Json.BiomeName> biomeMap = new List<Json.BiomeName>();
      
        public static string GetBiomeDisplayName(string biomeStr)
        {
            foreach (var biome in biomeMap)
            {
                if (biomeStr.Equals(biome.Biomename))
                {
                    return biome.BiomeEditedName;
                }
            }

            return biomeStr;
        }

        public static string GetBiomeStringName(string biomeDisplayName)
        {
            foreach (var biome in biomeMap)
            {
                if (biomeDisplayName.Equals(biome.BiomeEditedName))
                {
                    return biome.Biomename;
                }
            }

            return biomeDisplayName;
        }
    }
}
