public class Gym
{
    public static void Main()
    {
        Membership mem=new Membership();
        System.Console.Write("Enter tier: ");
        string tier=Console.ReadLine()!;
        mem.Tier=tier;
        System.Console.Write("Enter duration in months: ");
        int dur=int.Parse(Console.ReadLine()!);
        mem.DurationInMonths=dur;
        System.Console.Write("Enter Base Price: ");
        double price=double.Parse(Console.ReadLine()!);
        mem.BasePricePerMonth=price;
        try
        {
            mem.ValidateEnrollment();
            var va=mem.CalculateBill();
            System.Console.WriteLine($"{va:F2}");
            System.Console.WriteLine("Enrollment Successfull");
        }catch(Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}