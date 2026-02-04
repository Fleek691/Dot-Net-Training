using System;

namespace InventoryStockManagement
{
    public class StockMovement
    {
        public int MovementId { get; set; }
        public string ProductCode { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; } // In/Out
        public int Quantity { get; set; }
        public string Reason { get; set; } // Purchase/Sale/Return
    }
}
