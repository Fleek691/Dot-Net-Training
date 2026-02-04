using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HotelManager manager = new HotelManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== HOTEL ROOM BOOKING SYSTEM =====");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. View Available Rooms Grouped By Type");
            Console.WriteLine("3. Book a Room");
            Console.WriteLine("4. Find Available Rooms By Price Range");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Room Number: ");
                    int roomNo = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter Room Type (Single/Double/Suite): ");
                    string type = Console.ReadLine()!;

                    Console.Write("Enter Price Per Night: ");
                    double price = double.Parse(Console.ReadLine()!);

                    manager.AddRoom(roomNo, type, price);
                    Console.WriteLine("Room added successfully.");
                    break;

                case 2:
                    var groupedRooms = manager.GroupRoomsByType();

                    Console.WriteLine("\nAvailable Rooms Grouped By Type:");
                    foreach (var group in groupedRooms)
                    {
                        Console.WriteLine($"Room Type: {group.Key}");
                        foreach (var room in group.Value)
                        {
                            Console.WriteLine(
                                $"  Room No: {room.RoomNumber}, Price: {room.PricePerNight}"
                            );
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Room Number to Book: ");
                    int bookRoomNo = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter Number of Nights: ");
                    int nights = int.Parse(Console.ReadLine()!);

                    bool booked = manager.BookRoom(bookRoomNo, nights);
                    if (!booked)
                    {
                        Console.WriteLine("Room not available or does not exist.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Minimum Price: ");
                    double min = double.Parse(Console.ReadLine()!);

                    Console.Write("Enter Maximum Price: ");
                    double max = double.Parse(Console.ReadLine()!);

                    var roomsInRange = manager.GetAvailableRoomsByPriceRange(min, max);

                    Console.WriteLine("\nAvailable Rooms in Price Range:");
                    foreach (var room in roomsInRange)
                    {
                        Console.WriteLine(
                            $"Room No: {room.RoomNumber}, Type: {room.RoomType}, Price: {room.PricePerNight}"
                        );
                    }
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Exiting application...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
