using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstatePropertyManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            RealEstateManager manager = new RealEstateManager();

            Console.WriteLine("=== Real Estate Property Management System ===\n");

            // Test Case 1: List properties for sale/rent
            Console.WriteLine("--- Listing Properties ---");
            manager.AddProperty("123 Park Avenue, Manhattan", "Apartment", 3, 1500, 850000, "Smith Holdings");
            manager.AddProperty("456 Beach Road, Malibu", "Villa", 5, 4500, 2500000, "Ocean Properties");
            manager.AddProperty("789 Elm Street, Brooklyn", "House", 4, 2200, 650000, "Johnson Family");
            manager.AddProperty("321 Broadway, Queens", "Apartment", 2, 1000, 450000, "Metro Realty");
            manager.AddProperty("654 Lake View, Staten Island", "House", 3, 1800, 550000, "Lake Estates");
            manager.AddProperty("987 5th Avenue, Manhattan", "Apartment", 2, 1200, 920000, "Elite Properties");
            Console.WriteLine();

            // Test Case 2: Register clients with preferences
            Console.WriteLine("--- Registering Clients ---");
            manager.AddClient("John Anderson", "555-0101", "Buyer", 700000, new List<string> { "3 bedrooms", "Manhattan or Brooklyn" });
            manager.AddClient("Sarah Miller", "555-0102", "Buyer", 500000, new List<string> { "2-3 bedrooms", "Near subway" });
            manager.AddClient("Michael Chen", "555-0103", "Buyer", 1000000, new List<string> { "Manhattan", "Modern apartment" });
            manager.AddClient("Emily Davis", "555-0104", "Renter", 3000, new List<string> { "2 bedrooms", "Pet-friendly" });
            Console.WriteLine();

            // Get property IDs for scheduling viewings
            var properties = manager.GetAllProperties();

            // Test Case 3: Schedule property viewings
            Console.WriteLine("--- Scheduling Viewings ---");
            manager.ScheduleViewing(properties[0].PropertyId, 1, new DateTime(2026, 2, 8, 14, 0, 0));
            manager.ScheduleViewing(properties[2].PropertyId, 1, new DateTime(2026, 2, 9, 10, 0, 0));
            manager.ScheduleViewing(properties[3].PropertyId, 2, new DateTime(2026, 2, 8, 16, 0, 0));
            manager.ScheduleViewing(properties[5].PropertyId, 3, new DateTime(2026, 2, 10, 11, 0, 0));
            manager.ScheduleViewing(properties[4].PropertyId, 2, new DateTime(2026, 2, 11, 15, 0, 0));
            Console.WriteLine();

            // Test Case 4: Group properties by type
            Console.WriteLine("--- Grouping Properties by Type ---");
            var groupedProperties = manager.GroupPropertiesByType();
            foreach (var group in groupedProperties)
            {
                Console.WriteLine($"\n{group.Key} Properties:");
                foreach (var property in group.Value)
                {
                    Console.WriteLine($"  - {property.Address}");
                    Console.WriteLine($"    {property.Bedrooms} beds, {property.AreaSqFt} sqft, ${property.Price:N2} ({property.Status})");
                }
            }
            Console.WriteLine();

            // Test Case 5: Find properties within budget
            Console.WriteLine("--- Properties within $400,000 - $700,000 Budget ---");
            var budgetProperties = manager.GetPropertiesInBudget(400000, 700000);
            Console.WriteLine($"Found {budgetProperties.Count} matching properties:");
            foreach (var property in budgetProperties)
            {
                Console.WriteLine($"  - {property.Address}");
                Console.WriteLine($"    Type: {property.PropertyType}, Bedrooms: {property.Bedrooms}, Price: ${property.Price:N2}");
            }
            Console.WriteLine();

            Console.WriteLine("--- Properties within $800,000 - $1,000,000 Budget ---");
            var luxuryProperties = manager.GetPropertiesInBudget(800000, 1000000);
            Console.WriteLine($"Found {luxuryProperties.Count} matching properties:");
            foreach (var property in luxuryProperties)
            {
                Console.WriteLine($"  - {property.Address}");
                Console.WriteLine($"    Type: {property.PropertyType}, Bedrooms: {property.Bedrooms}, Price: ${property.Price:N2}");
            }
            Console.WriteLine();

            // Summary
            Console.WriteLine("--- Summary ---");
            Console.WriteLine($"Total Properties Listed: {properties.Count}");
            Console.WriteLine($"Total Clients Registered: {manager.GetAllClients().Count}");
            Console.WriteLine($"Total Viewings Scheduled: {manager.GetAllViewings().Count}");

            Console.WriteLine("\n=== End of Real Estate Property Management Demo ===");
        }
    }
}
