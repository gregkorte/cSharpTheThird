using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("APL", "Apple");

            string GM = stocks["GM"];
            Console.WriteLine(GM);

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GE", shares: 32, price: 17.87));
            purchases.Add((ticker: "GE", shares: 80, price: 19.02));
            purchases.Add((ticker: "APL", shares: 200, price: 160.00));
            purchases.Add((ticker: "CAT", shares: 100, price: 100.00));

            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                Console.WriteLine(purchase);
            }

            /* 
                Define a new Dictionary to hold the aggregated purchase information.
                - The key should be a string that is the full company name.
                - The value will be the valuation of each stock (price*amount)

                {
                    "General Electric": 35900,
                    "AAPL": 8445,
                    ...
                }
            */
            Dictionary<string, int> aggregate = new Dictionary<string, int>();

            // Iterate over the purchases and 
            foreach((string ticker, int shares, double price) purchase in purchases){
                // Does the company name key already exist in the report dictionary?
                if(aggregate.ContainsKey(purchase.ticker)){
                // If it does, update the total valuation
                    aggregate[purchase.ticker] += (int)(purchase.shares * purchase.price);
                // If not, add the new key and set its value
                }  else {
                    aggregate.Add(purchase.ticker, (int)(purchase.shares * purchase.price));
                }
            }

            foreach(KeyValuePair<string, int> agg in aggregate){
                Console.WriteLine(agg);
            }
        }
    }
}
