public abstract class DiscountPolicy
{
    public abstract double GetFinalAmount(double amount);
}
public class FestiveDIscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        double discountedAmouunt=0;
        if(amount>=5000){
            discountedAmouunt=amount-(amount*10/100);
        }
        else
        {
            discountedAmouunt=amount-(amount*5/100);
        }
        return discountedAmouunt;
    }
}
public class MemberDIscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        double discountedAmouunt=0;
        if(amount>=2000){
            discountedAmouunt=amount-300;
        }
        else
        {
            discountedAmouunt=amount;
        }
        return discountedAmouunt;
    }
}
public class Helper
{
    public static void Main()
    {
        System.Console.Write("Enter policy:(Festival,Member) ");
        string policy=Console.ReadLine()!;
        System.Console.Write("Enter amount: ");
        double amount=double.Parse(Console.ReadLine()!);
        DiscountPolicy dp=null!;
        if (policy.Equals("Festival", StringComparison.OrdinalIgnoreCase))
        {
            dp=new FestiveDIscount();            
        }else if(policy.Equals("Member", StringComparison.OrdinalIgnoreCase))
        {
            dp=new MemberDIscount();
        }
        else
        {
            System.Console.WriteLine("Invalid Policy");
            return;
        }
        double finalAMount=dp.GetFinalAmount(amount);
        System.Console.WriteLine($"Total Payable Amount: {finalAMount}");
    }
}