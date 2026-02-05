using System;
using System.Linq;

namespace EventManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EventManager manager = new EventManager();

            Console.WriteLine("=== Event Management System ===\n");

            // Test Case 1: Create different types of events
            Console.WriteLine("--- Creating Events ---");
            manager.CreateEvent("Rock Music Festival", "Concert", new DateTime(2026, 3, 15, 18, 0, 0), "Madison Square Garden", 200, 75.00);
            manager.CreateEvent("Tech Conference 2026", "Conference", new DateTime(2026, 2, 20, 9, 0, 0), "Convention Center", 500, 299.00);
            manager.CreateEvent("Jazz Night", "Concert", new DateTime(2026, 2, 8, 20, 0, 0), "Blue Note Club", 100, 45.00);
            manager.CreateEvent("Python Workshop", "Workshop", new DateTime(2026, 2, 12, 10, 0, 0), "Tech Hub", 50, 99.00);
            manager.CreateEvent("Leadership Summit", "Conference", new DateTime(2026, 4, 5, 8, 30, 0), "Grand Hotel", 300, 399.00);
            manager.CreateEvent("Art Exhibition Opening", "Workshop", new DateTime(2026, 2, 18, 17, 0, 0), "Modern Art Museum", 150, 25.00);
            Console.WriteLine();

            // Test Case 2: Book tickets for events
            Console.WriteLine("--- Booking Tickets ---");
            manager.BookTicket(1, 1001, "A15");
            manager.BookTicket(1, 1002, "A16");
            manager.BookTicket(1, 1003, "B10");
            manager.BookTicket(2, 1004, "C45");
            manager.BookTicket(2, 1005, "C46");
            manager.BookTicket(3, 1001, "D5");
            manager.BookTicket(4, 1006, "E12");
            manager.BookTicket(4, 1007, "E13");
            Console.WriteLine();

            // Test Case 3: Group events by type
            Console.WriteLine("--- Grouping Events by Type ---");
            var groupedEvents = manager.GroupEventsByType();
            foreach (var group in groupedEvents)
            {
                Console.WriteLine($"\n{group.Key} Events:");
                foreach (var evt in group.Value)
                {
                    Console.WriteLine($"  - {evt.EventName} at {evt.Venue} on {evt.EventDate:yyyy-MM-dd}");
                }
            }
            Console.WriteLine();

            // Test Case 4: View upcoming events
            Console.WriteLine("--- Upcoming Events (Next 30 days) ---");
            var upcomingEvents = manager.GetUpcomingEvents(30);
            if (upcomingEvents.Count > 0)
            {
                foreach (var evt in upcomingEvents)
                {
                    int availableSeats = evt.TotalCapacity - evt.TicketsSold;
                    Console.WriteLine($"  - {evt.EventName} ({evt.EventType}) - {evt.EventDate:yyyy-MM-dd HH:mm} at {evt.Venue}");
                    Console.WriteLine($"    Tickets: {evt.TicketsSold}/{evt.TotalCapacity} sold, {availableSeats} available");
                }
            }
            else
            {
                Console.WriteLine("No upcoming events in the next 30 days.");
            }
            Console.WriteLine();

            // Test Case 5: Calculate event revenue
            Console.WriteLine("--- Event Revenue Report ---");
            var allEvents = manager.GetAllEvents();
            double totalRevenue = 0;
            foreach (var evt in allEvents.Where(e => e.TicketsSold > 0))
            {
                double revenue = manager.CalculateEventRevenue(evt.EventId);
                Console.WriteLine($"{evt.EventName}: ${revenue:N2} (from {evt.TicketsSold} tickets)");
                totalRevenue += revenue;
            }
            Console.WriteLine($"\nTotal Revenue from all events: ${totalRevenue:N2}");

            Console.WriteLine("\n=== End of Event Management System Demo ===");
        }
    }
}
