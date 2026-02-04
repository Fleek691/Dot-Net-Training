namespace OnlineFoodDelivery
{
    public class FoodItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; }
        public FoodItem(int id,int restaurantId, string name, string category, double price)
        {
            ItemId=id;
            Name=name;
            Category=category;
            Price=price;
            RestaurantId=restaurantId;
        }
    }
}
