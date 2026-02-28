namespace FlightSearchEngine.Models;

public class FlightHotelResult
{
    public int FlightId { get; set; }
    public required string FlightName { get; set; }
    public required string Source { get; set; }
    public required string Destination { get; set; }
    public required string HotelName { get; set; }
    public decimal TotalCost { get; set; }
}