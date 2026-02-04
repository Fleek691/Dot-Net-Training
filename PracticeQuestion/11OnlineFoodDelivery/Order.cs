using System;
using System.Collections.Generic;

namespace OnlineFoodDelivery
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<FoodItem> Items { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public Order(int id,int customerId,List<FoodItem>items,DateTime time)
        {
            OrderId=id;
            CustomerId=customerId;
            Items=items;
            OrderTime=time;
            Status="Pending";
        }
    }
}
