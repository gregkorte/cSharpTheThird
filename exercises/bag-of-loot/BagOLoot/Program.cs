using System;
using System.Collections.Generic;
using System.Linq;


namespace BagOLoot
{
    class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.CheckChildTable();
            db.CheckToyTable();

            // choice will hold the number entered by the user
            // int choice;

            Console.WriteLine("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine("*********************************");
            Console.WriteLine("1. Add a child");
                Console.WriteLine("> ");
                int choice;
                Int32.TryParse(Console.ReadLine(), out choice);

            if(choice == 1)
            {
                Console.WriteLine("Enter name of child");
                Console.WriteLine("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                int childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
        }
    }
}
