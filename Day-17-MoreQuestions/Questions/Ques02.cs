using System.Data.Common;
public interface IRealEstateListing
{
    int Id{get;set;}
    string? Title{get;set;}
    string? Description{get;set;}
    double Price{get;set;}
    string? Location{get;set;}
}
public class RealEstateListing : IRealEstateListing
{
    public int Id{get;set;}
    public string? Title{get;set;}
    public string? Description{get;set;}
    public double Price{get;set;}
    public string? Location{get;set;}
}
public class RealEstateApp
{
    private List<IRealEstateListing> listing=new List<IRealEstateListing>();
    public void AddListing(IRealEstateListing realEstate)
    {
        listing.Add(realEstate);
    }
    public void RemoveListing(int listingId)
    {
        IRealEstateListing a=null;
        foreach(var item in listing)
        {
            if (item.Id == listingId)
            {
                a=item;
                break;
            }
        }
        if (a != null)
        {
            listing.Remove(a);
        }
    }
    public void UpdateListing(IRealEstateListing realEstate)
    {
        foreach(var item in listing)
        {
            if (item.Id == realEstate.Id)
            {
                item.Description=realEstate.Description;
                item.Location=realEstate.Location;
                item.Price=realEstate.Price;
                item.Title=realEstate.Title;
                break;
            }
            
        }
    }
    public List<IRealEstateListing> GetListing()
    {
        return listing;
    }
    public List<IRealEstateListing> GetListingByLocation(string location)
    {
        List<IRealEstateListing> lo=new List<IRealEstateListing>();
        foreach(var item in listing)
        {
            if (item.Location.ToLower()==location.ToLower())
            {
                lo.Add(item);
            }
        }
        return lo;

    }
    public List<IRealEstateListing> GetListingByPriceRange(int minPrice,int maxPrice)
    {
        List<IRealEstateListing> temp=new List<IRealEstateListing>();
        foreach (var item in listing)
        {
            if(item.Price>=minPrice && item.Price <= maxPrice)
            {
                temp.Add(item);
            }
        }
        return temp;
    }
}
public class Ques2
{
    public static void Main(string[] args)
    {
        RealEstateApp app=new RealEstateApp();
        app.AddListing(new RealEstateListing 
{ 
    Id = 1, 
    Title = "2BHK Apartment", 
    Description = "2 bedroom apartment near city center", 
    Price = 3500000, 
    Location = "Mumbai" 
});

app.AddListing(new RealEstateListing 
{ 
    Id = 2, 
    Title = "Luxury Villa", 
    Description = "Sea-facing luxury villa with private garden", 
    Price = 12500000, 
    Location = "Goa" 
});

app.AddListing(new RealEstateListing 
{ 
    Id = 3, 
    Title = "Studio Flat", 
    Description = "Affordable studio flat for working professionals", 
    Price = 1800000, 
    Location = "Bangalore" 
});

app.AddListing(new RealEstateListing 
{ 
    Id = 4, 
    Title = "Commercial Office Space", 
    Description = "Office space in IT park with parking facility", 
    Price = 7500000, 
    Location = "Hyderabad" 
});

app.AddListing(new RealEstateListing 
{ 
    Id = 5, 
    Title = "Independent House", 
    Description = "Independent house in a quiet residential area", 
    Price = 5200000, 
    Location = "Pune" 
});

foreach(var item in app.GetListing())
        {
            System.Console.WriteLine($"{item.Id} {item.Description} {item.Title} {item.Location} {item.Price}");
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
    app.RemoveListing(3);
    foreach(var item in app.GetListing())
        {
            System.Console.WriteLine($"{item.Id} {item.Description} {item.Title} {item.Location} {item.Price}");
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
        
        var loca=app.GetListingByLocation("Mumbai");
        foreach(var item in loca)
        {
            System.Console.WriteLine($"{item.Id} {item.Description} {item.Title} {item.Location} {item.Price}");
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
        var p=app.GetListingByPriceRange(3000000,6000000);
        foreach(var item in p)
        {
            System.Console.WriteLine($"{item.Id} {item.Description} {item.Title} {item.Location} {item.Price}");
        }
        System.Console.WriteLine();
        System.Console.WriteLine();
        app.UpdateListing(new RealEstateListing
    {
        Id = 1, // IMPORTANT: same Id
        Title = "1BHK Flat (Renovated)",
        Description = "Renovated flat near metro station",
        Price = 2400000,
        Location = "Pune"
    });
    foreach(var item in app.GetListing())
        {
            System.Console.WriteLine($"{item.Id} {item.Description} {item.Title} {item.Location} {item.Price}");
        }
        System.Console.WriteLine();
        System.Console.WriteLine();

    }
}