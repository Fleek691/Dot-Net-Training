using Microsoft.VisualBasic;

public class CakeOrder
{
    private Dictionary<string,double> orderMap = new Dictionary<string,double>();
    public void addOrderDetails(string orderId,double cakeCost)
{
    orderMap.Add(orderId, cakeCost);
}
    public Dictionary<string,double>findOrdersAboveSpecifiedCost(double cakeCost)
    {
        var result=orderMap!.Where(x=>x.Value>cakeCost).ToDictionary(x=>x.Key,x=>x.Value);
        return result;
    }
}
public class UserInterfaceC1
{
    public static void Main(string[] args)
    {
        CakeOrder orderList=new CakeOrder();
        System.Console.WriteLine("Enter the number of cakes to be added");
        int n=int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter the cake order details(OrderId:CakeCost)");
        for(int i = 0; i < n; i++)
        {
            string input=Console.ReadLine()!;
            string[]parts=input.Split(":");
            orderList.addOrderDetails(parts[0],int.Parse(parts[1]));
        }
        System.Console.WriteLine("Enter the cost to search the cake orders");
        int cost=int.Parse(Console.ReadLine()!);
        var orders=orderList.findOrdersAboveSpecifiedCost(cost);
        if (orders.Count > 0)
        {
            System.Console.WriteLine("Cake Orders above the specified cost");
            foreach (var item in orders)
            {
                System.Console.WriteLine($"Order ID: {item.Key}, Cake Cost: {item.Value}");
            }
        }
        else
        {
            System.Console.WriteLine("No cake orders found");
        }

    }
}

