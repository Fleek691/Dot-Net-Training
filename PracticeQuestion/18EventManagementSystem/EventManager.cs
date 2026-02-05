using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementSystem
{
    public class EventManager
    {
        private List<Event> events = new List<Event>();
        private List<Attendee> attendees = new List<Attendee>();
        private List<Ticket> tickets = new List<Ticket>();
        private Random random = new Random();

        public void CreateEvent(string name, string type, DateTime date, string venue, int capacity, double price)
        {
            int eventId = events.Count + 1;
            var eventItem = new Event
            {
                EventId = eventId,
                EventName = name,
                EventType = type,
                EventDate = date,
                Venue = venue,
                TotalCapacity = capacity,
                TicketsSold = 0,
                TicketPrice = price
            };
            events.Add(eventItem);
            Console.WriteLine($"Event '{name}' created with ID: {eventId}");
        }

        public bool BookTicket(int eventId, int attendeeId, string seatNumber)
        {
            var eventItem = events.FirstOrDefault(e => e.EventId == eventId);
            if (eventItem == null)
            {
                Console.WriteLine("Event not found!");
                return false;
            }

            if (eventItem.TicketsSold >= eventItem.TotalCapacity)
            {
                Console.WriteLine("Event is fully booked!");
                return false;
            }

            var attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
            if (attendee == null)
            {
                attendee = new Attendee
                {
                    AttendeeId = attendeeId,
                    Name = $"Attendee{attendeeId}",
                    Email = $"attendee{attendeeId}@example.com",
                    Phone = $"555-{attendeeId:D4}",
                    RegisteredEvents = new List<int>()
                };
                attendees.Add(attendee);
            }

            var ticket = new Ticket
            {
                TicketNumber = "TKT" + random.Next(100000, 999999),
                EventId = eventId,
                AttendeeId = attendeeId,
                PurchaseDate = DateTime.Now,
                SeatNumber = seatNumber
            };

            tickets.Add(ticket);
            eventItem.TicketsSold++;
            attendee.RegisteredEvents.Add(eventId);

            Console.WriteLine($"Ticket {ticket.TicketNumber} booked for {attendee.Name} at {eventItem.EventName}");
            return true;
        }

        public Dictionary<string, List<Event>> GroupEventsByType()
        {
            return events.GroupBy(e => e.EventType)
                        .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Event> GetUpcomingEvents(int days)
        {
            var endDate = DateTime.Now.AddDays(days);
            return events.Where(e => e.EventDate >= DateTime.Now && e.EventDate <= endDate)
                        .OrderBy(e => e.EventDate)
                        .ToList();
        }

        public double CalculateEventRevenue(int eventId)
        {
            var eventItem = events.FirstOrDefault(e => e.EventId == eventId);
            if (eventItem == null)
            {
                return 0;
            }
            return eventItem.TicketsSold * eventItem.TicketPrice;
        }

        public List<Event> GetAllEvents()
        {
            return events;
        }

        public List<Ticket> GetAllTickets()
        {
            return tickets;
        }
    }
}
