namespace FlightBookingSystem
{
    public class Booking
    {
        public string BookingId { get; set; }
        public string FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public int SeatsBooked { get; set; }
        public double TotalFare { get; set; }
        public string SeatClass { get; set; } // Economy/Business
    }
}
