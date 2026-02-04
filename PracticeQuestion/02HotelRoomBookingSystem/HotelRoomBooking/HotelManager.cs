public class HotelManager
{
    public Dictionary<int, Room> roomDetails = new Dictionary<int, Room>();
    // In class HotelManager:
    public void AddRoom(int roomNumber, string type, double price)
    {
        if (!roomDetails.ContainsKey(roomNumber))
        {
            roomDetails[roomNumber] = new Room(roomNumber, type, price, true);
        }
        else
        {
            System.Console.WriteLine("Room Exists");
        }

    }


    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        return roomDetails.Values
            .GroupBy(room => room.RoomType)
            .ToDictionary(group => group.Key, group => group.Where(r => r.IsAvailable).ToList());
    }
    // Groups available rooms by type

    public bool BookRoom(int roomNumber, int nights)
    {
        double totalCost = 0;
        if (roomDetails.ContainsKey(roomNumber))
        {
            if (roomDetails[roomNumber].IsAvailable)
            {
                totalCost = roomDetails[roomNumber].PricePerNight * nights;
                roomDetails[roomNumber].IsAvailable = false;
                System.Console.WriteLine($"Total COst {totalCost}");
                return true;
            }
        }
        return false;
    }
    // Books room if available, calculates total cost

    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        var result = roomDetails.Values
    .Where(r => r.IsAvailable && r.PricePerNight >= min && r.PricePerNight <= max)
    .ToList();
        return result;
    }

}