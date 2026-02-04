using System;

namespace EventManagementSystem
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; } // Concert/Conference/Workshop
        public DateTime EventDate { get; set; }
        public string Venue { get; set; }
        public int TotalCapacity { get; set; }
        public int TicketsSold { get; set; }
        public double TicketPrice { get; set; }
    }
}
