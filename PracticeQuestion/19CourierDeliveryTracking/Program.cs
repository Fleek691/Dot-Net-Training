using System;
using System.Linq;

namespace CourierDeliveryTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            CourierManager manager = new CourierManager();

            Console.WriteLine("=== Courier Delivery Tracking System ===\n");

            // Test Case 1: Register packages for delivery
            Console.WriteLine("--- Registering Packages ---");
            manager.AddPackage("John Doe", "Alice Smith", "123 Main St, New York", 2.5, "Document", 15.00);
            manager.AddPackage("Bob Wilson", "Charlie Brown", "456 Oak Ave, Los Angeles", 5.0, "Parcel", 25.00);
            manager.AddPackage("Eve Davis", "Frank Miller", "789 Pine Rd, New York", 1.0, "Document", 12.00);
            manager.AddPackage("Grace Lee", "Henry Adams", "321 Elm St, Chicago", 10.0, "Fragile", 50.00);
            manager.AddPackage("Ivy Chen", "Jack Taylor", "654 Maple Dr, Boston", 3.5, "Parcel", 20.00);
            Console.WriteLine();

            // Get tracking numbers for testing
            var packages = manager.GetAllPackages();
            var trackingNumbers = packages.Select(p => p.TrackingNumber).ToList();

            // Test Case 2: Update delivery status
            Console.WriteLine("--- Updating Delivery Status ---");
            manager.UpdateStatus(trackingNumbers[0], "InTransit", "Arrived at sorting facility");
            manager.UpdateStatus(trackingNumbers[0], "InTransit", "Out for delivery");
            manager.UpdateStatus(trackingNumbers[0], "Delivered", "Package delivered successfully");

            manager.UpdateStatus(trackingNumbers[1], "InTransit", "Departed from origin");
            manager.UpdateStatus(trackingNumbers[2], "InTransit", "In transit to destination");
            manager.UpdateStatus(trackingNumbers[3], "InTransit", "Arrived at local hub");
            Console.WriteLine();

            // Test Case 3: Group packages by type
            Console.WriteLine("--- Grouping Packages by Type ---");
            var groupedPackages = manager.GroupPackagesByType();
            foreach (var group in groupedPackages)
            {
                Console.WriteLine($"\n{group.Key} Packages:");
                foreach (var package in group.Value)
                {
                    Console.WriteLine($"  - {package.TrackingNumber}: {package.SenderName} → {package.ReceiverName} (${package.ShippingCost})");
                }
            }
            Console.WriteLine();

            // Test Case 4: Track packages by destination
            Console.WriteLine("--- Packages to New York ---");
            var nyPackages = manager.GetPackagesByDestination("New York");
            Console.WriteLine($"Found {nyPackages.Count} package(s) to New York:");
            foreach (var package in nyPackages)
            {
                var status = manager.GetDeliveryStatus(package.TrackingNumber);
                Console.WriteLine($"  - {package.TrackingNumber}: {package.ReceiverName} at {package.DestinationAddress}");
                Console.WriteLine($"    Status: {status.CurrentStatus}");
            }
            Console.WriteLine();

            // Test Case 5: Identify delayed deliveries
            Console.WriteLine("--- Checking for Delayed Packages ---");
            var delayedPackages = manager.GetDelayedPackages();
            if (delayedPackages.Count > 0)
            {
                Console.WriteLine($"Found {delayedPackages.Count} delayed package(s):");
                foreach (var package in delayedPackages)
                {
                    var status = manager.GetDeliveryStatus(package.TrackingNumber);
                    Console.WriteLine($"  - {package.TrackingNumber}: To {package.ReceiverName}");
                    Console.WriteLine($"    Expected: {status.EstimatedDelivery:yyyy-MM-dd}, Current Status: {status.CurrentStatus}");
                }
            }
            else
            {
                Console.WriteLine("No delayed packages at this time.");
            }
            Console.WriteLine();

            // Show detailed tracking for one package
            Console.WriteLine("--- Detailed Tracking Example ---");
            var sampleStatus = manager.GetDeliveryStatus(trackingNumbers[0]);
            Console.WriteLine($"Tracking Number: {trackingNumbers[0]}");
            Console.WriteLine($"Current Status: {sampleStatus.CurrentStatus}");
            Console.WriteLine("Checkpoints:");
            foreach (var checkpoint in sampleStatus.Checkpoints)
            {
                Console.WriteLine($"  - {checkpoint}");
            }

            Console.WriteLine("\n=== End of Courier Delivery Tracking Demo ===");
        }
    }
}
