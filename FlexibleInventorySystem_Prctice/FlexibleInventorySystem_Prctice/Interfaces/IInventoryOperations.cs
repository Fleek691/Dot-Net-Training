using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Interfaces
{
         /// <summary>
        /// Defines core inventory operations
        /// </summary>
        public interface IInventoryOperations
        {
            /// <summary>
            /// Adds a new product to inventory
            /// </summary>
            /// <param name="product">Product to add</param>
            /// <returns>True if added successfully</returns>
            bool AddProduct(Product product);

            /// <summary>
            /// Removes a product from inventory
            /// </summary>
            /// <param name="productId">ID of product to remove</param>
            /// <returns>True if removed successfully</returns>
            bool RemoveProduct(string productId);

            /// <summary>
            /// Finds a product by ID
            /// </summary>
            /// <param name="productId">Product ID to search</param>
            /// <returns>Product if found, null otherwise</returns>
            Product FindProduct(string productId);

            /// <summary>
            /// Gets all products in a specific category
            /// </summary>
            /// <param name="category">Category name</param>
            /// <returns>List of products in category</returns>
            List<Product> GetProductsByCategory(string category);

            /// <summary>
            /// Updates quantity of a product
            /// </summary>
            /// <param name="productId">Product ID</param>
            /// <param name="newQuantity">New quantity value</param>
            /// <returns>True if updated successfully</returns>
            bool UpdateQuantity(string productId, int newQuantity);

            /// <summary>
            /// Calculates total inventory value
            /// </summary>
            /// <returns>Total value of all products</returns>
            decimal GetTotalInventoryValue();

            /// <summary>
            /// Gets products with quantity below threshold
            /// </summary>
            /// <param name="threshold">Minimum quantity threshold</param>
            /// <returns>List of low stock products</returns>
            List<Product> GetLowStockProducts(int threshold);
        }
    
}
