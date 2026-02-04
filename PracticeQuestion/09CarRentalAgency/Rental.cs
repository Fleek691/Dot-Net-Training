using System;

namespace CarRentalAgency
{
    public class Rental
    {
        public int RentalId { get; set; }
        public string LicensePlate { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
        public Rental(int id,string license,string name,DateTime start,DateTime end,double total)
        {
            
        }
    }
}