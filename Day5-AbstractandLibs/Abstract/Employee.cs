//Abstract class cant have an instancte
//virtual is able to seal as well using seal method
public abstract class Employee
{
    public abstract void CallTax();


}
public class IndianEmployee : Employee
{
    public override void CallTax()
    {
        System.Console.WriteLine("Indian EMployee Tax is Calculated");
    }
}
public class UsEmployee : Employee
{
    public override void CallTax()
    {
        System.Console.WriteLine("Us Employee Tax is Calculated");
    }
}