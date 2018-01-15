using System;
using System.Collections.Generic;

namespace bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();
            
            Accounting accounting = new Accounting("Accounting", "Rob Zombie", 5, "A1");
            IT it = new IT("IT", "Moses Jones", 40, "C4");
            Marketing marketing = new Marketing("Marketing", "Saul Bernstein", 17, "B2");
            HumanResources hr = new HumanResources("HR", "Sally Halloween", 5, "B1");

            departments.Add(accounting);
            departments.Add(it);
            departments.Add(marketing);
            departments.Add(hr);

            Console.WriteLine(">>> Running all derived class toString <<<");
            Console.WriteLine(accounting.toString());
            Console.WriteLine(it.toString());
            Console.WriteLine(marketing.toString());
            Console.WriteLine($"{hr.toString()}");

            Console.WriteLine("\n>>> Running Department toString <<<");
            foreach(Department d in departments)
            {
                Console.WriteLine($"{d.toString()}");
            }

            Console.WriteLine("\n>>> Setting base budgets and modifiers <<<");
            foreach(Department d in departments)
            {
                d.SetBudget(50000);
            }
            accounting.SetBudget(950000.00);
            it.SetBudget(7950000.00);
            marketing.SetBudget(720000.00);
            hr.SetBudget(250000.00);
            Console.WriteLine(accounting.toString());
            Console.WriteLine(it.toString());
            Console.WriteLine(marketing.toString());
            Console.WriteLine($"{hr.toString()} \n");

            Console.WriteLine($"\n>>> Eat method #1: Selecting a random restaurant for this employee <<<");
            Employee ted = new Employee("Ted", "Croatia");
            Console.WriteLine($"{ted.eat()}");

            Console.WriteLine($"\n>>> Eat method #2: Printing what the employee ate <<<");
            Console.WriteLine($"{ted.eat("hambuergher")}");

            Console.WriteLine($"\n>>> Eat method #3: Selecting a random restaurant for this employee <<<");
            List<Employee> emps = new List<Employee>();
            Employee saul = new Employee("Saul", "Minion");
            Employee dave = new Employee("Dave", "Rumbah");
            Employee larry = new Employee("Larry", "Mankles");
            emps.Add(saul);
            emps.Add(dave);
            emps.Add(larry);
            
            Console.WriteLine($"{ted.eat(emps)}");

            Console.WriteLine($"\n>>> Eat method #4: Selecting a random restaurant, for and companions for this employee <<<");
            ted.eat("hambuergher", emps);

        }
    }
}
