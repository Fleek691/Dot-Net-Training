using System;
using System.Collections.Generic;

namespace CourierDeliveryTracking
{
    public class CourierManager
    {
        public void AddPackage(string sender, string receiver, string address, double weight, string type, double cost)
        {
        }

        public bool UpdateStatus(string trackingNumber, string status, string checkpoint)
        {
            return false;
        }

        public Dictionary<string, List<Package>> GroupPackagesByType()
        {
            return null;
        }

        public List<Package> GetPackagesByDestination(string city)
        {
            return null;
        }

        public List<Package> GetDelayedPackages()
        {
            return null;
        }
    }
}
