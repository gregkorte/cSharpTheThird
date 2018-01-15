using System;
using System.Collections.Generic;

namespace bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            
            Accounting accounting = new Accounting("Accounting", "Rob Zombie", 5, "A1", 1000000.00);
            IT it = new IT("IT", "Moses Jones", 40, "C4", 8000000.00);
            Marketing marketing = new Marketing("Marketing", "Saul Bernstein", 17, "B2", 680000.00);
            HumanResources hr = new HumanResources("HR", "Sally Halloween", 5, "B1", 290000.00);

            departments.Add(accounting);
            departments.Add(it);
            departments.Add(marketing);
            departments.Add(hr);

            Console.WriteLine(">>> Running all derived class toString <<<");
            Console.WriteLine(accounting.toString());
            Console.WriteLine(it.toString());
            Console.WriteLine(marketing.toString());
            Console.WriteLine($"{hr.toString()} \n");

            Console.WriteLine(">>> Running Department toString <<<");
            foreach(Department d in departments)
            {
                Console.WriteLine($"{d.toString()}");
            }
        }
    }
}
