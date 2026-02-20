using System;
using System.Collections.Generic;
using System.Linq;

public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; protected set; }
    public List<string> TransactionHistory { get; } = new List<string>();

    protected BankAccount(string accountNumber, string customerName, decimal openingBalance)
    {
        AccountNumber = accountNumber;
        CustomerName = customerName;
        Balance = openingBalance;
        TransactionHistory.Add($"OPEN | Balance: {Balance}");
    }

    public virtual void Deposit(decimal amount)
    {
        ValidateAmount(amount);
        Balance += amount;
        TransactionHistory.Add($"DEPOSIT | Amount: {amount} | Balance: {Balance}");
    }

    public virtual void Withdraw(decimal amount)
    {
        ValidateAmount(amount);
        if (amount > Balance)
        {
            throw new InsufficientBalanceException("Withdrawal exceeds available balance.");
        }
        Balance -= amount;
        TransactionHistory.Add($"WITHDRAW | Amount: {amount} | Balance: {Balance}");
    }

    public abstract void CalculateInterest();

    protected static void ValidateAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new InvalidTransactionException("Amount must be greater than zero.");
        }
    }
}

public class SavingsAccount : BankAccount
{
    public const decimal MinimumBalance = 2000m;
    public decimal InterestRate { get; } = 0.04m;

    public SavingsAccount(string accountNumber, string customerName, decimal openingBalance)
        : base(accountNumber, customerName, openingBalance)
    {
        if (openingBalance < MinimumBalance)
        {
            throw new MinimumBalanceException("Opening balance is below the minimum balance.");
        }
    }

    public override void Withdraw(decimal amount)
    {
        ValidateAmount(amount);
        decimal projected = Balance - amount;
        if (projected < MinimumBalance)
        {
            throw new MinimumBalanceException("Withdrawal would breach minimum balance.");
        }
        Balance = projected;
        TransactionHistory.Add($"WITHDRAW | Amount: {amount} | Balance: {Balance}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
        TransactionHistory.Add($"INTEREST | Amount: {interest} | Balance: {Balance}");
    }
}

public class CurrentAccount : BankAccount
{
    public decimal OverdraftLimit { get; } = 10000m;
    public decimal InterestRate { get; } = 0.02m;

    public CurrentAccount(string accountNumber, string customerName, decimal openingBalance)
        : base(accountNumber, customerName, openingBalance)
    {
    }

    public override void Withdraw(decimal amount)
    {
        ValidateAmount(amount);
        if (amount > Balance + OverdraftLimit)
        {
            throw new InsufficientBalanceException("Withdrawal exceeds balance and overdraft limit.");
        }
        Balance -= amount;
        TransactionHistory.Add($"WITHDRAW | Amount: {amount} | Balance: {Balance}");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
        TransactionHistory.Add($"INTEREST | Amount: {interest} | Balance: {Balance}");
    }
}

public class LoanAccount : BankAccount
{
    public decimal InterestRate { get; } = 0.06m;

    public LoanAccount(string accountNumber, string customerName, decimal openingBalance)
        : base(accountNumber, customerName, openingBalance)
    {
    }

    public override void Deposit(decimal amount)
    {
        throw new InvalidTransactionException("Loan accounts cannot accept deposits.");
    }

    public override void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
        TransactionHistory.Add($"INTEREST | Amount: {interest} | Balance: {Balance}");
    }
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message)
    {
    }
}

public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message)
    {
    }
}

public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message)
    {
    }
}

public static class Program
{
    private static readonly List<BankAccount> Accounts = new List<BankAccount>();

    public static void Main()
    {
        SeedAccounts();
        RunMenu();
    }

    private static void SeedAccounts()
    {
        Accounts.Add(new SavingsAccount("SA1001", "Riya", 75000m));
        Accounts.Add(new SavingsAccount("SA1002", "Arjun", 25000m));
        Accounts.Add(new CurrentAccount("CA2001", "Rohit", 5000m));
        Accounts.Add(new CurrentAccount("CA2002", "Meera", 12000m));
        Accounts.Add(new LoanAccount("LA3001", "Rohan", 150000m));
    }

    private static void RunMenu()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Smart Banking System ===");
            Console.WriteLine("1. List accounts");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Calculate interest for all accounts");
            Console.WriteLine("6. Run LINQ queries");
            Console.WriteLine("7. Show transaction history");
            Console.WriteLine("8. Add new account");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ListAccounts();
                    break;
                case "2":
                    DepositToAccount();
                    break;
                case "3":
                    WithdrawFromAccount();
                    break;
                case "4":
                    TransferBetweenAccounts();
                    break;
                case "5":
                    CalculateInterestForAll();
                    break;
                case "6":
                    RunLinqQueries();
                    break;
                case "7":
                    ShowTransactionHistory();
                    break;
                case "8":
                    AddNewAccount();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static void ListAccounts()
    {
        foreach (BankAccount account in Accounts)
        {
            Console.WriteLine($"{account.AccountNumber} | {account.CustomerName} | {account.GetType().Name} | Balance: {account.Balance}");
        }
    }

    private static void DepositToAccount()
    {
        BankAccount account = FindAccount();
        if (account == null) return;

        decimal amount = ReadDecimal("Deposit amount: ");
        try
        {
            account.Deposit(amount);
            Console.WriteLine("Deposit successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void WithdrawFromAccount()
    {
        BankAccount account = FindAccount();
        if (account == null) return;

        decimal amount = ReadDecimal("Withdraw amount: ");
        try
        {
            account.Withdraw(amount);
            Console.WriteLine("Withdrawal successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void TransferBetweenAccounts()
    {
        Console.WriteLine("From account:");
        BankAccount from = FindAccount();
        if (from == null) return;

        Console.WriteLine("To account:");
        BankAccount to = FindAccount();
        if (to == null) return;

        decimal amount = ReadDecimal("Transfer amount: ");

        try
        {
            from.Withdraw(amount);
            try
            {
                to.Deposit(amount);
            }
            catch
            {
                from.Deposit(amount);
                throw;
            }
            from.TransactionHistory.Add($"TRANSFER OUT | Amount: {amount} | To: {to.AccountNumber}");
            to.TransactionHistory.Add($"TRANSFER IN | Amount: {amount} | From: {from.AccountNumber}");
            Console.WriteLine("Transfer successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void CalculateInterestForAll()
    {
        foreach (BankAccount account in Accounts)
        {
            account.CalculateInterest();
        }
        Console.WriteLine("Interest calculated using polymorphism.");
    }

    private static void RunLinqQueries()
    {
        Console.WriteLine("Accounts with balance > 50,000:");
        foreach (BankAccount account in Accounts.Where(a => a.Balance > 50000m))
        {
            Console.WriteLine($"{account.AccountNumber} | {account.CustomerName} | Balance: {account.Balance}");
        }

        decimal totalBalance = Accounts.Sum(a => a.Balance);
        Console.WriteLine($"Total bank balance: {totalBalance}");

        Console.WriteLine("Top 3 highest balance accounts:");
        foreach (BankAccount account in Accounts.OrderByDescending(a => a.Balance).Take(3))
        {
            Console.WriteLine($"{account.AccountNumber} | {account.CustomerName} | Balance: {account.Balance}");
        }

        Console.WriteLine("Grouped by account type:");
        var grouped = Accounts.GroupBy(a => a.GetType().Name);
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key} ({group.Count()})");
        }

        Console.WriteLine("Customers with names starting with 'R':");
        foreach (BankAccount account in Accounts.Where(a => a.CustomerName.StartsWith("R", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"{account.CustomerName} | {account.AccountNumber}");
        }
    }

    private static void ShowTransactionHistory()
    {
        BankAccount account = FindAccount();
        if (account == null) return;

        Console.WriteLine($"Transaction history for {account.AccountNumber}:");
        foreach (string entry in account.TransactionHistory)
        {
            Console.WriteLine(entry);
        }
    }

    private static void AddNewAccount()
    {
        Console.WriteLine("Account type: 1. Savings 2. Current 3. Loan");
        Console.Write("Choose: ");
        string typeChoice = Console.ReadLine();

        Console.Write("Account number: ");
        string number = Console.ReadLine();
        Console.Write("Customer name: ");
        string name = Console.ReadLine();
        decimal opening = ReadDecimal("Opening balance: ");

        try
        {
            BankAccount account = typeChoice switch
            {
                "1" => new SavingsAccount(number, name, opening),
                "2" => new CurrentAccount(number, name, opening),
                "3" => new LoanAccount(number, name, opening),
                _ => null
            };

            if (account == null)
            {
                Console.WriteLine("Invalid account type.");
                return;
            }

            Accounts.Add(account);
            Console.WriteLine("Account created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static BankAccount FindAccount()
    {
        Console.Write("Account number: ");
        string number = Console.ReadLine();
        BankAccount account = Accounts.FirstOrDefault(a => a.AccountNumber.Equals(number, StringComparison.OrdinalIgnoreCase));
        if (account == null)
        {
            Console.WriteLine("Account not found.");
        }
        return account;
    }

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal value))
            {
                return value;
            }
            Console.WriteLine("Invalid number.");
        }
    }
}