namespace FlightSearchEngine.Models;

public class FlightResult
{
    public int FlightId { get; set; }
    public required string FlightName { get; set; }
    public required string FlightType { get; set; }
    public required string Source { get; set; }
    public required string Destination { get; set; }
    public decimal TotalCost { get; set; }
}