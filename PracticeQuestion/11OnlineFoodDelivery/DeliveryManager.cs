using System;
using System.Collections.Generic;

namespace OnlineFoodDelivery
{
    public class DeliveryManager
    {
        public void AddRestaurant(string name, string cuisine, string location, double charge)
        {
        }

        public void AddFoodItem(int restaurantId, string name, string category, double price)
        {
        }

        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            return null;
        }

        public bool PlaceOrder(int customerId, List<int> itemIds)
        {
            return false;
        }

        public List<Order> GetPendingOrders()
        {
            return null;
        }
    }
}
