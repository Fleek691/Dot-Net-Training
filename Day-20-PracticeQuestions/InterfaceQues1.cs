using System;

#region Room Interface
public interface Room
{
    // Abstract method
    double calculateTotalBill(int nightsStayed, int joiningYear);

    // Default method
    public int calculateMembershipYears(int joiningYear)
    {
        int currentYear = DateTime.Now.Year;
        return currentYear - joiningYear;
    }
}
#endregion

#region HotelRoom Class
public class HotelRoom : Room
{
    // Attributes
    private string roomType;
    private double ratePerNight;
    private string guestName;

    // Constructor
    public HotelRoom(string roomType, double ratePerNight, string guestName)
    {
        this.roomType = roomType;
        this.ratePerNight = ratePerNight;
        this.guestName = guestName;
    }

    // Getters
    public string RoomType => roomType;
    public double RatePerNight => ratePerNight;
    public string GuestName => guestName;

    // Method implementation
    public double calculateTotalBill(int nightsStayed, int joiningYear)
    {
        double total = nightsStayed * ratePerNight;

        // Call the interface's default method using the Room interface
        Room roomInterface = (Room)this;
        int membershipYears = roomInterface.calculateMembershipYears(joiningYear);

        if (membershipYears > 3)
        {
            total = total * 0.90; // 10% discount
        }

        return Math.Round(total);
    }
}
#endregion

#region UserInterface
public class UserInterface3
{
    public static void Main(string[] args)
    {
        // Deluxe Room Input
        Console.WriteLine("Enter Deluxe Room Details:");
        Console.Write("Guest Name: ");
        string deluxeName = Console.ReadLine()!;

        Console.Write("Rate per Night: ");
        double deluxeRate = double.Parse(Console.ReadLine()!);

        Console.Write("Nights Stayed: ");
        int deluxeNights = int.Parse(Console.ReadLine()!);

        Console.Write("Joining Year: ");
        int deluxeYear = int.Parse(Console.ReadLine()!);

        HotelRoom deluxeRoom = new HotelRoom("Deluxe", deluxeRate, deluxeName);

        // Cast to Room interface to access the default method
        Room deluxeRoomInterface = deluxeRoom;
        int deluxeMembership = deluxeRoomInterface.calculateMembershipYears(deluxeYear);
        double deluxeBill = deluxeRoom.calculateTotalBill(deluxeNights, deluxeYear);

        // Suite Room Input
        Console.WriteLine("Enter Suite Room Details:");
        Console.Write("Guest Name: ");
        string suiteName = Console.ReadLine()!;

        Console.Write("Rate per Night: ");
        double suiteRate = double.Parse(Console.ReadLine()!);

        Console.Write("Nights Stayed: ");
        int suiteNights = int.Parse(Console.ReadLine()!);

        Console.Write("Joining Year: ");
        int suiteYear = int.Parse(Console.ReadLine()!);

        HotelRoom suiteRoom = new HotelRoom("Suite", suiteRate, suiteName);

        // Cast to Room interface to access the default method
        Room suiteRoomInterface = suiteRoom;
        int suiteMembership = suiteRoomInterface.calculateMembershipYears(suiteYear);
        double suiteBill = suiteRoom.calculateTotalBill(suiteNights, suiteYear);

        // Output
        Console.WriteLine("Room Summary:");
        Console.WriteLine($"Deluxe Room: {deluxeRoom.GuestName}, {deluxeRoom.RatePerNight} per night, Membership: {deluxeMembership} years");
        Console.WriteLine($"Suite Room: {suiteRoom.GuestName}, {suiteRoom.RatePerNight} per night, Membership: {suiteMembership} years");

        Console.WriteLine("Total Bill:");
        Console.WriteLine($"For {deluxeRoom.GuestName} (Deluxe): {deluxeBill}");
        Console.WriteLine($"For {suiteRoom.GuestName} (Suite): {suiteBill}");
    }
}
#endregion
