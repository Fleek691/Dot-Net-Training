public class Ques5
{
    public static void Main(string[] args)
    {
        
        try
        {
            EcommerceShop Emily=MakePayment("Emily",1000,1001);
            if (Emily != null)
            {
                System.Console.WriteLine("Payment Successful");
            }
        }
        catch(InsufficientWalletBalanceException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    public static EcommerceShop MakePayment(string name,double balance, double amount)
    {
        


        if (balance < amount)
        {
            throw new InsufficientWalletBalanceException();
        } 
        EcommerceShop ecom=new EcommerceShop
        {
          UserName=name,
          WalletBalance=balance,
          TotalPurchaseAmount=amount,  
        };
        return ecom;
    }
   
}

public class EcommerceShop
{
    public string? UserName{get;set;}
    public double WalletBalance{get;set;}
    public double TotalPurchaseAmount{get;set;}

}
 public class InsufficientWalletBalanceException : Exception
{
    public override string Message => "Insufficient balance in your digital wallet";
}