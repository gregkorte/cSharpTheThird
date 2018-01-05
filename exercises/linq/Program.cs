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

        }
    }   
}
