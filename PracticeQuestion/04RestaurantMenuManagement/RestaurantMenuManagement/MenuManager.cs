public class MenuManager
{
    private List<MenuItem> menuItems=new List<MenuItem>();
    public void AddMenuItem(string name, string category, double price, bool isVeg)
    {
        if (price > 0)
        {
            menuItems.Add(new MenuItem(name,category,price,isVeg));
        }
        else
        {
            System.Console.WriteLine("Invalid Item");
        }
    }
    // Adds item with validation for price > 0

    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        var result=menuItems.GroupBy(e=>e.Category).ToDictionary(g=>g.Key,g=>g.ToList());
        return result;
    }

    public List<MenuItem> GetVegetarianItems()
    {
        var result=menuItems.Where(e=>e.IsVegetarian==true).ToList();
        return result;
    }
    // Returns all vegetarian items

    public double CalculateAveragePriceByCategory(string category)
    {
        double average=menuItems.Where(e=>e.Category==category).Average(e=>e.Price);
        return average;
    }
    // Returns average price of items in category

}