namespace ConsumingData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Category {  get; set; }
        

    }
    public class ProductRespone
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Total { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
