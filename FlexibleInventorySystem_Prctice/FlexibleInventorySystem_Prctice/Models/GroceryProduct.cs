using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Temperature
{
    Roomtemperature,
    Refrigerated,
    Frozen
}
namespace FlexibleInventorySystem_Practice.Models
{
    /// <summary>
    /// TODO: Implement grocery product class
    /// </summary>
    public class GroceryProduct : Product
    {
        // TODO: Add these properties
        // - ExpiryDate (DateTime)
        // - IsPerishable (bool)
        // - Weight (double)
        // - StorageTemperature (string) - e.g., "Room temperature", "Refrigerated", "Frozen"
        public DateTime ExpiryDate { get; set; }
        public bool IsPerishable { get; set; }
        public double Weight { get; set; }
        public Temperature StorageTemperature { get; set; }
        /// <summary>
        /// TODO: Override GetProductDetails for grocery items
        /// Include expiry information
        /// </summary>
        public override string GetProductDetails()
        {
            // TODO: Implement
            return $"Product details: Id->{Id}, Name->{Name}, Price->{Price}, Qty->{Quantity}, Category->{Category}, Date->{DateAdded}, ExpiryDate->{ExpiryDate}, IsPeriable->{IsPerishable}, Weight->{Weight}";
        }

        /// <summary>
        /// TODO: Check if product is expired
        /// </summary>
        public bool IsExpired()
        {
            // TODO: Compare ExpiryDate with current date
            if (DateTime.Now> ExpiryDate)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// TODO: Calculate days until expiry
        /// Return negative if expired
        /// </summary>
        public int DaysUntilExpiry()
        {
            // TODO: Calculate days difference
            var a=ExpiryDate-DateTime.Now;
            return a.Days;
        }

        /// <summary>
        /// TODO: Override CalculateValue to apply discount for near-expiry items
        /// Apply 20% discount if within 3 days of expiry
        /// </summary>
        public override decimal CalculateValue()
        {
            // TODO: Apply discount logic if near expiry
            decimal newPrice=0;
            var daysleft=ExpiryDate-DateTime.Now;
            if(daysleft.Days>0 && daysleft.Days <= 3)
            {
                newPrice=Price-(Price*20/100);
                return newPrice*Quantity;
            }
            return base.CalculateValue();
        }
    }
}
