using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFoodDelivery
{
    public class DeliveryManager
    {
        private Dictionary<int, Restaurant> restaurantList = new Dictionary<int, Restaurant>();
        int resId = 1;
        private Dictionary<int, FoodItem> foodList = new Dictionary<int, FoodItem>();
        int foodId = 1;
        private Dictionary<int, Order> orders = new Dictionary<int, Order>();
        int orderid = 1;
        public void AddRestaurant(string name, string cuisine, string location, double charge)
        {
            restaurantList.Add(resId, new Restaurant(resId, name, cuisine, location, charge));
            resId++;
        }

        public void AddFoodItem(int restaurantId, string name, string category, double price)
        {
            if (restaurantList.ContainsKey(restaurantId))
            {
                foodList.Add(foodId, new FoodItem(foodId, restaurantId, name, category, price));
                foodId++;
            }
            else
            {
                System.Console.WriteLine("Restaurant doesnt exist");
            }


        }

        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            var res = restaurantList.Values.GroupBy(e => e.CuisineType).ToDictionary(g => g.Key, g => g.ToList());
            return res;
        }

        public bool PlaceOrder(int customerId, List<int> itemIds)
        {
            if (itemIds.Count <= 0)
            {
                return false;
            }
            List<FoodItem>selectedIetm=new List<FoodItem>();
            foreach(var id in itemIds)
            {
                if (foodList.ContainsKey(id))
                {
                    selectedIetm.Add(foodList[id]);
                }
                else
                {
                    return false;
                }

            }
            double total=selectedIetm.Sum(e=>e.Price);
            Order order=new Order(orderid,customerId,selectedIetm,DateTime.Now);
            order.TotalAmount=total;
            order.Status="Pending";
            orders.Add(orderid++,order);
            return true;
        }

        public List<Order> GetPendingOrders()
        {
            var res=orders.Values.Where(e=>e.Status=="Pending").ToList();
            return res;
        }
    }
}
