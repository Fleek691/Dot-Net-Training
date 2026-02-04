public class MovieScreening
{
    public string MovieTitle{get;set;}
    public DateTime ShowTime{get;set;}
    public string ScreeNumber{get;set;}
    public int TotalSeats{get;set;}
    public int BookedSeats{get;set;}
    public double TicketPrice{get;set;}
    public MovieScreening(string title,DateTime time,string number,int seats,double price)
    {
        MovieTitle=title;
        ShowTime=time;
        ScreeNumber=number;
        TotalSeats=seats;
        BookedSeats=0;
        TicketPrice=price;
    }
}