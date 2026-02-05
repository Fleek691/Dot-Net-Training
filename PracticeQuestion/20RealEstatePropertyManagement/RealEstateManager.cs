using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstatePropertyManagement
{
    public class RealEstateManager
    {
        private List<Property> properties = new List<Property>();
        private List<Client> clients = new List<Client>();
        private List<Viewing> viewings = new List<Viewing>();
        private Random random = new Random();

        public void AddProperty(string address, string type, int bedrooms, double area, double price, string owner)
        {
            string propertyId = "PROP" + random.Next(1000, 9999);
            var property = new Property
            {
                PropertyId = propertyId,
                Address = address,
                PropertyType = type,
                Bedrooms = bedrooms,
                AreaSqFt = area,
                Price = price,
                Status = "Available",
                Owner = owner
            };
            properties.Add(property);
            Console.WriteLine($"Property listed: {propertyId} - {address}");
        }

        public void AddClient(string name, string contact, string type, double budget, List<string> requirements)
        {
            int clientId = clients.Count + 1;
            var client = new Client
            {
                ClientId = clientId,
                Name = name,
                Contact = contact,
                ClientType = type,
                Budget = budget,
                Requirements = requirements
            };
            clients.Add(client);
            Console.WriteLine($"Client registered: {name} (ID: {clientId}) - {type} with budget ${budget:N2}");
        }

        public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
        {
            var property = properties.FirstOrDefault(p => p.PropertyId == propertyId);
            if (property == null)
            {
                Console.WriteLine("Property not found!");
                return false;
            }

            var client = clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client == null)
            {
                Console.WriteLine("Client not found!");
                return false;
            }

            int viewingId = viewings.Count + 1;
            var viewing = new Viewing
            {
                ViewingId = viewingId,
                PropertyId = propertyId,
                ClientId = clientId,
                ViewingDate = date,
                Feedback = ""
            };
            viewings.Add(viewing);
            Console.WriteLine($"Viewing scheduled: {client.Name} to view {property.Address} on {date:yyyy-MM-dd HH:mm}");
            return true;
        }

        public Dictionary<string, List<Property>> GroupPropertiesByType()
        {
            return properties.GroupBy(p => p.PropertyType)
                            .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
        {
            return properties.Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Status == "Available")
                            .ToList();
        }

        public List<Property> GetAllProperties()
        {
            return properties;
        }

        public List<Client> GetAllClients()
        {
            return clients;
        }

        public List<Viewing> GetAllViewings()
        {
            return viewings;
        }
    }
}
