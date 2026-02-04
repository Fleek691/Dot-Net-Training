namespace InventoryStockManagement
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public double UnitPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStockLevel { get; set; }
    }
}
