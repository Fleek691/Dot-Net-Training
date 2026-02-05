using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBookingSystem
{
    public class AirlineManager
    {
        private List<Flight> flights = new List<Flight>();
        private List<Booking> bookings = new List<Booking>();
        private Random random = new Random();

        public void AddFlight(string number, string origin, string destination, DateTime depart, DateTime arrive, int seats, double price)
        {
            var flight = new Flight
            {
                FlightNumber = number,
                Origin = origin,
                Destination = destination,
                DepartureTime = depart,
                ArrivalTime = arrive,
                TotalSeats = seats,
                AvailableSeats = seats,
                TicketPrice = price
            };
            flights.Add(flight);
            Console.WriteLine($"Flight {number} scheduled from {origin} to {destination}");
        }

        public bool BookFlight(string flightNumber, string passenger, int seats, string seatClass)
        {
            var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
            if (flight == null)
            {
                Console.WriteLine("Flight not found!");
                return false;
            }

            if (flight.AvailableSeats < seats)
            {
                Console.WriteLine($"Not enough seats available! Only {flight.AvailableSeats} seats remaining.");
                return false;
            }

            double multiplier = seatClass == "Business" ? 2.5 : 1.0;
            double totalFare = flight.TicketPrice * seats * multiplier;

            var booking = new Booking
            {
                BookingId = "BKG" + random.Next(10000, 99999),
                FlightNumber = flightNumber,
                PassengerName = passenger,
                SeatsBooked = seats,
                TotalFare = totalFare,
                SeatClass = seatClass
            };

            bookings.Add(booking);
            flight.AvailableSeats -= seats;

            Console.WriteLine($"Booking successful! Booking ID: {booking.BookingId}, Total Fare: ${totalFare}");
            return true;
        }

        public Dictionary<string, List<Flight>> GroupFlightsByDestination()
        {
            return flights.GroupBy(f => f.Destination)
                         .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Flight> SearchFlights(string origin, string destination, DateTime date)
        {
            return flights.Where(f => f.Origin == origin &&
                                     f.Destination == destination &&
                                     f.DepartureTime.Date == date.Date)
                         .ToList();
        }

        public double CalculateTotalRevenue(string flightNumber)
        {
            return bookings.Where(b => b.FlightNumber == flightNumber)
                          .Sum(b => b.TotalFare);
        }

        public List<Flight> GetAllFlights()
        {
            return flights;
        }

        public List<Booking> GetAllBookings()
        {
            return bookings;
        }
    }
}
