public class Ques4
{
    public static void Main()
    {
        Queue<(TimeSpan entryTime, string ticketType)> q = new();
        q.Enqueue((new TimeSpan(7, 30, 0), "Regular"));
        q.Enqueue((new TimeSpan(8, 15, 0), "Regular"));
        q.Enqueue((new TimeSpan(9, 0, 0), "VIP"));
        q.Enqueue((new TimeSpan(9, 45, 0), "Regular"));
        q.Enqueue((new TimeSpan(10, 0, 0), "Regular"));
        q.Enqueue((new TimeSpan(10, 30, 0), "Regular"));
        int count=0;
        TimeSpan start = new(8, 0, 0);
        TimeSpan end = new(10, 0, 0);
        while (q.Count > 0)
            {
                var passenger = q.Dequeue();
                if (passenger.ticketType == "Regular" && (start <= passenger.entryTime && end >= passenger.entryTime)) count++;
            }
            System.Console.WriteLine($"Tickets Purchased in Peak Hours Is/Are: {count}");
    }
}