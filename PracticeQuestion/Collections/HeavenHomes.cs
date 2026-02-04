public class Apartment
{
    private Dictionary<string,double>?apartmentDetailsMap{get;set;} = new Dictionary<string, double>();
    public void addApartmentDetails(string apartmentNumber,double rent)
    {
        apartmentDetailsMap![apartmentNumber]=rent;
    }
    public double findTotalRentOfApartmentsinTheGivenRange(double minmumRent,double maximumRent)
    {
        var result=apartmentDetailsMap!
                    .Where(x=>x.Value>=minmumRent && x
                    .Value<=maximumRent)
                    .Sum(x=>x.Value);
        return result;
    }
}
public class UserInterfaceC3
{
    public static void Main()
    {
        Apartment apartment=new Apartment();
        System.Console.WriteLine("Enter number of details to be added");
        int num=int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter the details(Apartmentnumber: Rent)");
        for(int i = 0; i < num; i++)
        {
            string input=Console.ReadLine()!;
            string[] parts=input.Split(":");
            apartment.addApartmentDetails(parts[0],double.Parse(parts[1]));
        }
        System.Console.WriteLine("Enter the range to filter the details");
        double minRent=double.Parse(Console.ReadLine()!);
        double maxRent=double.Parse(Console.ReadLine()!);
        var totalSum=apartment.findTotalRentOfApartmentsinTheGivenRange(minRent,maxRent);
        System.Console.WriteLine($"Total Rent in the range {minRent:C1} to {maxRent:F2} USD:{totalSum:F3}");
    }
}