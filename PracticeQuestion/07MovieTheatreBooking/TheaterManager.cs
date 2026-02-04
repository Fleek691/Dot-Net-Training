public class TheatreManager
{
    // In class TheaterManager:
    List<MovieScreening> movieScreenings=new List<MovieScreening>();
    public void AddScreening(string title, DateTime time, string screen,int seats, double price)
    {
        movieScreenings.Add(new MovieScreening(title,time,screen,seats,price));
    }
    // Adds new screening

    public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
    {
        foreach(var item in movieScreenings)
        {
            if (item.MovieTitle == movieTitle && item.ShowTime==showTime)
            {
                if ((item.TotalSeats - item.BookedSeats) >= tickets)
                {
                    item.BookedSeats+=tickets;
                    return true;
                }
            }
        }
        return false;
    }
    // Books tickets if available seats

    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        var group=movieScreenings.GroupBy(e=>e.MovieTitle).ToDictionary(g=>g.Key,g=>g.ToList());
        return group;
    }
    // Groups screenings by movie title

    public double CalculateTotalRevenue()
    {
        double revenue=0;
        foreach(var item in movieScreenings)
        {
            revenue+=item.BookedSeats*item.TicketPrice;
        }
        return revenue;
    }
    // Calculates total revenue from all bookings

    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        var result=movieScreenings.Where(e=>e.TotalSeats-e.BookedSeats>=minSeats).ToList();
        return result;
    }
    // Returns screenings with at least minSeats available

}