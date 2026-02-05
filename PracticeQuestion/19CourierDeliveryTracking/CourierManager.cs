using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierDeliveryTracking
{
    public class CourierManager
    {
        private List<Package> packages = new List<Package>();
        private List<DeliveryStatus> deliveryStatuses = new List<DeliveryStatus>();
        private Random random = new Random();

        public void AddPackage(string sender, string receiver, string address, double weight, string type, double cost)
        {
            string trackingNumber = "TRK" + random.Next(100000, 999999);
            var package = new Package
            {
                TrackingNumber = trackingNumber,
                SenderName = sender,
                ReceiverName = receiver,
                DestinationAddress = address,
                Weight = weight,
                PackageType = type,
                ShippingCost = cost
            };
            packages.Add(package);

            var status = new DeliveryStatus
            {
                TrackingNumber = trackingNumber,
                Checkpoints = new List<string> { "Package Registered" },
                CurrentStatus = "Dispatched",
                EstimatedDelivery = DateTime.Now.AddDays(3),
                ActualDelivery = DateTime.MinValue
            };
            deliveryStatuses.Add(status);

            Console.WriteLine($"Package registered with tracking number: {trackingNumber}");
        }

        public bool UpdateStatus(string trackingNumber, string status, string checkpoint)
        {
            var deliveryStatus = deliveryStatuses.FirstOrDefault(ds => ds.TrackingNumber == trackingNumber);
            if (deliveryStatus == null)
            {
                Console.WriteLine("Tracking number not found!");
                return false;
            }

            deliveryStatus.CurrentStatus = status;
            deliveryStatus.Checkpoints.Add(checkpoint);

            if (status == "Delivered")
            {
                deliveryStatus.ActualDelivery = DateTime.Now;
            }

            Console.WriteLine($"Status updated for {trackingNumber}: {status} - {checkpoint}");
            return true;
        }

        public Dictionary<string, List<Package>> GroupPackagesByType()
        {
            return packages.GroupBy(p => p.PackageType)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Package> GetPackagesByDestination(string city)
        {
            return packages.Where(p => p.DestinationAddress.Contains(city))
                          .ToList();
        }

        public List<Package> GetDelayedPackages()
        {
            var currentDate = DateTime.Now;
            return packages.Where(p =>
            {
                var status = deliveryStatuses.FirstOrDefault(ds => ds.TrackingNumber == p.TrackingNumber);
                return status != null &&
                       status.CurrentStatus != "Delivered" &&
                       status.EstimatedDelivery < currentDate;
            }).ToList();
        }

        public List<Package> GetAllPackages()
        {
            return packages;
        }

        public List<DeliveryStatus> GetAllStatuses()
        {
            return deliveryStatuses;
        }

        public DeliveryStatus GetDeliveryStatus(string trackingNumber)
        {
            return deliveryStatuses.FirstOrDefault(ds => ds.TrackingNumber == trackingNumber);
        }
    }
}
