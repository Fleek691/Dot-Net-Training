using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalAgency
{
    

    public class RentalManager
    {
        private List<RentalCar> rentalCars=new List<RentalCar>();
        private Dictionary<int,Rental> rental=new ();
        int id=1;
        public void AddCar(string license, string make, string model, string type, double rate)
        {
            if (rentalCars.Any(item => item.LicensePlate == license))
            {
                System.Console.WriteLine("Car already Present");
                return;
            }

            rentalCars.Add(new RentalCar(license, make, model, type, rate));
        }

        // Creates rental if car available
        public bool RentCar(string license, string customer, DateTime start, int days)
        {
            if (days <= 0)
            {
                return false;
            }

            var car = rentalCars.FirstOrDefault(c => c.LicensePlate == license);
            if (car == null || !car.IsAvailable)
            {
                return false;
            }

            rental.Add(id, new Rental(id, license, customer, start, days));
            id++;
            car.IsAvailable = false;
            return true;
        }

        // Groups available cars by type
        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            var result = rentalCars
                .Where(car => car.IsAvailable)
                .GroupBy(car => car.CarType)
                .ToDictionary(group => group.Key, group => group.ToList());
            return result;
        }

        // Returns current rentals
        public List<Rental> GetActiveRentals()
        {
            var result=rental.Values.Where(e=>e.EndDate>DateTime.Now).ToList();
            return result;
        }

        // Sum of all rental costs
        public double CalculateTotalRentalRevenue()
        {
            double totalRev = 0;

            foreach (var re in rental.Values)
            {
                var car = rentalCars.FirstOrDefault(c => c.LicensePlate == re.LicensePlate);
                if (car == null)
                {
                    continue;
                }

                var days = (re.EndDate - re.StartDate).TotalDays;
                if (days < 0)
                {
                    days = 0;
                }

                re.TotalCost = car.DailyRate * days;
                totalRev += re.TotalCost;
            }

            return totalRev;
        }
    }
}