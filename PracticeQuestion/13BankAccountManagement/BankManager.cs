using System;
using System.Collections.Generic;

namespace BankAccountManagement
{
    public class BankManager
    {
        public void CreateAccount(string holder, string type, double initialDeposit)
        {
        }

        public bool Deposit(string accountNumber, double amount)
        {
            return false;
        }

        public bool Withdraw(string accountNumber, double amount)
        {
            return false;
        }

        public Dictionary<string, List<Account>> GroupAccountsByType()
        {
            return null;
        }

        public List<Transaction> GetAccountStatement(string accountNumber, DateTime from, DateTime to)
        {
            return null;
        }
    }
}
