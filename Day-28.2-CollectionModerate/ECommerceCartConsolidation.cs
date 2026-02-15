public class Ques1
{
    public static void Main()
    {
        List<(string sky, int qty)> scans = new();
        System.Console.WriteLine("Enter number of scans: ");
        int n = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter details (sku,qty): ");
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine()!;
            string[] parts = input.Split(",");
            scans.Add((parts[0], int.Parse(parts[1])));
        }
        Dictionary<string,int> skuQty=new Dictionary<string, int>();
        for(int i = 0; i < n; i++)
        {
            if (scans[i].qty <= 0)
            {
                continue;
            }
            if (skuQty.ContainsKey(scans[i].sky))
            {
                skuQty[scans[i].sky]+=scans[i].qty;
                continue;
            }
            skuQty[scans[i].sky]=scans[i].qty;
        }
        foreach(var item in skuQty)
        {
            System.Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}