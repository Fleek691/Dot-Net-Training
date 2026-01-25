using PettyCash.Enums;

namespace PettyCash.Model
{
    public class ExpenseTransaction : Transaction
    {
        public Category Category{get;protected set;}
        public string voucherNumber{get;protected set;}
        public ExpenseTransaction(decimal amount,DateTime date,User requestedBy,Category category,string VoucherNumber) : base(amount, date, requestedBy)
        {
            this.Category=category;
            this.voucherNumber=VoucherNumber;
        }
    }
}