using System;
using System.Collections.Generic;

class Program1
{
    static void Main()
    {
        TheatreManager manager = new TheatreManager();

        // 1️⃣ Add movie screenings
        manager.AddScreening(
            "Inception",
            new DateTime(2026, 2, 5, 10, 0, 0),
            "Screen 1",
            100,
            250
        );

        manager.AddScreening(
            "Inception",
            new DateTime(2026, 2, 5, 14, 0, 0),
            "Screen 2",
            120,
            300
        );

        manager.AddScreening(
            "Interstellar",
            new DateTime(2026, 2, 5, 18, 0, 0),
            "Screen 1",
            150,
            350
        );

        Console.WriteLine("Screenings added.\n");

        // 2️⃣ Book tickets
        bool bookingResult = manager.BookTickets(
            "Inception",
            new DateTime(2026, 2, 5, 10, 0, 0),
            5
        );

        Console.WriteLine(
            bookingResult ? "Tickets booked successfully.\n" : "Booking failed.\n"
        );

        // 3️⃣ Group screenings by movie
        Console.WriteLine("Screenings grouped by movie:");
        var grouped = manager.GroupScreeningsByMovie();

        foreach (var movie in grouped)
        {
            Console.WriteLine($"\nMovie: {movie.Key}");
            foreach (var screening in movie.Value)
            {
                Console.WriteLine(
                    $"Time: {screening.ShowTime}, Screen: {screening.ScreeNumber}, " +
                    $"Available Seats: {screening.TotalSeats - screening.BookedSeats}"
                );
            }
        }

        // 4️⃣ Get available screenings for group booking
        Console.WriteLine("\nAvailable screenings with at least 50 seats:");
        var available = manager.GetAvailableScreenings(50);

        foreach (var screening in available)
        {
            Console.WriteLine(
                $"{screening.MovieTitle} - {screening.ShowTime} - " +
                $"Available Seats: {screening.TotalSeats - screening.BookedSeats}"
            );
        }

        // 5️⃣ Calculate total revenue
        double revenue = manager.CalculateTotalRevenue();
        Console.WriteLine($"\nTotal Revenue: ₹{revenue}");

        Console.ReadLine();
    }
}
