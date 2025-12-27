using System;

namespace DataModelExample
{
    // Base class for common properties
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } // "Suspect", "Prospect", "Account"
    }

    // Suspect: Initial potential lead
    public class Suspect : Lead
    {
        public string Source { get; set; } // How they were acquired (website, referral, etc.)
        public string Notes { get; set; }

        public Suspect()
        {
            Status = "Suspect";
            CreatedDate = DateTime.Now;
        }
    }

    // Prospect: Qualified lead
    public class Prospect : Suspect
    {
        public DateTime QualifiedDate { get; set; }
        public int QualificationScore { get; set; } // 1-100 scale
        public string Industry { get; set; }
        public decimal EstimatedValue { get; set; }

        public Prospect()
        {
            Status = "Prospect";
            QualifiedDate = DateTime.Now;
        }
    }

    // Account: Converted customer
    public class Account : Prospect
    {
        public string AccountNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal ContractValue { get; set; }
        public string AccountManager { get; set; }

        public Account()
        {
            Status = "Account";
            ContractDate = DateTime.Now;
        }
    }

    // Manager class to handle operations
    public class LeadManager
    {
        private List<Lead> leads = new List<Lead>();

        public void AddSuspect(Suspect suspect)
        {
            leads.Add(suspect);
        }

        public void ConvertToProspect(int suspectId, Prospect prospect)
        {
            var suspect = leads.FirstOrDefault(l => l.Id == suspectId && l.Status == "Suspect");
            if (suspect != null)
            {
                prospect.Id = suspect.Id;
                leads.Remove(suspect);
                leads.Add(prospect);
            }
        }

        public void ConvertToAccount(int prospectId, Account account)
        {
            var prospect = leads.FirstOrDefault(l => l.Id == prospectId && l.Status == "Prospect");
            if (prospect != null)
            {
                account.Id = prospect.Id;
                leads.Remove(prospect);
                leads.Add(account);
            }
        }

        public List<Lead> GetAllLeads()
        {
            return leads;
        }

        public List<Suspect> GetSuspects()
        {
            return leads.Where(l => l.Status == "Suspect").Cast<Suspect>().ToList();
        }

        public List<Prospect> GetProspects()
        {
            return leads.Where(l => l.Status == "Prospect").Cast<Prospect>().ToList();
        }

        public List<Account> GetAccounts()
        {
            return leads.Where(l => l.Status == "Account").Cast<Account>().ToList();
        }
    }
}