using System;
using System.Collections.Generic;

namespace CarRentalAgency
{
    public class RentalManager
    {
        public void AddCar(string license, string make, string model, string type, double rate)
        {
        }

        // Creates rental if car available
        public bool RentCar(string license, string customer, DateTime start, int days)
        {
            return false;
        }

        // Groups available cars by type
        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            return null;
        }

        // Returns current rentals
        public List<Rental> GetActiveRentals()
        {
            return null;
        }

        // Sum of all rental costs
        public double CalculateTotalRentalRevenue()
        {
            return 0;
        }
    }
}