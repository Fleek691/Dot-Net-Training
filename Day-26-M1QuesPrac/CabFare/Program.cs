using System.Diagnostics;

public class Cab
{
    public virtual void CalculateFare(int km){}
}
public class Mini: Cab
{
    public override void CalculateFare(int km)
    {
        System.Console.WriteLine($"Fare is {km*12}");
    }
}
public class Sedan: Cab
{
    public override void CalculateFare(int km)
    {
        System.Console.WriteLine($"Fare is {km*15+50}");
    }
}
public class SUV: Cab
{
    public override void CalculateFare(int km)
    {
        System.Console.WriteLine($"Fare is {km*18+100}");
    }
}
public class Helper
{
    public static void Main()
    {
        System.Console.WriteLine("Enter Cab Type: (Mini,Sedan,Suv) ");
        string cabType=Console.ReadLine()!;
        System.Console.WriteLine("Enter distance");
        int km=int.Parse(Console.ReadLine()!);
        Cab cab=null;
        if (cabType == "Mini")
        {
            cab=new Mini();
        }
        else if (cabType == "Sedan")
        {
            cab=new Sedan();
        }
        else if (cabType.Equals("SUV",StringComparison.OrdinalIgnoreCase))
        {
            cab=new SUV();
        }
        else
        {
            System.Console.WriteLine("Enter a valid type.");
            return;
        }
        cab.CalculateFare(km);
    }
}