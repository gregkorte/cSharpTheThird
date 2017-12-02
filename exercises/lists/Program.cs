using System;
using System.Collections.Generic;

namespace lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, string>> probes = new List<Dictionary<string, string>>(){};
            probes.Add(new Dictionary<string, string>(){{"Hyugens", "Jupiter"}});
            probes.Add(new Dictionary<string, string>(){{"Cassini", "Saturn"}});
            probes.Add(new Dictionary<string, string>(){{"Opportunity", "Mars"}});
            probes.Add(new Dictionary<string, string>(){{"Sojourn", "Mars"}});
            probes.Add(new Dictionary<string, string>(){{"Mariner 2", "Venus"}});
            List<string> planetList = new List<string>(){"Mercury", "Mars"};

            // 1. Add Jupiter and Saturn at the end of the list
            planetList.Add("Jupiter");
            planetList.Add("Saturn");
            string str1 = "MMJS";
            writePlanets(str1, planetList);

            // 2. Create another List that contains the last two known planets of our solar system
            List<string> lastPlanets = new List<string>(){"Uranus", "Neptune"};
            string str2 = "UN";
            writePlanets(str2, lastPlanets);
            
            // 3. Combine the two Lists
            planetList.AddRange(lastPlanets);
            string str3 = "All but EVP";
            writePlanets(str3, planetList);
            
            // 4. Insert Venus and Earth in the correct order
            planetList.Insert(1, "Venus");
            planetList.Insert(2, "Earth");
            string str4 = "All but P";
            writePlanets(str4, planetList);
            
            // 5. Add Pluto to the end of the list
            planetList.Add("Pluto");
            string str5 = "All planets";
            writePlanets(str5, planetList);
            
            // 6. Extract all the rocky planets to a new List
            List<string> rockyPlanets = planetList.GetRange(0, 4);
            List<string> outerRocks = planetList.GetRange(7, 2);
            string str6 = "Rocky ones";
            rockyPlanets.AddRange(outerRocks);
            writePlanets(str6, rockyPlanets);
            
            // 7. Remove Pluto from the end of planetList
            planetList.Remove("Pluto");
            string str7 = "Pluto gets no respect";
            writePlanets(str7, planetList);
        }
        public static void writePlanets(string str, List<string> list)
        {
            foreach(string planet in list){
               Console.WriteLine("{0} {1}", str, planet);
            }
        }

        public static void writeProbes(List<Dictionary<string, string>> probes)
        {
            foreach(Dictionary<string, string> probeSet in probes){
                Console.WriteLine(string.Format("{1}: {0}", probes.Key, probes.Value));
            }
        }
    }
}
