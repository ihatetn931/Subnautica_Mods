using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SubnauticaBZRP
{
    public class Main
    {
        //thanks to AHK1221 from relasing is source code to subnautica rich presence
        //thanks to Kylinator25 for the check if player is using seaglide
        //public static Data PlayerInfoState;
        //public static MainPlayerInfo MainPlayerInfoState;
        public static Discord.Discord discord;

        public static void FirstStart()
        {
                SecondStart();
            
        }

        public static void SecondStart()
        {
            discord = new Discord.Discord(658097781482848257, (UInt64)Discord.CreateFlags.Default);
            DiscordController.Load();
            
        }
    }

    public class Utility
    {
        private static Dictionary<string, string> biomeMap = new Dictionary<string, string>()
        {
            {
                "sparsearctic",
                "Sparse Arctic"
            },
            {
                "glacialconnection",
                "Glacial Connection"
            },
            {
                "arctickelp",
                "Arctic Kelp Forest"
            },
            {
                "arctic",
                "Arctic"
            },
            {
                "thermalspires",
                "Thermal Spires"
            },
            {
                "treespires",
                "Tree Spires"
            },
            {
                "purplevents",
                "Purple Vents"
            },
            {
                "purplevents_deep",
                "Purple Vents Deep"
            },
            {
                "crystalcave",
                "Crystal Caves"
            },
            {
                "fabricatorcaverns",
                "Fabcricator Caverns"
            },
            {
                "twistybridges_deep",
                "Twisty Bridges Deep"
            },
            {
                "arctickelp_caveinner",
                "Arctic Kelp Caves"
            },
            {
                "arcticKelp_caveouter",
                "Arctic Kelp Caves"
            },
            {
                "startzone",
                "Starting Zone"
            },
            {
                "introicecave",
                "Intro Ice Cave"
            },
            {
                "twistybridges_shallow",
                "Twisty Bridges Shallow"
            },
            {
                "twistybridges",
                "Twisty Bridges"
            },
            {
                "lilypads",
                "Lily Pads"
            },
            {
                "lilypads_deep",
                "Lily Pads Deep"
            },
            {
                "miningsite",
                "Mining Site"
            },
            {
                "rocketarea",
                "Rocket Island"
            },
            {
                "arcticspires",
                "Arctic Spires"
            },
            {
                "glacialbasin",
                "Glacial Basin"
            },
            {
                "icesheet",
                "Ice Sheet"
            },
            {
                "glacier",
                "Glacier"
            }
        };

        public static string GetBiomeDisplayName(string biomeStr)
        {
            foreach (var biome in biomeMap)
            {
                if (biomeStr.ToLower().Equals(biome.Key))//Contains(biome.Key))
                {
                    return biome.Value;
                }
            }

            return biomeStr;
        }

        public static string GetBiomeStringName(string biomeDisplayName)
        {
            foreach (var biome in biomeMap)
            {
                if (biomeDisplayName.Equals(biome.Value))
                {
                    return biome.Key;
                }
            }

            return "";
        }
    }
}
