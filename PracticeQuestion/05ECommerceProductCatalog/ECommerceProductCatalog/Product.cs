public class Product
{
    public string ProductCode{get;set;}
    public string ProductName{get;set;}
    public string Category{get;set;}
    public double Price{get;set;}
    public int StockQuantity{get;set;}
    public Product(string code,string name,string category,double price,int qnt)
    {
        ProductCode=code;
        ProductName=name;
        Category=category;
        Price=price;
        StockQuantity=qnt;
    }

}