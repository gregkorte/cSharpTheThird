using System;
using System.Collections.Generic;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();
            List<int> squares = new List<int>();
            for(var i = 0; i < 10; i++){
                numbers.Add(random.Next(25));
            }
            foreach(int number in numbers){
                int sq = number*number;
                squares.Add(sq);
                if(sq % 2 != 0){
                    squares.Remove(sq);
                }
            }
            foreach(int evenSquare in squares){
                Console.WriteLine(evenSquare + " ");
            }

        }
    }
}
