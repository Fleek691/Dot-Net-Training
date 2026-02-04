namespace OnlineFoodDelivery
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public string Location { get; set; }
        public double DeliveryCharge { get; set; }
        public Restaurant(int id,string name, string cuisine, string location, double charge)
        {
            RestaurantId=id;
            Name=name;
            CuisineType=cuisine;
            Location=location;
            DeliveryCharge=charge;
        }
    }
    
}
