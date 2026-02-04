namespace CourierDeliveryTracking
{
    public class Package
    {
        public string TrackingNumber { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string DestinationAddress { get; set; }
        public double Weight { get; set; }
        public string PackageType { get; set; } // Document/Parcel/Fragile
        public double ShippingCost { get; set; }
    }
}
