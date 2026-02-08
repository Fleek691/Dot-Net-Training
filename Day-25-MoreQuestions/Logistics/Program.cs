public class Ship
{
    public static void Main()
    {
        Shipmetdetail ship = new Shipmetdetail();
        System.Console.WriteLine("Enter Shipment Code: ");
        ship.ShipmentCode=Console.ReadLine()!;
        if(!ship.ValidateShipMentCode()){
            System.Console.WriteLine("Invalid Shipment Code");
            return;
        }
        System.Console.WriteLine("Enter Transport Mode(Air,Sea,Land): ");
        ship.TransportMode=Console.ReadLine()!;
        System.Console.WriteLine("Enter the Weight: ");
        ship.Weight=double.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter the number of Days: ");
        ship.StorageDays=int.Parse(Console.ReadLine()!);
        double totalCost=ship.CalculateTotalCost();
        System.Console.WriteLine($"Total COst is {totalCost:F2}");
    }
}