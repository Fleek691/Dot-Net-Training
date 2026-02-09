public class Ticket
{
    public static int LastTicketNo=1000;
    public int TicketNo=LastTicketNo++;
}
public class Helper
{
    public static void Main()
    {
        Ticket t=new Ticket();
        System.Console.WriteLine(t.TicketNo);

        Ticket t1=new Ticket();
        System.Console.WriteLine(t1.TicketNo);

        Ticket t2=new Ticket();
        System.Console.WriteLine(t2.TicketNo);

        Ticket t3=new Ticket();
        System.Console.WriteLine(t3.TicketNo);

        Ticket t4=new Ticket();
        System.Console.WriteLine(t4.TicketNo);

        Ticket t5=new Ticket();
        System.Console.WriteLine(t5.TicketNo);
    }
}