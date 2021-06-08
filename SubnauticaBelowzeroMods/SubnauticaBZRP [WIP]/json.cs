using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Oculus.Newtonsoft.Json;
using UnityEngine;
//Capture all the biomes the user has been in and make
namespace SubnauticaBZRP
{
    public class Json
    {
        public class BiomeName
        {
            public int BiomeId { get; set; }
            public string Biomename { get; set; }
            public string BiomeEditedName { get; set; }
            public string TimeDateFound { get; set; }
        }
        public class RootObject
        {
            public int totalBiomes { get; set; }
            public List<BiomeName> biomenames { get; set; }
        }

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
            File.AppendAllText(BiomeCapture.lightStatePath, json);
        }

        public static void AddToList(string name)
        {
            bool found = true;
            var settings = new JsonSerializerSettings { CheckAdditionalContent = true, Formatting = Formatting.Indented };
            var read = File.ReadAllText(BiomeCapture.lightStatePath);
            var json = JsonConvert.DeserializeObject<RootObject>(read);
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
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
                    BiomeId = json.totalBiomes,
                    Biomename = name.ToLower(),
                    BiomeEditedName = textInfo.ToTitleCase(name.Replace("_", " ")),
                    TimeDateFound = DateTime.Now.ToString(),
                });

                string jsonString1 = JsonConvert.SerializeObject(json, settings);
                File.WriteAllText(BiomeCapture.lightStatePath, jsonString1);
            }
        }

        public static void AddNewBiome(string bName)
        {
            if (!File.Exists(BiomeCapture.lightStatePath))
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



