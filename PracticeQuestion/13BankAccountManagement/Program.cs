using System;
using System.Linq;

namespace BankAccountManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            BankManager manager = new BankManager();

            Console.WriteLine("=== Bank Account Management System ===\n");

            // Test Case 1: Open different types of accounts
            Console.WriteLine("--- Creating Accounts ---");
            manager.CreateAccount("John Doe", "Savings", 5000);
            manager.CreateAccount("Jane Smith", "Current", 10000);
            manager.CreateAccount("Bob Johnson", "Fixed", 50000);
            manager.CreateAccount("Alice Williams", "Savings", 3000);
            Console.WriteLine();

            // Get account numbers for testing
            var accounts = manager.GetAllAccounts();
            var johnAccount = accounts[0].AccountNumber;
            var janeAccount = accounts[1].AccountNumber;
            var bobAccount = accounts[2].AccountNumber;

            // Test Case 2: Process deposits and withdrawals
            Console.WriteLine("--- Processing Transactions ---");
            manager.Deposit(johnAccount, 2000);
            manager.Withdraw(johnAccount, 1500);
            manager.Deposit(janeAccount, 5000);
            manager.Withdraw(bobAccount, 10000);
            Console.WriteLine();

            // Test Case 3: Check account balances
            Console.WriteLine("--- Account Balances ---");
            manager.DisplayAccountBalance(johnAccount);
            manager.DisplayAccountBalance(janeAccount);
            manager.DisplayAccountBalance(bobAccount);
            Console.WriteLine();

            // Test Case 4: Group accounts by type
            Console.WriteLine("--- Grouping Accounts by Type ---");
            var groupedAccounts = manager.GroupAccountsByType();
            foreach (var group in groupedAccounts)
            {
                Console.WriteLine($"\n{group.Key} Accounts:");
                foreach (var account in group.Value)
                {
                    Console.WriteLine($"  - {account.AccountHolder}: ${account.Balance}");
                }
            }
            Console.WriteLine();

            // Test Case 5: Generate account statements
            Console.WriteLine("--- Account Statement ---");
            var statement = manager.GetAccountStatement(johnAccount, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            Console.WriteLine($"Statement for Account: {johnAccount}");
            Console.WriteLine($"Total Transactions: {statement.Count}");
            foreach (var transaction in statement)
            {
                Console.WriteLine($"  {transaction.TransactionDate:yyyy-MM-dd HH:mm:ss} | {transaction.Type} | ${transaction.Amount} | {transaction.Description}");
            }

            Console.WriteLine("\n=== End of Bank Account Management Demo ===");
        }
    }
}
