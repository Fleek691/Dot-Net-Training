using System.Text;

public class Item
{
    public string ItemName { get; set; }
    public int Qty { get; set; }
    public double Price { get; set; }
}
public class Invoice
{
    public static void Main()
    {
        double Total = 0;
        StringBuilder invoice = new StringBuilder();
        Item item1 = new Item() { ItemName = "Item1", Qty = 1, Price = 100 };
        double itemTotal=item1.Qty*item1.Price;
        invoice.Append($"Price of {item1.ItemName} X {item1.Qty} :{itemTotal} \n");
        Item item2 = new Item() { ItemName = "Item2", Qty = 2, Price = 200 };
        double itemTotal1=item2.Qty*item2.Price;
        invoice.Append($"Price of {item2.ItemName} X {item2.Qty} :{itemTotal1} \n");
        Item item3 = new Item() { ItemName = "Item3", Qty = 3, Price = 300 };
        double itemTotal2=item3.Qty*item3.Price;
        invoice.Append($"Price of {item3.ItemName} X {item3.Qty} :{itemTotal2} \n");
        Item item4 = new Item() { ItemName = "Item4", Qty = 4, Price = 400 };
        double itemTotal3=item4.Qty*item4.Price;
        invoice.Append($"Price of {item4.ItemName} X {item4.Qty} :{itemTotal3} \n");
        Item item5 = new Item() { ItemName = "Item5", Qty = 5, Price = 500 };
        double itemTotal4=item5.Qty*item5.Price;
        invoice.Append($"Price of {item5.ItemName} X {item5.Qty} :{itemTotal4} \n");
        invoice.Append($"Grand total: {Total=itemTotal+itemTotal1+itemTotal2+itemTotal4+itemTotal3}");
        System.Console.WriteLine(invoice);
    }

}