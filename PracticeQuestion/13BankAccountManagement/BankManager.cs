using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountManagement
{
    public class BankManager
    {
        private List<Account> accounts = new List<Account>();
        private Random random = new Random();

        public void CreateAccount(string holder, string type, double initialDeposit)
        {
            string accountNumber = "ACC" + random.Next(10000, 99999);
            var account = new Account
            {
                AccountNumber = accountNumber,
                AccountHolder = holder,
                AccountType = type,
                Balance = initialDeposit,
                TransactionHistory = new List<Transaction>()
            };

            if (initialDeposit > 0)
            {
                account.TransactionHistory.Add(new Transaction
                {
                    TransactionId = "TXN" + random.Next(100000, 999999),
                    TransactionDate = DateTime.Now,
                    Type = "Deposit",
                    Amount = initialDeposit,
                    Description = "Initial deposit"
                });
            }

            accounts.Add(account);
            Console.WriteLine($"Account created successfully! Account Number: {accountNumber}");
        }

        public bool Deposit(string accountNumber, double amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found!");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount!");
                return false;
            }

            account.Balance += amount;
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "TXN" + random.Next(100000, 999999),
                TransactionDate = DateTime.Now,
                Type = "Deposit",
                Amount = amount,
                Description = "Cash deposit"
            });

            Console.WriteLine($"Deposited ${amount}. New balance: ${account.Balance}");
            return true;
        }

        public bool Withdraw(string accountNumber, double amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found!");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount!");
                return false;
            }

            if (account.Balance < amount)
            {
                Console.WriteLine("Insufficient balance!");
                return false;
            }

            account.Balance -= amount;
            account.TransactionHistory.Add(new Transaction
            {
                TransactionId = "TXN" + random.Next(100000, 999999),
                TransactionDate = DateTime.Now,
                Type = "Withdrawal",
                Amount = amount,
                Description = "Cash withdrawal"
            });

            Console.WriteLine($"Withdrawn ${amount}. New balance: ${account.Balance}");
            return true;
        }

        public Dictionary<string, List<Account>> GroupAccountsByType()
        {
            return accounts.GroupBy(a => a.AccountType)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found!");
                return new List<Transaction>();
            }

            return account.TransactionHistory
                         .Where(t => t.TransactionDate >= from && t.TransactionDate <= to)
                         .ToList();
        }

        public void DisplayAccountBalance(string accountNumber)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account != null)
            {
                Console.WriteLine($"Account: {accountNumber}, Holder: {account.AccountHolder}, Balance: ${account.Balance}");
            }
        }

        public List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
