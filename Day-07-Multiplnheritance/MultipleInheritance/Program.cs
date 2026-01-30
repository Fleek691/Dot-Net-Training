using System;
using System.Linq;

namespace DataModelExample
{
    class Program
    {
        static void Main(string[] args)
        {
            LeadManager manager = new LeadManager();

            // Create a suspect
            Suspect suspect = new Suspect
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@example.com",
                Phone = "123-456-7890",
                Company = "ABC Corp",
                Source = "Website",
                Notes = "Interested in our services"
            };

            manager.AddSuspect(suspect);
            Console.WriteLine("Added suspect: " + suspect.Name);

            // Convert to prospect
            Prospect prospect = new Prospect
            {
                Name = suspect.Name,
                Email = suspect.Email,
                Phone = suspect.Phone,
                Company = suspect.Company,
                Source = suspect.Source,
                Notes = suspect.Notes,
                QualificationScore = 85,
                Industry = "Technology",
                EstimatedValue = 50000
            };

            manager.ConvertToProspect(1, prospect);
            Console.WriteLine("Converted to prospect: " + prospect.Name);

            // Convert to account
            Account account = new Account
            {
                Name = prospect.Name,
                Email = prospect.Email,
                Phone = prospect.Phone,
                Company = prospect.Company,
                Source = prospect.Source,
                Notes = prospect.Notes,
                QualificationScore = prospect.QualificationScore,
                Industry = prospect.Industry,
                EstimatedValue = prospect.EstimatedValue,
                AccountNumber = "ACC001",
                ContractValue = 45000,
                AccountManager = "Jane Smith"
            };

            manager.ConvertToAccount(1, account);
            Console.WriteLine("Converted to account: " + account.Name);

            // Display all
            Console.WriteLine("\nAll Leads:");
            foreach (var lead in manager.GetAllLeads())
            {
                Console.WriteLine($"{lead.Status}: {lead.Name} - {lead.Email}");
            }

            Console.WriteLine("\nSuspects: " + manager.GetSuspects().Count);
            Console.WriteLine("Prospects: " + manager.GetProspects().Count);
            Console.WriteLine("Accounts: " + manager.GetAccounts().Count);
        }
    }
}
  