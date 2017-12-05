using System;
using System.Collections.Generic;

namespace tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<(string product, double amount, int quantity)> transactions = new List<(string, double, int)>();

            transactions.Add(("Screaming cheetah wheelie", 2000, 1));
            transactions.Add(("Strangled holders", 300, 5));
            transactions.Add(("Flying tree toppers", 490, 89));
            transactions.Add(("Macking Fleetwoods", 892, 4));
            transactions.Add(("Syds & Rogers", 1340, 76));

            int totalItems = 0;
            double totalRevenue = 0;

            foreach ((string product, double amount, int quantity) t in transactions){
                totalItems += t.quantity;
                totalRevenue += t.amount;
            }
            Console.WriteLine("Items sold today: " + totalItems);
            Console.WriteLine("Total revenue: $" + totalRevenue);
        }
    }
}
