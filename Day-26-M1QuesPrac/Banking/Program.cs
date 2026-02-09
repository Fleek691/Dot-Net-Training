public class BankAccount
{
    private double Balance;
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance+=amount;
        }
        else
        {
            System.Console.WriteLine("Invalid Amount");
        }
    }
    public void Withdraw(double amount)
    {
        if(amount>0 && amount <= Balance)
        {
            Balance-=amount;
            System.Console.WriteLine($"Successfull, curr balance: {Balance}");
        }
        else
        {
            System.Console.WriteLine("Insufficient Balance");
        }
    }
}
public class Helper
{
    public static void Main()
    {
        BankAccount ba=new BankAccount();
        ba.Deposit(500);
        ba.Withdraw(250);
        ba.Deposit(1000);
        ba.Withdraw(250);
        ba.Withdraw(900);
    }
}