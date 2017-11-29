using System;
using System.Collections.Generic; // Namespace containing data structures


namespace intro
{
    class Program
    {
        static void Main(string[] args)
        {
            // DateTime is the type of the purchaseData variable.
            DateTime purchaseDate=DateTime.Now;

            /*
                string is the type of the lastName variable. It 
                tells the compiler that the lastName variable can
                ONLY hold a string value.
            */
            string lastName="Smith"; 

            /*
                C# now supports implicitly typing of a variable. The
                type of the variable will be determined, by the 
                compiler, at compile time.
            */
            var firstName="Bill";

            /* 
              The String.Format() function syntax allows you to
              build the final string, with placeholders, and
              then provide comma-delimited list of variables to
              use in the placeholders.
            */
            Console.WriteLine($"{firstName} {lastName} purchased on {purchaseDate}");

            /*
                Not only do you have to say what type the variable is, you also 
                have to instantiate that exact same type of object on assignment.
                This may seem redundant, but it's part of the C# language compiler's 
                type checking constraints.
            */
            string[] products = new string[] {
                "Motorcycle",
                "Sofa",
                "Sandals",
                "Omega Watch",
                "iPhone"
            };

            /*
                This syntax should look very similar to what you did in an Angular
                partial's ng-repeat directive. However, once again you have to 
                explicitly say what type of variable product is. Since the products
                array holds strings, then its type must be string.
            */
            foreach (string product in products) {
                if (product.Length > 5) {
                    Console.WriteLine(product);
                }
            }

            // Somewhere in a Program.cs

            // Creates an instance of a List type that will only contain integers.
            // Starts off as empty.
            List<int> myListOfIntegers = new List<int>();

            // You can add items to this list via the `Add` method.
            myListOfIntegers.Add(77);
            myListOfIntegers.Add(108);

            foreach (int num in myListOfIntegers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(myListOfIntegers);

            List<double> doublePrecisionNumbers = new List<double>();
            doublePrecisionNumbers.Add(1.3);
            doublePrecisionNumbers.Add(8.2);
            doublePrecisionNumbers.Add(0.4);
            doublePrecisionNumbers.Add(12.1);

            foreach (double d in doublePrecisionNumbers)
            {
                Console.WriteLine(d);
            }

            var productToy = Tuple.Create("Yo-yo", 1, 9.04);
            Console.WriteLine($"{productToy.Item1} {productToy.Item2} {productToy.Item3}");

            (string name, int quantity, double price) productToys = ("Yo-yo", 1, 9.04);

            productToys.quantity = 2;

            // Now you can use appropriately named properties on the object
            Console.WriteLine($"{productToys.name} {productToys.quantity} {productToys.price} ");

            Dictionary<int, string> numberTable = new Dictionary<int, string>();

            numberTable.Add(1, "One");
            numberTable.Add(2, "Two");
            numberTable.Add(3, "Three");
            numberTable.Add(4, "Four");
            numberTable.Add(5, "Five");

            foreach (KeyValuePair<int, string> number in numberTable)
            {
                Console.WriteLine("{0} equals {1}", number.Key, number.Value);
            }

            /*
            The following code generates the exception:
                An item with the same key has already been added.
            */
            // numberTable.Add(5, "Cinco");
        }
    }
}