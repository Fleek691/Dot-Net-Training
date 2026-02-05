using System;
using System.Linq;

namespace FlightBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AirlineManager manager = new AirlineManager();

            Console.WriteLine("=== Flight Booking System ===\n");

            // Test Case 1: Schedule flights
            Console.WriteLine("--- Scheduling Flights ---");
            manager.AddFlight("AA101", "New York", "London", new DateTime(2026, 2, 10, 8, 0, 0), new DateTime(2026, 2, 10, 20, 0, 0), 200, 500);
            manager.AddFlight("AA102", "New York", "Paris", new DateTime(2026, 2, 10, 9, 0, 0), new DateTime(2026, 2, 10, 21, 0, 0), 180, 600);
            manager.AddFlight("AA103", "London", "Dubai", new DateTime(2026, 2, 11, 10, 0, 0), new DateTime(2026, 2, 11, 18, 0, 0), 250, 700);
            manager.AddFlight("AA104", "New York", "London", new DateTime(2026, 2, 10, 14, 0, 0), new DateTime(2026, 2, 11, 2, 0, 0), 200, 550);
            manager.AddFlight("AA105", "Paris", "Tokyo", new DateTime(2026, 2, 12, 11, 0, 0), new DateTime(2026, 2, 13, 7, 0, 0), 300, 900);
            Console.WriteLine();

            // Test Case 2: Book tickets
            Console.WriteLine("--- Booking Tickets ---");
            manager.BookFlight("AA101", "John Doe", 2, "Economy");
            manager.BookFlight("AA101", "Jane Smith", 1, "Business");
            manager.BookFlight("AA102", "Bob Johnson", 3, "Economy");
            manager.BookFlight("AA103", "Alice Williams", 2, "Business");
            Console.WriteLine();

            // Test Case 3: Search flights by route
            Console.WriteLine("--- Searching Flights (New York to London on 2026-02-10) ---");
            var searchResults = manager.SearchFlights("New York", "London", new DateTime(2026, 2, 10));
            foreach (var flight in searchResults)
            {
                Console.WriteLine($"Flight {flight.FlightNumber}: Departs at {flight.DepartureTime:HH:mm}, Available Seats: {flight.AvailableSeats}, Price: ${flight.TicketPrice}");
            }
            Console.WriteLine();

            // Test Case 4: Group flights by destination
            Console.WriteLine("--- Grouping Flights by Destination ---");
            var groupedFlights = manager.GroupFlightsByDestination();
            foreach (var group in groupedFlights)
            {
                Console.WriteLine($"\nDestination: {group.Key}");
                foreach (var flight in group.Value)
                {
                    Console.WriteLine($"  - Flight {flight.FlightNumber} from {flight.Origin}, Departs: {flight.DepartureTime:yyyy-MM-dd HH:mm}");
                }
            }
            Console.WriteLine();

            // Test Case 5: Calculate flight revenue
            Console.WriteLine("--- Calculating Flight Revenue ---");
            var allFlights = manager.GetAllFlights();
            foreach (var flight in allFlights.Where(f => manager.CalculateTotalRevenue(f.FlightNumber) > 0))
            {
                double revenue = manager.CalculateTotalRevenue(flight.FlightNumber);
                Console.WriteLine($"Flight {flight.FlightNumber}: Total Revenue = ${revenue}");
            }

            Console.WriteLine("\n=== End of Flight Booking System Demo ===");
        }
    }
}
