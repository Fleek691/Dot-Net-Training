
public class Jewellery
{
    public string Type { get; set; }
    public string Id { get; set; }
    public string Material { get; set; }
    public int Price { get; set; }
    public Jewellery(string type, string id, string material, int price)
    {
        Type = type;
        Id = id;
        Material = material;
        Price = price;
    }
}

public class Jewelleryutility
{

    public static Dictionary<string, string> GetJewelleryDetails(string id)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
            var found = Program.jewelleryDetails.Values.FirstOrDefault(j => j.Id == id);
            if (found == null) return result;
            string concatenated = found.Type + "_" + found.Material;
        result[id] = concatenated;
        return result;
    }
    public Dictionary<string, Jewellery> UpdateJewelleryPrice(string id, int price)
    {
        Dictionary<string, Jewellery> updatePriceList = new Dictionary<string, Jewellery>();
            var found = Program.jewelleryDetails.Values.FirstOrDefault(j => j.Id == id);
            if (found == null) return updatePriceList;
            found.Price = price;
            updatePriceList[id] = found;
        return updatePriceList;
    }
}
public class Program
{
    public static Dictionary<int, Jewellery> jewelleryDetails = new();

    public static void Main()
    {
        
        jewelleryDetails.Add(1, new Jewellery("Bracelet", "JW01", "Silver", 5000));
        jewelleryDetails.Add(2, new Jewellery("Ring", "JW02", "Platinum", 8000));
        jewelleryDetails.Add(3, new Jewellery("Necklace", "JW03", "Gold", 15000));

        while (true)
        {
            Console.WriteLine("1. Get Jewellery Details");
            Console.WriteLine("2. Update Price");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.WriteLine("Enter the jewellery id");
                string id = Console.ReadLine();
                var result = Jewelleryutility.GetJewelleryDetails(id);
                if (result.Count == 0)
                {
                    Console.WriteLine("Jewellery id not found");
                }
                else
                {
                    foreach (var kvp in result)
                    {
                        Console.WriteLine($"{kvp.Key}   {kvp.Value}");
                    }
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter the jewellery id");
                string id = Console.ReadLine();
                Console.WriteLine("Enter the price to be updated");
                string priceInput = Console.ReadLine();
                int price;
                if (!int.TryParse(priceInput, out price))
                {
                    Console.WriteLine("Invalid price");
                    continue;
                }
                var result = new Jewelleryutility().UpdateJewelleryPrice(id, price);
                if (result.Count == 0)
                {
                    Console.WriteLine("Jewellery id not found");
                }
                else
                {
                    foreach (var kvp in result)
                    {
                        var j = kvp.Value;
                        Console.WriteLine($"Id : {j.Id},    Type : {j.Type},    Material : {j.Material},    Price : {j.Price}");
                    }
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Thank you");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }
    }
}