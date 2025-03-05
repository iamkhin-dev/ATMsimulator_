using System;

class ATM
{
    static void Main()
    {
        string name;
        double balance = 0;
        Console.WriteLine("ATM SIMULATOR\n");
        while (true)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("To continue, you must enter the name of the account holder.");
                continue;
            }
            else
            {
                break;
            }
        }
        while (true)
        {
            Console.Write("Enter your balance: ");
            try
            {
                balance = double.Parse(Console.ReadLine());
                if (balance < 0)
                {
                    Console.WriteLine("The balance cannot be negative. Please enter a valid amount.");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                 throw;
            }
        }
        Console.WriteLine($"{name}, your balance of ${balance} has been successfully added.");
        ATM atm = new ATM(balance);
        atm.ATMMenu();
    }

    double balance;

    public ATM(double initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit()
    {
        Console.Write("Enter the amount you want to deposit: ");
        try
        {
            double depositAmount = double.Parse(Console.ReadLine());
            if (depositAmount > 0)
            {
                balance += depositAmount;
                Console.WriteLine("Money deposited.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        catch (FormatException)
        {
            throw;
        }
    }

    public void Withdraw()
    {
        Console.Write("Enter the amount you want to withdraw: ");
        try
        {
            double withdrawAmount = double.Parse(Console.ReadLine());
            if (withdrawAmount > 0 && withdrawAmount <= balance)
            {
                balance -= withdrawAmount;
                Console.WriteLine("Money withdrawn.");
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient balance.");
            }
        }
        catch (FormatException)
        {
             throw;
        }
    }

    public void ATMMenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("1. Deposit money");
            Console.WriteLine("2. Withdraw money");
            Console.WriteLine("3. Exit\n");
            Console.Write("Choose an option: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Deposit();
                        break;
                    case 2:
                        Withdraw();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error: Invalid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid option.");
            }
            Console.WriteLine($"Current balance: ${balance}");
        }
    }
}
