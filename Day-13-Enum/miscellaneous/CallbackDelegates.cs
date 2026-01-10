public delegate void Notify(string  message);


class OrderService
{
    public void PlaceOrder(string OrderId,Notify callback)
    {
        Console.WriteLine($"Order {OrderId} placed");
        callback?.Invoke($"Order Id{OrderId} confirmation Sent");

    }
}