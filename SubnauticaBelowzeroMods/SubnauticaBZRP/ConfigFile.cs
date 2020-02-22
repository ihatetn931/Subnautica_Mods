
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


//public static bool dBug = false;
namespace SubnauticaBZRP
{
    //public class TestClass
    //{
        /*public  class  BiomeName
        {
            public string BiomeId { get; set; }
            public string Biomename { get; set; }
            public string TimeDateFound { get; set; }
            public string Location { get; set; }
        }

        public class RootObject
        {
            public List<BiomeName> BiomeName { get; set; }
        }


        //Store new customer in array
        public static void Save(string valueToWrite)
        {
            bool found = false;
            var lines = File.ReadAllLines(ConfigFile.lightStatePath);
            foreach (var sLine in lines)
            {
                if (sLine.Equals(valueToWrite.ToLower()))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                BiomeName test = new BiomeName();
                if (test.Biomename != Player.main.GetBiomeString())
                {
                    test.BiomeId = "0";
                    test.Biomename = Player.main.GetBiomeString();
                    test.Location = "Here";
                    test.TimeDateFound = "Now";
                }
                File.AppendAllText(ConfigFile.lightStatePath, JsonConvert.SerializeObject(test));
            }
        }

        public static void AddCustomer(BiomeName newCustomer)
        {
            var json = File.ReadAllText(ConfigFile.lightStatePath);
            var customers = JsonConvert.DeserializeObject<List<BiomeName>>(json);
            customers.Add(newCustomer);
            File.WriteAllText(ConfigFile.lightStatePath, JsonConvert.SerializeObject(customers));
        }

        public BiomeName GetCustomer(string id)
        {
            var json = File.ReadAllText(ConfigFile.lightStatePath);
            var customers = JsonConvert.DeserializeObject<List<BiomeName>>(json);
            var result = new BiomeName();
            foreach (var c in customers)
            {
                if (c.BiomeId == id)
                {
                    result = c;
                    break;
                }
            }
            return result;
        }
    }*/
    public static class ConfigFile
    {

        private static readonly string LightsState = "biomes.json";
        public static string lightStatePath = Path.Combine(GetAssemblyDirectory, LightsState);

        private static string GetAssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        public static void Save(string valueToWrite)
        {
            bool found = false;
            var lines = File.ReadAllLines(lightStatePath);
            foreach (var sLine in lines)
            {
                if (sLine.Equals(valueToWrite.ToLower()))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                string textFile = $"{valueToWrite.ToLower()}\n";
                File.AppendAllText(lightStatePath, textFile);
            }
        }
        /*public static bool GetCurrentBiomes()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                CheckAdditionalContent = true,

            };
            if (File.Exists(lightStatePath))
            {
                string myString = File.ReadAllText(lightStatePath);
                

                    var myMessage = JsonConvert.DeserializeObject<Biomes>(myString);
                    //Debug.Log($"GetCurrentBiome() file is {myMessage.BiomeName[i]}");
                    //Main.PlayerInfoState = myMessage;
            }
            else
            {
                AttemptToCreate();
            }

            return true;
        }
        public static bool AttemptToCreate()
        {

            if (!File.Exists(lightStatePath))
            {
                var collection = new List<Biomes>();
                var collectionWrapper = new
                {
                    Biomes = collection
                };

                collection.Add(new Biomes { BiomeName = "First" });
                string json = JsonConvert.SerializeObject(collectionWrapper, Formatting.Indented);
                File.AppendAllText(lightStatePath, json);

            }
            return true;
        }

        public static bool AttemptToSave(string state)
        {
            if (File.Exists(lightStatePath))
            {
                if (state != null)
                {
                    string[] biome = File.ReadAllLines(lightStatePath);
                    //var myMessage = JsonConvert.DeserializeObject<Biomes>(biome);

                    for (int i = 0; i < biome.Length; i++)
                    {
                        var myMessage = JsonConvert.DeserializeObject<Biomes>(biome[i]);
                        myMessage.BiomeName = state;
                        string json = JsonConvert.SerializeObject(myMessage, Formatting.Indented);
                        File.AppendAllText(lightStatePath, json);
                    }
                }
            }
            return true;
        }*/
    }
}


    

