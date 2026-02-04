using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        // TODO:
        // 1. Process each order
        // 2. Throw exception for invalid order ID
        // 3. Ensure one failure does not stop processing

        foreach (int orderId in orders)
        {
            try
            {
                ProcessOrder(orderId);
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine($"Error processing order {orderId}: {ex.Message}");
            }
        }

        System.Console.WriteLine("All orders processed.");
    }

    static void ProcessOrder(int orderId)
    {
        if (orderId <= 0)
        {
            throw new ArgumentException("Invalid order ID. Order ID must be positive.");
        }

        System.Console.WriteLine($"Order {orderId} processed successfully.");
    }
}