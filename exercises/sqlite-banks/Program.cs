using System;

namespace BankTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the database interface
            DatabaseInterface db = new DatabaseInterface();

            // Check/create the Account table
            db.CheckAccountTable();

            int choice;

            do
            {
                // Show the main menu by invoking the static method
                choice = MainMenu.Show();

                switch (choice)
                {
                    // Menu option 1: Adding account
                    case 1:
                        // Ask user to input customer name
                        string CustomerName = Console.ReadLine();

                        // Insert customer account into database
                        db.Insert($@"
                            INSERT INTO Account
                            (Id, Customer, Balance)
                            VALUES
                            (null, '{CustomerName}', 0)
                        ");
                        break;

                    // Menu option 2: Deposit money
                    case 2:
                        // Logic here
                        Console.WriteLine ("Enter the customer name");
                        Console.Write ("> ");
                        string depositQuery = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("How much would you like to deposit?");
                        Console.Write("> ");
                        string depositAmt = Console.ReadLine();

                        // Get record from database
                        db.Query($"UPDATE Account SET Balance = Balance + {depositAmt} WHERE Customer = '{depositQuery}'", (reader) => {});
                        break;

                        Console.WriteLine($"You've deposited {depositAmt}");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadLine();

                    // Menu option 3: Withdraw money
                    case 3:
                        // Logic here
                        Console.WriteLine ("Enter the customer name");
                        Console.Write ("> ");
                        string withdrawQuery = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("How much would you like to withdraw?");
                        Console.Write("> ");
                        string withdrawAmt = Console.ReadLine();

                        // Get record from database
                        db.Query($"UPDATE Account SET Balance = Balance - {withdrawAmt} WHERE Customer = '{withdrawQuery}'", (reader) => {});

                        Console.WriteLine($"You've withdrawn {withdrawAmt}");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadLine();
                        break;

                    // Menu option 4: Withdraw money
                    case 4:
                        // Logic here
                        Console.WriteLine ("Enter the customer name");
                        Console.Write ("> ");
                        string customer = Console.ReadLine();
                        Console.WriteLine("");

                        // Get record from database
                        db.Query($"SELECT Balance FROM Account WHERE Customer = '{customer}'", (reader) => {
                            while(reader.Read()){
                                Console.WriteLine($"Current Account Balance for {customer}");
                                Console.WriteLine(string.Format("${0:#.00}", Convert.ToDecimal(reader[0].ToString())));
                                Console.WriteLine("");
                                Console.WriteLine("Press any key to return to the main menu.");
                                Console.ReadLine();
                            }
                        });
                        break;
                }
            } while (choice != 5);
        }
    }
}