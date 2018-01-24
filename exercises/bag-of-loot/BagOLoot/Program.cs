using System;
using System.Collections.Generic;
using System.Linq;
using BagOLoot.Actions;


namespace BagOLoot
{
    class Program
    {
        public static void Main(string[] args)
        {
            DatabaseInterface db = new DatabaseInterface("BAGOLOOT_DB");
            db.CheckChildTable();
            db.CheckToyTable();

            MainMenu menu = new MainMenu();
            ChildRegister book = new ChildRegister(db);
            ToyRegister bag = new ToyRegister(db);

            // choice will hold the number entered by the user
            int choice;

            do
            {
                // Show main menu
                choice = menu.Show();

                switch(choice)
                {
                    // Menu option 1
                    case 1:
                        CreateChild.DoAction(book);
                        break;

                    // Menu option 2
                    case 2:
                        AddToy.DoAction(bag, book, db);
                        break;
                }

            } 
            while(choice != 3);
        }
    }
}
