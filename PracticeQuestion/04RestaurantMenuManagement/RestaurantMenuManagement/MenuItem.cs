public class MenuItem
{
    public string ItemName{get;set;}
    public string Category{get;set;}
    public double Price{get;set;}
    public bool IsVegetarian{get;set;}
    public MenuItem(string name,string category,double price,bool isVeg)
    {
        ItemName=name;
        Category=category;
        Price=price;
        IsVegetarian=isVeg;
    }
}