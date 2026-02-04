using System;
using System.Collections.Generic;

namespace CourierDeliveryTracking
{
    public class DeliveryStatus
    {
        public string TrackingNumber { get; set; }
        public List<string> Checkpoints { get; set; }
        public string CurrentStatus { get; set; } // Dispatched/InTransit/Delivered
        public DateTime EstimatedDelivery { get; set; }
        public DateTime ActualDelivery { get; set; }
    }
}
