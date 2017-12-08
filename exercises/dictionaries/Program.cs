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
            purchases.Add((ticker: "CAT", shares: 25, price: 45.00));

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

            aggregate.Add("APL", 33500);
            aggregate.Add("IBM", 4598);
            aggregate.Add("GE", 12984);

            foreach(KeyValuePair<string, int> item in aggregate){
                Console.WriteLine(item);
            }

            // Iterate over the purchases and 
            foreach(KeyValuePair<string, int> data in aggregate){
                var company = data.Key;
                var total = data.Value;
                Console.WriteLine(company total);
                // foreach((string company, int shares, double sellAt) purchase in purchases){
                //     if (data.Key = transaction.company){
                //         Console.WriteLine("The valuation for {0} is {1}", transaction.company, (transaction.shares*data.num));
                //     }
                // }
            }
            
                // Does the company name key already exist in the report dictionary?
            // foreach (<(string company, int volume)> data in aggregate)
            // {
            //     Console.WriteLine(data);

                // If it does, update the total valuation

                // If not, add the new key and set its value
            // }
        }
    }
}
