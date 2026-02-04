using PieceWorkWageSystem;

public class Bike
{
    public string? Model{get;set;}
    public string? Brand{get;set;}
    public int PricePerDay{get;set;}
}
public class BikeUtility
{
    public void AddBikeDetails(string model, string brand,int pricePerDay)
    {
        int key=BikeProgram.bikeDetails.Count+1;

        BikeProgram.bikeDetails.Add(key,new Bike
        {
            Model=model,
            Brand=brand,
            PricePerDay=pricePerDay,
        });
        System.Console.WriteLine("Bike details Added Successfully");
        
    }
    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> groups=new SortedDictionary<string, List<Bike>>();
        foreach(var bike in BikeProgram.bikeDetails.Values)
        {
            if (!groups.ContainsKey(bike.Brand!))
            {
                groups[bike.Brand]=new List<Bike>();
            }
            groups[bike.Brand].Add(bike);
        }
        return groups;
    }
}
public class BikeProgram
{
    public static SortedDictionary<int,Bike> bikeDetails=new SortedDictionary<int, Bike>();
    public static void Main()
    {
        BikeUtility utility=new BikeUtility();
        int choice=0;
        do
        {
            System.Console.WriteLine("1. Add Bike Details");
            System.Console.WriteLine("2. Group Bikes by Brand");
            System.Console.WriteLine("#. Exit");
            System.Console.WriteLine("Enter your Choice");
            choice=int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the model");
                    string model=Console.ReadLine()!;
                    System.Console.WriteLine("Enter the brand");
                    string brand=Console.ReadLine()!;
                    System.Console.WriteLine("Enter the Price per Day");
                    int price=int.Parse(Console.ReadLine()!);
                    utility.AddBikeDetails(model,brand,price);
                    System.Console.WriteLine("Bike");
                    System.Console.WriteLine();
                    break;
                case 2:
                    var groups=utility.GroupBikesByBrand();
                    foreach(var bike in groups)
                    {
                        System.Console.WriteLine(bike.Key);
                        foreach(var list in bike.Value)
                        {
                            System.Console.WriteLine(list.Model);
                        }
                        System.Console.WriteLine();
                    }
                    break;
                case 3:
                    break;
                default:
                    System.Console.WriteLine("Invalid choice");
                    break;
            }
        }while(choice!=3);
    }

}