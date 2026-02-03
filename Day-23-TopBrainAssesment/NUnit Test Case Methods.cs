public class Program1
{
    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        private set { balance = value; }
    }

    public Program1(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new InvalidOperationException("Initial balance cannot be negative.");
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Deposit amount must be positive.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Withdrawal amount must be positive.");
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds.");
        Balance -= amount;
    }

}
