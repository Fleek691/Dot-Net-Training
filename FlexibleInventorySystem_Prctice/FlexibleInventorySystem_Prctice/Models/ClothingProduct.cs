using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{

    /// <summary>
    /// TODO: Implement clothing product class
    /// </summary>
    public class ClothingProduct : Product
    {
        // TODO: Add these properties
        // - Size (string)
        // - Color (string)
        // - Material (string)
        // - Gender (string) - "Men", "Women", "Unisex"
        // - Season (string) - "Summer", "Winter", "All-season"
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Gender { get; set; }
        public string Season { get; set; }

        /// <summary>
        /// TODO: Override GetProductDetails for clothing items
        /// </summary>
        public override string GetProductDetails()
        {
            // TODO: Return formatted string with size, color, material
            return $"Product details: Id->{Id},Name->{Name},Price->{Price},Qty->{Quantity},Category->{Category},Date->{DateAdded}, Size->{Size}, Color->{Color}, Material->{Material}, Gender->{Gender}, Season->{Season}";

        }

        /// <summary>
        /// TODO: Check if size is available
        /// Valid sizes: XS, S, M, L, XL, XXL
        /// </summary>
        
        public bool IsValidSize()
        {
            // TODO: Validate size against allowed values
            string[] sizes={"XS", "S", "M", "L", "XL", "XXL"};
            return sizes.Contains(Size,StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// TODO: Override CalculateValue to apply seasonal discount
        /// Apply 15% discount for off-season items
        /// </summary>
        public override decimal CalculateValue()
        {
            // TODO: Apply seasonal discount logic
            var currentSeason=(DateTime.Now.Month >=3 && DateTime.Now.Month<=8)? "Summer" : "Winter";
            if(Season!=currentSeason && Season != "All-season")
            {
                return Price*Quantity*0.85m;
            }
            return base.CalculateValue();
        }
    }
}