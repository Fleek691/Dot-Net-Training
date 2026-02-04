using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");
        int amount = int.Parse(Console.ReadLine()!);

        try
        {
            if (amount <= 0)
            {
                throw new BankProblemException("Withdrawal amount must be greater than zero.");
            }

            if (amount > balance)
            {
                throw new BankProblemException("Insufficient balance.");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine($"Remaining balance: {balance}");
        }
        catch (BankProblemException ex)
        {
            Console.WriteLine($"Transaction failed: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
        finally
        {
            Console.WriteLine("Transaction process completed.");
        }
    }
}

public class BankProblemException : Exception
{
    public BankProblemException(string message) : base(message)
    {
    }
}
