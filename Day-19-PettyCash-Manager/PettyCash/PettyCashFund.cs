using PettyCash.Model;

public class PettyCashFund
{
    public int FundId{get;protected set;}
    public string FundName{get;protected set;}
    public decimal OpeningBalance{get;set;}
    public DateTime CreatedDate{get;set;}
    private readonly List<Transaction> _transactions;
    public PettyCashFund(int funId,string fundName,decimal openingBalance)
    {
        this.FundId=funId;
        this.FundName=fundName;
        this.OpeningBalance=openingBalance;
        this.CreatedDate=DateTime.Now;
        this._transactions=new List<Transaction>();
    }
    public void AddTransaction(Transaction transaction)
    {
        if (transaction != null)
        {
            _transactions.Add(transaction);
        }
        else
        {
            throw new ArgumentNullException(nameof(transaction));
        }
    }

    public decimal CalculateCurrentBalance()
    {
        decimal balance=OpeningBalance;
        return balance;
    }
}