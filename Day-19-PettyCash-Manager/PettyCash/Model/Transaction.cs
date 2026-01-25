using PettyCash.Enums;
namespace PettyCash.Model
{
    public abstract class Transaction
    {
        public int Id{get;private set;}
        public decimal Amount{get;protected set;}
        public DateTime Date{get;protected set;}
        public string? Narration{get;protected set;}
        public TransactionStatus Status{get;private set;}
        public User RequestedBy{get;protected set;}
        public User? ApprovedBy{get;protected set;}

        protected Transaction(decimal amount,DateTime date,User requestedBy)
        {
            if (amount < 0)
            {
                System.Console.WriteLine("Invalid Amount");
            }
            else
            {
                this.Amount=amount;
            }
           
            this.Date=date;
            this.RequestedBy=requestedBy;
            this.Status=TransactionStatus.Pending;
        }

    }
}
