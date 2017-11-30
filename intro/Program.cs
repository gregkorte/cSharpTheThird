using System;
using System.Linq; // Namespace containing LINQ data structures
using System.Collections.Generic; // Namespace containing data structures


namespace intro
{
    public class Product
    {
        /*
        Properties
         */
         public string Title { get; set; }
         public double Price {get; set; }

         // Constructor method
         public Product (string title, double price)
         {
             this.Title = title;
             this.Price = price;
         }
    }

    public class Program
    {
        public static void Main(string[] args)
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

             /*
            Start with a collection that is of type IEnumerable, which
            List is and initialize it with some values. This is the 
            class sizes for a selection of NSS cohorts.
            */
            List<int> cohortStudentCount = new List<int>()
            {
                25, 12, 28, 22, 11, 25, 27, 24, 19
            };
            Console.WriteLine($"Largest cohort was {cohortStudentCount.Max()}");
            Console.WriteLine($"Smallest cohort was {cohortStudentCount.Min()}");
            Console.WriteLine($"Total students is {cohortStudentCount.Sum()}");

            /*
                Now we need to determine which cohorts fell within the range
                of acceptable size - between 20 and 26 students. Also, sort
                the new enumerable collection in ascending order.
            */
            IEnumerable<int> idealSizes = from count in cohortStudentCount 
                where count < 27 && count > 19
                orderby count ascending
                select count;

            Console.WriteLine($"Average ideal size is {idealSizes.Average()}");

            // The @ symbol lets you create multi-line strings in C#
            Console.WriteLine($@"
            There were {idealSizes.Count()} ideally sized cohorts
            There have been {cohortStudentCount.Count()} total cohorts");

            // Display each number that was the acceptable size
            foreach (int c in idealSizes)
            {
                Console.WriteLine($"{c}");
            }

            /*
            We can use curly braces to create instances of objects
            and immediately inject them into the List.
            */
            List<Product> shoppingCart = new List<Product>(){ 
                new Product("Bike", 109.99),
                new Product("Mittens", 6.49),
                new Product("Lollipop", 0.50),
                new Product("Pocket Watch", 584.00)
            };

            /*
                IEnumerable is an interface, which we'll get to later,
                that we're using here to create a collection of Products
                that we can iterate over.
            */
            IEnumerable<Product> inexpensive = from product in shoppingCart 
                where product.Price < 100.00
                orderby product.Price descending
                select product;

            foreach (Product p in inexpensive)
            {
                Console.WriteLine($"{p.Title} ${p.Price:f2}");
            }

            /*
                You can also use `var` when creating LINQ collections. The 
                following variable will still be typed as List<Product> by
                the compiler, but you don't need to type that all out.
            */
            var expensive = from product in shoppingCart 
                where product.Price >= 100.00
                orderby product.Price descending
                select product;

            // Give this C# List of numbers
            List<int> numbers = new List<int>(){ 9, -59, 23, 71, -74, 13, 52, 44, 2 };

            /*
                Use the IEnumerable Where() method to build a new array of
                numbers that match two conditions. Then chain the OrderBy()
                method to order them ascending
            */
            var smallPositiveNumbers = numbers.Where(n => n < 40 && n > 0).OrderBy(n => n);

            /*
                Use All() to see if every item in the collection passes the
                provided conditions.
            */
            var allBetweenLarge = numbers.All(n => n > -100 && n < 400);  // true
            var allBetweenSmall = numbers.All(n => n > -5 && n < 39);  // false

            foreach (int numb in smallPositiveNumbers){
                Console.WriteLine(numb);
            }
        }
    }
}