using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
abstract class GroceryReceiptBase2
{
public Dictionary<string, decimal> Prices { get; set; }
public Dictionary<string, int> Discounts { get; set; }
public GroceryReceiptBase2(Dictionary<string, decimal> prices, Dictionary<string, int> discounts)
{
Prices = prices;
Discounts = discounts;
}
public abstract IEnumerable<(string fruit, decimal price, decimal total)>
Calculate(List<Tuple<string, int>> shoppingList);
}
class GroceryReceipt2: GroceryReceiptBase2
{
    public GroceryReceipt2(Dictionary<string, decimal> prices, Dictionary<string, int> discounts) : base(prices, discounts)
    {
        
    }

    public override IEnumerable<(string fruit, decimal price, decimal total)> Calculate(List<Tuple<string, int>> shoppingList)
    {
        var result=new List<(string fruit,decimal price,decimal total)>();
        string fruit="";
        decimal price=0;
        decimal total=0;
        decimal discountedPrice=0;
        foreach(var item in shoppingList)
        {
            fruit=item.Item1;
            price=Prices[item.Item1];
            if (Discounts.ContainsKey(item.Item1))
            {
                discountedPrice=price-(price*(decimal)Discounts[item.Item1]/100);
            }
            else
            {
                discountedPrice=price;
            }
            
            total=discountedPrice*item.Item2;
            result.Add((fruit,price,total));
        }
        var sorted=result.OrderBy(x=>x.fruit).ToList();
        return sorted;
    }
}
class Ques5
{
public static void Main(string[] args)
{
List<Tuple<string, int>> boughtItems = new List<Tuple<string, int>>();
Dictionary<string, decimal> prices = new Dictionary<string, decimal>();
Dictionary<string, int> discounts = new Dictionary<string, int>();
int n = Convert.ToInt32(Console.ReadLine()!.Trim());
for (int i = 0; i < n; i++)
{
var a = Console.ReadLine()!.Trim().Split(' ');
prices.Add(a[0], Convert.ToDecimal(a[1]));
}
int m = Convert.ToInt32(Console.ReadLine()!.Trim());
for (int i = 0; i < m; i++)
{
var a = Console.ReadLine()!.Trim().Split(' ');
discounts.Add(a[0], Convert.ToInt32(a[1]));
}
int b = Convert.ToInt32(Console.ReadLine()!.Trim());
for (int i = 0; i < b; i++)
{
var a = Console.ReadLine()!.Trim().Split(' ');
boughtItems.Add(new Tuple<string, int>(a[0], Convert.ToInt32(a[1])));
}
var g = new GroceryReceipt2(prices, discounts);
var result = g.Calculate(boughtItems);
foreach (var x in result)
{
Console.WriteLine($"{x.fruit} {x.price.ToString("0.0", new NumberFormatInfo() {
NumberDecimalSeparator = "." })} {x.total.ToString("0.0", new NumberFormatInfo() { NumberDecimalSeparator
= "." })}");
}
}
}