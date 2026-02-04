public class Room
{
    public int RoomNumber{get;set;}
    public string RoomType{get;set;}
    public double PricePerNight{get;set;}
    public bool IsAvailable{get;set;}
    public Room(int roomno,string type,double price,bool availablity)
    {
        RoomNumber=roomno;
        RoomType=type;
        PricePerNight=price;
        IsAvailable=availablity;    
    }
}
