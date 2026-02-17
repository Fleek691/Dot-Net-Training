using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    // Different Product Types

    /// <summary>
    /// TODO: Implement electronic product class
    /// </summary>
    public class ElectronicProduct : Product
    {
        // TODO: Add these properties
        // - Brand (string)
        public string Brand { get; set; }
        public int WarrantyMonths { get; set; }
        public string Voltage { get; set; }
        public bool IsRefurbished { get; set; }
        // - WarrantyMonths (int)
        // - Voltage (string)
        // - IsRefurbished (bool)

        /// <summary>
        /// TODO: Override GetProductDetails to include electronic specifics
        /// Format: "Brand: {Brand}, Model: {Name}, Warranty: {WarrantyMonths} months"
        /// </summary>
        public override string GetProductDetails()
        {
            // TODO: Implement
            return $"Product details: Id->{Id},Name->{Name},Price->{Price},Qty->{Quantity},Category->{Category},Date->{DateAdded}, Brand: {Brand}, Model: {Name}, Warranty: {WarrantyMonths} months";

        }

        /// <summary>
        /// TODO: Calculate warranty expiration date
        /// </summary>
        public DateTime GetWarrantyExpiryDate()
        {
            // TODO: Return DateAdded.AddMonths(WarrantyMonths)
            return DateAdded.AddMonths(WarrantyMonths);
        }

        /// <summary>
        /// TODO: Check if warranty is still valid
        /// </summary>
        public bool IsWarrantyValid()
        {
            // TODO: Compare warranty expiry with current date
            DateTime warrantyExp=DateAdded.AddMonths(WarrantyMonths);
            return DateTime.Now<=warrantyExp;
        }
    }
}

