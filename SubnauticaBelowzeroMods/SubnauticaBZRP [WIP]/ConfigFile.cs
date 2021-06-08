using System;
using System.IO;
using System.Reflection;

namespace SubnauticaBZRP
{
    public static class BiomeCapture
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
    }
}


    

