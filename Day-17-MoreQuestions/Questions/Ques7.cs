using System.Globalization;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
interface ICategory
{
    int Id { get; set; }
    string Name { get; set; }
    List<IProduct> Products { get; set; }
    void AddProduct(IProduct product);
}
interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
}
interface ICompany
{
    //The top category name by product count
    string GetTopCategoryNameByProductCount();
    //The products are added to more than one category
    List<IProduct> GetProductsBelongsToMultipleCategory();
    //Top category according to the total price of its products
    (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices();
    //The list of categories with the sum of the prices of the products
    List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices();
}
/*
* Create Category,Product and Company classes by implementing
* ICategory,
* IProcduct,
* ICompany interfaces.
*/
class Company : ICompany
{
    public int Id{get;set;}
    public string Name{get;set;}
    public List<ICategory> Categories;
    public Company(int id,string name){
        this.Id=id;
        this.Name=name;
        Categories=new List<ICategory>();
    }
    public void AddCategory(ICategory category){
        Categories.Add(category);
    }
    public List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices()
    {
        List<(ICategory category,decimal totalValue)> res=new List<(ICategory category, decimal totalValue)>();
        foreach(var item in Categories){
            decimal sum=0;
            foreach(var product in item.Products){
                sum+=product.Price;
            }
            res.Add((item,sum));
            
        }
        return res;
    }

    public List<IProduct> GetProductsBelongsToMultipleCategory()
    {
        List<IProduct>products=new List<IProduct>();
        Dictionary<IProduct,int> count=new Dictionary<IProduct, int>();
        foreach(var cat in Categories){
            foreach(var prod in cat.Products){
                if(count.ContainsKey(prod)){
                    count[prod]+=1;
                }else{
                    count.Add(prod,1);
                }
            }
        }
        foreach(var item in count){
            if(item.Value>1){
                products.Add(item.Key);
            }
        }
        return products;
    }

    public (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices()
    {
        string categoryName="";
        decimal totalValue=0;
        foreach(var item in Categories){
            decimal sum=0;
            foreach(var product in item.Products){
                sum+=product.Price;
            }
            if(sum>totalValue){
                totalValue=sum;
                categoryName=item.Name;
            }
        }
        return (categoryName,totalValue);
    }

    public string GetTopCategoryNameByProductCount()
    {
        string categoryName="";
        int count=0;
        foreach(var item in Categories){
            if(item.Products.Count>count){
                count=item.Products.Count;
                categoryName=item.Name;
            }
        }
        return categoryName;
    }
}
class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(int id,string name,decimal price){
        this.Id=id;
        this.Name=name;
        this.Price=price;
    }
}
class Category : ICategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IProduct> Products { get; set; }
    public Category(int id,string name){
        this.Id=id;
        this.Name=name;
        Products=new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        Products.Add(product);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        var company = new Company(1, "Company 1");
        List<IProduct> products = new List<IProduct>();
        List<ICategory> categories = new List<ICategory>();
        int n = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= n; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            products.Add(new Product(Convert.ToInt32(a[0]), a[1], Convert.ToInt32(a[2])));
        }
        int m = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= m; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            categories.Add(new Category(Convert.ToInt32(a[0]), a[1]
            ));
        }
        int p = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= p; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            var c = categories.FirstOrDefault(x => x.Id == Convert.ToInt32(a[0]));
            var pp = products.FirstOrDefault(x => x.Id == Convert.ToInt32(a[1]));
            if (c != null && pp != null)
            {
                c.AddProduct(pp);
            }
        }
        foreach (var item in categories)
        {
            company.AddCategory(item);
        }
        var topCategory = company.GetTopCategoryNameByProductCount(
        );
        var commonProducts = company.GetProductsBelongsToMultipleCategory();
        var mostValuableCategory = company.GetTopCategoryBySumOfProductPrices();
        var categoriesWithTotalPrices = company.GetCategoriesWithSumOfTheProductPrices();
        textWriter.WriteLine("Top category:" + topCategory);
        textWriter.WriteLine("Common products:");
        foreach (var item in commonProducts)
        {
            textWriter.WriteLine(item.Name);
        }
        textWriter.WriteLine("Most valuable category:" + mostValuableCategory.categoryName
        + " " + mostValuableCategory.totalValue.ToString("0.0",new NumberFormatInfo() { NumberDecimalSeparator = "." }));
        foreach (var item in categoriesWithTotalPrices)
        {
            textWriter.WriteLine(item.category.Name + " " + item.totalValue.ToString("0.0", new NumberFormatInfo() { NumberDecimalSeparator = "." }));
        }
        textWriter.Flush();
        textWriter.Close();
    }
}