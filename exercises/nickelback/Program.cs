using System;
using System.Collections.Generic;

namespace nickelback
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(string, string)> goodSongs = new List<(string, string)>();
            HashSet<(string, string)> allSongs = new HashSet<(string, string)>(){
                ("Nickelback", "Someday"),
                ("Nickelback", "Too Bad"),
                ("Yes", "Tempus Fugit"),
                ("Rush", "Freewill"),
                ("The Beatles", "Polythene Pam"),
                ("Cat Stevens", "Year of the Cat"),
                ("Grateful Dead", "Ripple")
            };
            foreach((string, string) t in allSongs){
                if(t.Item1 != "Nickelback"){
                    goodSongs.Add(t);
                }
            };
            foreach((string, string) tup in goodSongs){
                Console.WriteLine($"{tup.Item2} by {tup.Item1}");
            };

        }
    }
}
