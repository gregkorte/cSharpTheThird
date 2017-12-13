using System;
using System.Collections.Generic;

namespace sets
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create an empty HashSet named Showroom that will contain strings.
            HashSet<string> Showroom = new HashSet<string>();

            // Add four of your favorite car model names to the set.
            Showroom.Add("Sonata");
            Showroom.Add("Altima");
            Showroom.Add("Cordia");
            Showroom.Add("Cavalier");

            // Print to the console how many cars are in your show room.
            Console.WriteLine($"First four {Showroom.Count}");

            // Pick one of the items in your show room and add it to the set again.
            Showroom.Add("Altima");

            // Print your showroom again, and notice how there's still only one representation of that model in there.
            Console.WriteLine($"After duplicate {Showroom.Count}");

            // Create another set named UsedLot and add two more car model strings to it.
            HashSet<string> usedLot = new HashSet<string>();
            usedLot.Add("ZR5");
            usedLot.Add("ZR7");
            
            // Use the UnionWith() method on Showroom to add in the two models you added to UsedLot.
            Showroom.UnionWith(usedLot);
            Console.WriteLine($"After join {Showroom.Count}");
            string output0 = string.Join(" ", Showroom);
            Console.WriteLine($"Showroom and used: {output0}");

            // You've sold one of your cars. Remove it from the set with the Remove() method.
            Showroom.Remove("Cavalier");
            Console.WriteLine($"After remove {Showroom.Count}");
            string output1 = string.Join(" ", Showroom);
            Console.WriteLine($"Remove Cavalier: {output1}"); 

            // Now create another HashSet of cars in a variable Junkyard. Someone who owns a junkyard full of old cars has approached you about buying the entire inventory. In the new set, add some different cars, but also add a few that are the same as in the Showroom set.
            HashSet<string> junkYard = new HashSet<string>();
            junkYard.Add("REO");      
            junkYard.Add("Cordia");      
            junkYard.Add("Altima");      
            junkYard.Add("RS5");      
            junkYard.Add("Gremlin");  

            // Use the IntersectWith() method to see which cars exist in both the show room and the junkyard.
            HashSet<string> intersect = new HashSet<string>();
            intersect.UnionWith(junkYard);
            intersect.IntersectWith(Showroom);
            string output2 = string.Join(" ", intersect);
            Console.WriteLine($"Intersecting {output2}");

            // Now you're ready to buy the cars in the junkyard. Use the UnionWith() method to combine the junkyard into your showroom.
            Showroom.UnionWith(junkYard);
            string output3 = string.Join(" ", Showroom);
            Console.WriteLine($"Showroom, used & junk: {output3}");

            // Use the Remove() method to remove any cars that you acquired from the junkyard that you want in your showroom.
            Showroom.Remove("RS5");
            Console.WriteLine($"After remove {Showroom.Count}");
            string output4 = string.Join(" ", Showroom);
            Console.WriteLine($"Showroom, used & junk: {output4}");
        }
    }
}
