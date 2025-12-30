public class Program
{
    public static void Main(string[] args)
    {
        
        // IndianEmployee Ind=new IndianEmployee();
        // Ind.CallTax();
        // UsEmployee Us=new UsEmployee();
        // Us.CallTax();
        Payment p1=new UpiPayment(499.00M,"abc@oksbi");
        p1.Pay();
        p1.PrintReceipt();
    }
}