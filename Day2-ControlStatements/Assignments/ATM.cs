using System;

public class ATM
{
    public static void Working()
    {
        Console.Write("Is the card inserted: ");
        string? inserted=Console.ReadLine();
        
        if (inserted == "yes")
        {
            Console.Write("Enter Pin: ");
            int pin=Convert.ToInt32(Console.ReadLine());
            if (pin == 1234)
            {
                int balance=100000;
                Console.WriteLine("Enter withdrawal amount: ");
                int amount=Convert.ToInt32(Console.ReadLine());
                if (amount <= balance)
                {
                    balance=balance-amount;
                    Console.WriteLine("Withdraw successfull");
                    System.Console.WriteLine($"Remaining Balance: {balance}");
                }
                else
                {
                    System.Console.WriteLine("Insufficient Balance");
                }
            }
            else
            {
                System.Console.WriteLine("Enter Valid Pin.");
            }
        }
        else
        {
            System.Console.WriteLine("Insert Card.");
        }
    }
}