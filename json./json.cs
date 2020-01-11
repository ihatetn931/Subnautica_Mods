using System;
using System.Collections.Generic;
using System.IO;
using Oculus.Newtonsoft.Json;

namespace SubnauticaBZRP
{
    public class Json
    {
        public class BiomeName
        {
            public int BiomeId { get; set; }
            public string Biomename { get; set; }
            public string TimeDateFound { get; set; }
            public string Location { get; set; }
        }
        public class RootObject
        {
            public int totalBiomes { get; set; }
            public List<BiomeName> biomenames { get; set; }
        }

        static int biomeId = 1;

        public static void CreateJson()
        {
            var settings = new JsonSerializerSettings
            {
                CheckAdditionalContent = true,
                Formatting = Formatting.Indented
            };

            List<BiomeName> BiomeNames = new List<BiomeName>();
            var root = new RootObject { biomenames = BiomeNames };

            string json = JsonConvert.SerializeObject(root, settings);
            File.AppendAllText(ConfigFile.lightStatePath, json);
        }

        public static void AddToList(string name)
        {
            float locX = Player.main.rigidBody.velocity.x;
            float locY = Player.main.rigidBody.velocity.y;
            float locZ = Player.main.rigidBody.velocity.z;
            string locXYZ = $"{locX} , {locY} , {locZ}";
            bool found = true;
            if (locX != 0 && locY != 0 && locZ != 0)
            {
                var settings = new JsonSerializerSettings { CheckAdditionalContent = true, Formatting = Formatting.Indented };
                var read = File.ReadAllText(ConfigFile.lightStatePath);
                var json = JsonConvert.DeserializeObject<RootObject>(read);

                json.totalBiomes = json.biomenames.Count + 1;

                foreach (var c in json.biomenames)
                {
                    if (c.Biomename.Equals(name.ToLower()))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    json.biomenames.Add(new BiomeName
                    {
                        BiomeId = biomeId++,
                        Biomename = name.ToLower(),
                        TimeDateFound = DateTime.Now.ToString(),
                        Location = locXYZ,
                    });

                    string jsonString1 = JsonConvert.SerializeObject(json, settings);
                    File.WriteAllText(ConfigFile.lightStatePath, jsonString1);
                    //found = false;
                }
            }
        }

        public static void AddNewBiome(string bName)
        {
            if (!File.Exists(ConfigFile.lightStatePath))
            {
                CreateJson();
                return;
            }
            if (bName != null)
            {
                AddToList(bName);
            }

        }
    }
}


