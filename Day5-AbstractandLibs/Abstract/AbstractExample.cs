abstract class Payment
{
    public decimal Amount{get;}
    protected Payment(decimal amount)=>Amount=amount;
    public void PrintReceipt()
    {
        System.Console.WriteLine($"Receipt: Amount={Amount}");
    }
    public abstract void Pay();
}
class UpiPayment:Payment
{
    public string UpiId{get;}
    public UpiPayment(decimal amount,string upiId):base(amount )=>UpiId=upiId;
    public override void Pay()
    {
        System.Console.WriteLine($"Paid amount: {Amount}, via Upi Id: {UpiId} ");
    }
}