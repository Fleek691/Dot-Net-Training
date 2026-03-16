namespace BikeStores.Models;

public class ProductPageViewModel
    {
        public List<Product> Products { get; set; } = new();
        public int CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
    }