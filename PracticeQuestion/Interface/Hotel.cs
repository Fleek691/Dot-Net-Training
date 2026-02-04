using System;

namespace HotelBillingSystem
{
    // -------- INTERFACE --------
    public interface IRoom
    {
        double calculateTotalBill(int nightsStayed, int joiningYear);

        // Default method in interface
        public int calculateMembershipYears(int joiningYear)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - joiningYear;
        }
    }

    // -------- IMPLEMENTATION --------
    public class HotelRoom : IRoom
    {
        public string? roomType { get; set; }
        public double ratePerNight { get; set; }
        public string? guestName { get; set; }

        public double calculateTotalBill(int nightsStayed, int joiningYear)
        {
            double amount = nightsStayed * ratePerNight;
            IRoom a =new  HotelRoom();

            // Call default interface method properly
            int membershipYears = a.calculateMembershipYears(joiningYear);

            if (membershipYears > 3)
            {
                amount = amount * 0.90; // 10% discount
            }

            return Math.Round(amount);
        }
    }

    // -------- USER INTERFACE --------
    public class UserInterface
    {
        public static void Main(string[] args)
        {
            // ---------- Deluxe Room ----------
            Console.WriteLine("Enter Deluxe Room Details:");
            Console.Write("Guest Name: ");
            string delName = Console.ReadLine()!;

            Console.Write("Rate per Night: ");
            double delRate = double.Parse(Console.ReadLine()!);

            Console.Write("Nights Stayed: ");
            int delNights = int.Parse(Console.ReadLine()!);

            Console.Write("Joining Year: ");
            int delJoinYear = int.Parse(Console.ReadLine()!);

            HotelRoom deluxe = new HotelRoom
            {
                roomType = "Deluxe",
                ratePerNight = delRate,
                guestName = delName!
            };
            IRoom deluxM=deluxe;

            int delMembership = deluxM.calculateMembershipYears(delJoinYear);
            double delBill = deluxe.calculateTotalBill(delNights, delJoinYear);

            // ---------- Suite Room ----------
            Console.WriteLine("\nEnter Suite Room Details:");
            Console.Write("Guest Name: ");
            string suiteName = Console.ReadLine()!;

            Console.Write("Rate per Night: ");
            double suiteRate = double.Parse(Console.ReadLine()!);

            Console.Write("Nights Stayed: ");
            int suiteNights = int.Parse(Console.ReadLine()!);

            Console.Write("Joining Year: ");
            int suiteJoinYear = int.Parse(Console.ReadLine()!);

            HotelRoom suite = new HotelRoom
            {
                roomType = "Suite",
                ratePerNight = suiteRate,
                guestName = suiteName!
            };

            int suiteMembership = ((IRoom)suite).calculateMembershipYears(suiteJoinYear);
            double suiteBill = suite.calculateTotalBill(suiteNights, suiteJoinYear);

            // ---------- OUTPUT ----------
            Console.WriteLine("\nRoom Summary:");
            Console.WriteLine($"Deluxe Room: {delName}, {delRate} per night, Membership: {delMembership} years");
            Console.WriteLine($"Suite Room: {suiteName}, {suiteRate} per night, Membership: {suiteMembership} years");

            Console.WriteLine("\nTotal Bill:");
            Console.WriteLine($"For {delName} (Deluxe): {delBill}");
            Console.WriteLine($"For {suiteName} (Suite): {suiteBill}");
        }
    }
}
