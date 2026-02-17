using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Interfaces
{
    
        /// <summary>
        /// Defines reporting operations
        /// </summary>
        public interface IReportGenerator
        {
            /// <summary>
            /// Generates complete inventory report
            /// </summary>
            /// <returns>Formatted string report</returns>
            string GenerateInventoryReport();

            /// <summary>
            /// Generates summary grouped by category
            /// </summary>
            /// <returns>Formatted category summary</returns>
            string GenerateCategorySummary();

            /// <summary>
            /// Generates report of most/least valuable products
            /// </summary>
            /// <returns>Formatted value report</returns>
            string GenerateValueReport();

            /// <summary>
            /// Generates report of expiring products (for groceries)
            /// </summary>
            /// <param name="daysThreshold">Days until expiry</param>
            /// <returns>Formatted expiry report</returns>
            string GenerateExpiryReport(int daysThreshold);
        }
    
}
