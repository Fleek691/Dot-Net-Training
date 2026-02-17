using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    // Base Product Class

    /// <summary>
    /// TODO: Implement abstract base class for all products
    /// </summary>
    public abstract class Product
    {
        // TODO: Add these properties
        // - Id (string)
        // - Name (string)
        // - Price (decimal)
        // - Quantity (int)
        // - Category (string)
        // - DateAdded (DateTime)
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }


        /// <summary>
        /// TODO: Implement abstract method to get product-specific details
        /// </summary>
        public abstract string GetProductDetails();

        /// <summary>
        /// TODO: Implement virtual method to calculate inventory value
        /// Default: Price * Quantity
        /// </summary>
        public virtual decimal CalculateValue()
        {
            // TODO: Return Price * Quantity
            return Price * Quantity;
        }

        /// <summary>
        /// TODO: Override ToString() to return product summary
        /// </summary>
        public override string ToString()
        {
            // TODO: Return formatted string with Id, Name, Price, Quantity
            return $"Product details: Id->{Id},Name->{Name},Price->{Price},Qty->{Quantity},Category->{Category},Date->{DateAdded}";
        }
    }
}








