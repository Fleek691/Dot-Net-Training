public interface IProduct
{
    string? Name{get;set;}
    string? Category{get;set;}
    int StockQuantity{get;set;}
    int price{get;set;}
}
public interface IInventory
{
    void AddProduct(IProduct product);
    void RemoveProduct(IProduct product);
    int CalculateTotalValue();
    List<IProduct> GetProductByCategory(string category);
    List<(string,int)> GetProductByCategoryWithCount();
    List<IProduct> SearchProductByName(string name);
    List<(string,List<IProduct>)> GetAllProductByCategory();
}

public class Product : IProduct
{
    public string? Name { get;set ; }
    public string? Category { get; set; }
    public int StockQuantity { get; set; }
    public int price { get; set; }
}

public class Inventory : IInventory
{
    private List<IProduct> _products=new List<IProduct>();

    public void AddProduct(IProduct product)
    {
        _products.Add(product);
    }

    public int CalculateTotalValue()
    {
        int total=0;
        foreach(var product in _products)
        {
            total+=product.price*product.StockQuantity;
        }
        return total;
    }

    public List<(string, List<IProduct>)> GetAllProductByCategory()
    {
        List<(string,List<IProduct>)> proCat=new List<(string, List<IProduct>)>();
        foreach(var item in _products)
        {
            string cat=item.Category!;
            bool found=false;
            for(int i = 0; i < proCat.Count; i++)
            {
                if (proCat[i].Item1 == cat)
                {
                    proCat[i].Item2.Add(item);
                    found=true;
                    break;
                }
            }
            if (!found)
            {
                proCat.Add((cat,new List<IProduct>{item}));
            }
        }
        return proCat;
    }

    public List<IProduct> GetProductByCategory(string category)
    {
        List<IProduct> categories=new List<IProduct>();
        foreach(var product in _products)
        {
            if (product.Category!.Equals(category))
            {
                categories.Add(product);
            }
        }
        return categories;
    }

    public List<(string, int)> GetProductByCategoryWithCount()
    {
        List<(string,int)>categoryWithCount=new List<(string, int)>();
        foreach(var item in _products)
        {
            string cat=item.Category!;
            bool found=false;
            for(int i = 0; i < categoryWithCount.Count; i++)
            {
                if (categoryWithCount[i].Item1 == cat)
                {
                    categoryWithCount[i]=(cat,categoryWithCount[i].Item2+1);
                    found=true;
                    break;
                }
            }
            if (!found)
            {
                categoryWithCount.Add((cat,1)!);
            }
        }
        return categoryWithCount;
    }

    public void RemoveProduct(IProduct product)
    {
        _products.Remove(product);
    }

    public List<IProduct> SearchProductByName(string name)
    {
        List<IProduct> res=new List<IProduct>();
        foreach(var product in _products)
        {
            if (product.Name!.Equals(name))
            {
                res.Add(product);
            }
        }
        return res;
    }
}


public class Ques4
{
    public static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        // Create products
        IProduct p1 = new Product { Name = "Laptop", Category = "Electronics", price = 50000, StockQuantity = 2 };
        IProduct p2 = new Product { Name = "Phone", Category = "Electronics", price = 20000, StockQuantity = 3 };
        IProduct p3 = new Product { Name = "Chair", Category = "Furniture", price = 3000, StockQuantity = 5 };
        IProduct p4 = new Product { Name = "Table", Category = "Furniture", price = 7000, StockQuantity = 2 };
        IProduct p5 = new Product { Name = "Headphones", Category = "Electronics", price = 2000, StockQuantity = 4 };

        // Add products
        inventory.AddProduct(p1);
        inventory.AddProduct(p2);
        inventory.AddProduct(p3);
        inventory.AddProduct(p4);
        inventory.AddProduct(p5);

        Console.WriteLine("=== All Products ===");
        foreach (var p in inventory.GetAllProductByCategory())
        {
            Console.WriteLine($"\nCategory: {p.Item1}");
            foreach (var prod in p.Item2)
            {
                Console.WriteLine($"  {prod.Name} | Price: {prod.price} | Qty: {prod.StockQuantity}");
            }
        }

        Console.WriteLine("\n=== Products in Electronics ===");
        foreach (var p in inventory.GetProductByCategory("Electronics"))
        {
            Console.WriteLine($"{p.Name} - {p.price}");
        }

        Console.WriteLine("\n=== Category with Product Count ===");
        foreach (var item in inventory.GetProductByCategoryWithCount())
        {
            Console.WriteLine($"{item.Item1} : {item.Item2}");
        }

        Console.WriteLine("\n=== Search Product by Name: Phone ===");
        foreach (var p in inventory.SearchProductByName("Phone"))
        {
            Console.WriteLine($"{p.Name} - {p.Category}");
        }

        Console.WriteLine("\n=== Total Inventory Value ===");
        Console.WriteLine(inventory.CalculateTotalValue());

        // Remove a product
        inventory.RemoveProduct(p3);

        Console.WriteLine("\nAfter removing Chair:");
        foreach (var p in inventory.GetAllProductByCategory())
        {
            Console.WriteLine($"\nCategory: {p.Item1}");
            foreach (var prod in p.Item2)
            {
                Console.WriteLine($"  {prod.Name} | Price: {prod.price} | Qty: {prod.StockQuantity}");
            }
        }
    }
}
