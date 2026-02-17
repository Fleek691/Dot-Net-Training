using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexibleInventorySystem_Practice.Exceptions;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice.Utilities
{

    /// <summary>
    /// TODO: Implement validation helper class
    /// </summary>
    public static class ProductValidator
    {
        /// <summary>
        /// TODO: Validate product data
        /// Check:
        /// - ID not null/empty
        /// - Name not null/empty
        /// - Price > 0
        /// - Quantity >= 0
        /// </summary>
        public static bool ValidateProduct(Product product, out string errorMessage)
        {
            // TODO: Implement validation
            if (product.Id == null || string.IsNullOrEmpty(product.Id))
            {
                errorMessage = "Invalid Id";
                throw new InventoryException(errorMessage);
            }
            if (product.Name == null || string.IsNullOrEmpty(product.Name))
            {
                errorMessage = "Invalid Name";
                throw new InventoryException(errorMessage);
            }
            if (product.Price <= 0)
            {
                errorMessage = "Invalid Price";
                throw new InventoryException(errorMessage);
            }
            if (product.Quantity < 0)
            {
                errorMessage = "Invalid Quantity";
                throw new InventoryException(errorMessage);
            }
            errorMessage = "Valid";
            return true;
        }

        /// <summary>
        /// TODO: Validate electronic product specific rules
        /// </summary>
        public static bool ValidateElectronicProduct(ElectronicProduct product, out string errorMessage)
        {
            // TODO: Implement electronic validation
            errorMessage = null!;
            // TODO: Implement validation
            if (product.Id == null || string.IsNullOrEmpty(product.Id))
            {
                errorMessage = "Invalid Id";
                throw new InventoryException(errorMessage);
            }
            if (product.Name == null || string.IsNullOrEmpty(product.Name))
            {
                errorMessage = "Invalid Name";
                throw new InventoryException(errorMessage);
            }
            if (product.Price <= 0)
            {
                errorMessage = "Invalid Price";
                throw new InventoryException(errorMessage);
            }
            if (product.Quantity < 0)
            {
                errorMessage = "Invalid Quantity";
                throw new InventoryException(errorMessage);
            }
            errorMessage = "Valid";
            return true;
        }

        /// <summary>
        /// TODO: Validate grocery product specific rules
        /// </summary>
        public static bool ValidateGroceryProduct(GroceryProduct product, out string errorMessage)
        {
            // TODO: Implement grocery validation
            errorMessage = null!;
            // TODO: Implement validation
            if (product.Id == null || string.IsNullOrEmpty(product.Id))
            {
                errorMessage = "Invalid Id";
                throw new InventoryException(errorMessage);
            }
            if (product.Name == null || string.IsNullOrEmpty(product.Name))
            {
                errorMessage = "Invalid Name";
                throw new InventoryException(errorMessage);
            }
            if (product.Price <= 0)
            {
                errorMessage = "Invalid Price";
                throw new InventoryException(errorMessage);
            }
            if (product.Quantity < 0)
            {
                errorMessage = "Invalid Quantity";
                throw new InventoryException(errorMessage);
            }
            errorMessage = "Valid";
            return true;
        }

        /// <summary>
        /// TODO: Validate clothing product specific rules
        /// </summary>
        public static bool ValidateClothingProduct(ClothingProduct product, out string errorMessage)
        {
            // TODO: Implement clothing validation
            errorMessage = null!;
            // TODO: Implement validation
            if (product.Id == null || string.IsNullOrEmpty(product.Id))
            {
                errorMessage = "Invalid Id";
                throw new InventoryException(errorMessage);
            }
            if (product.Name == null || string.IsNullOrEmpty(product.Name))
            {
                errorMessage = "Invalid Name";
                throw new InventoryException(errorMessage);
            }
            if (product.Price <= 0)
            {
                errorMessage = "Invalid Price";
                throw new InventoryException(errorMessage);
            }
            if (product.Quantity < 0)
            {
                errorMessage = "Invalid Quantity";
                throw new InventoryException(errorMessage);
            }
            errorMessage = "Valid";
            return true;
        }
    }
}
