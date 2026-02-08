public class Shipment
{
    public string? ShipmentCode{get;set;}
    public string? TransportMode{get;set;}	
    public double Weight{get;set;}	
    public int StorageDays{get;set;}

}
public class Shipmetdetail: Shipment
{
    public double ratePerKg{get;set;}
    public bool ValidateShipMentCode()
    {
        if(ShipmentCode!.Length!=7)return false;
        if(ShipmentCode[..3] !="GC#")return false;
        if (!int.TryParse(ShipmentCode[3..], out int result))
        {
            return false;
        }
        return true;
    }
    public double CalculateTotalCost(){
        if(TransportMode=="Sea")ratePerKg=15.00;
        else if(TransportMode=="Air")ratePerKg=50.00;
        else if(TransportMode=="Land")ratePerKg=25.00;
        double totalCost=(Weight*ratePerKg)+Math.Sqrt(StorageDays);
        return totalCost;
    }
}

