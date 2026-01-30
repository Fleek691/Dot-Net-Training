public class Bike
{
    public string Model{get;set;}   
    public string Brand{get;set;}
    public int PricePerDay{get;set;}
}
public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = Program.bikeDetails.Count + 1;

        Program.bikeDetails.Add(key, new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        });
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> grp =
            new SortedDictionary<string, List<Bike>>();

        foreach (var item in Program.bikeDetails.Values)
        {
            if (!grp.ContainsKey(item.Brand))
            {
                grp[item.Brand] = new List<Bike>();
            }
            grp[item.Brand].Add(item);
        }

        return grp;
    }
}

public class Program
{
    public static SortedDictionary<int, Bike> bikeDetails =
        new SortedDictionary<int, Bike>();

    public static void Main(string[] args)
    {
        BikeUtility bu = new BikeUtility();
        int choice;

        do
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the model");
                    string model = Console.ReadLine();

                    Console.WriteLine("Enter the brand");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Enter the price per day");
                    int price = int.Parse(Console.ReadLine());

                    bu.AddBikeDetails(model, brand, price);
                    Console.WriteLine("Bike details added successfully");
                    Console.WriteLine();
                    break;

                case 2:
                    var grp = bu.GroupBikesByBrand();

                    foreach (var brandGroup in grp)
                    {
                        Console.WriteLine(brandGroup.Key);
                        foreach (var bike in brandGroup.Value)
                        {
                            Console.WriteLine(bike.Model);
                        }
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    break;
            }

        } while (choice != 3);
    }
}
