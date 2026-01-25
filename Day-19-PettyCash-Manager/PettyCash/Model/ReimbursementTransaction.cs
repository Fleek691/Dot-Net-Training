namespace PettyCash.Model
{
    public class ReimbursementTransaction : Transaction
    {
        public string ReferenceNumber{get;protected set;}
        public ReimbursementTransaction(decimal amount,DateTime date,User requestedBy,string referenceNumber) : base(amount, date, requestedBy)
        {
            this.ReferenceNumber=referenceNumber;
        }
    }
}