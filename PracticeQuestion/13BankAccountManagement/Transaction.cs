using System;
using System.Collections.Generic;

namespace BankAccountManagement
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Type { get; set; } // Deposit/Withdrawal/Transfer
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
