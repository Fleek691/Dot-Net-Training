using System;

namespace EventManagementSystem
{
    public class Ticket
    {
        public string TicketNumber { get; set; }
        public int EventId { get; set; }
        public int AttendeeId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SeatNumber { get; set; }
    }
}
