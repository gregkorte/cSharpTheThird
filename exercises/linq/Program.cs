using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            var LFruits = from fruit in fruits
                        where fruit.StartsWith("L")
                        select fruit;

            Console.WriteLine(String.Join(", ", LFruits));

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {                                                       
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
            Console.WriteLine($"Multiples of 4 & 6...");
            foreach(int match in fourSixMultiples){
                Console.WriteLine(match);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina", "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice", "Theodora", "William", "Svetlana", "Charisse", "Yolanda", "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = names.OrderByDescending(x => x).ToList();
            Console.WriteLine(string.Join(", ", descend));

            // Build a collection of these numbers sorted in ascending order
            List<int> numbersX = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

           numbersX.Sort((a, b) => b - a);
           foreach(int num in numbersX){
           Console.WriteLine(num);
           };

           // Output how many numbers are in this list
            List<int> numbersY = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine($"There are {numbersY.Count()} numbers in this list.");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            Console.WriteLine($"We have made ${purchases.Aggregate((a, b) => a + b)} to date.");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            Console.WriteLine($"Our most expensive price is ${prices.Max()}");
            

        }
    }   
}
