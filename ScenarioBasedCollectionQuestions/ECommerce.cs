namespace Ques
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        Category Category { get; }
    }

    public enum Category { Electronics, Clothing, Books, Groceries }

    // 1. Create a generic repository for products
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();

        // TODO: Implement method to add product with validation
        public void AddProduct(T product)
        {
            // Rule: Product ID must be unique
            // Rule: Price must be positive
            // Rule: Name cannot be null or empty
            // Add to collection if validation passes
            foreach (var item in _products)
            {
                if (item.Id == product.Id)
                {
                    System.Console.WriteLine("Already Exists");
                    return;
                }
            }
            if (product.Price < 0)
            {
                System.Console.WriteLine("Invalid Price");
                return;
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                System.Console.WriteLine("Invalid Name");
                return;
            }
            _products.Add(product);
        }

        // TODO: Create method to find products by predicate
        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            var result = new List<T>();
            // Should return filtered products
            foreach (var item in _products)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return (IEnumerable<T>)result;
        }

        // TODO: Calculate total inventory value
        public decimal CalculateTotalValue()
        {
            // Return sum of all product prices
            decimal a = _products.Sum(e => e.Price);
            return a;
        }
    }

    // 2. Specialized electronic product
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }
    }

    // 3. Create a discounted product wrapper
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            // TODO: Initialize with validation
            // Discount must be between 0 and 100
            if (discountPercentage < 0 || discountPercentage > 100)
            {
                throw new ArgumentException("Discount must be between 0 and 100");
            }
            _product = product;
            _discountPercentage = discountPercentage;
        }

        // TODO: Implement calculated price with discount
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);
        public decimal CalculatedPrice => _product.Price * (_discountPercentage / 100);

        // TODO: Override ToString to show discount details
        public override string ToString()
        {
            return $"Actual Price: {_product.Price} after discount of {DiscountedPrice} is {CalculatedPrice}";
        }
    }

    // 4. Inventory manager with constraints
    public class InventoryManager
    {
        // TODO: Create method that accepts any IProduct collection
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            // a) Print all product names and prices
            foreach (var item in products)
            {
                System.Console.WriteLine($"{item.Name} {item.Price}");
            }
            var a = products.Max(e => e.Price);
            System.Console.WriteLine($"Max Price: {a}");
            // b) Find the most expensive product
            // c) Group products by category
            var gbCat = products.GroupBy(e => e.Category);
            foreach (var category in gbCat)
            {
                System.Console.WriteLine($"\nCategory: {category.Key}");
                foreach (var product in category)
                {
                    System.Console.WriteLine($"  - {product.Name}: ${product.Price}");
                }
            }
            // d) Apply 10% discount to Electronics over $500
            foreach (var item in products)
            {
                if (item.Category == Category.Electronics && item.Price > 500 && item is ElectronicProduct ep)
                {
                    ep.Price = ep.Price - (ep.Price * 10 / 100);
                }
            }
        }

        // TODO: Implement bulk price update with delegate
        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
        {
            // Apply priceAdjuster to each product
            try
            {
                foreach (var product in products)
                {
                    var updatedPrice = priceAdjuster(product);
                    if (product is ElectronicProduct electronicProduct)
                    {
                        electronicProduct.Price = updatedPrice;
                    }
                }
            }
            // Handle exceptions gracefully
            catch (Exception ex)
            {
                Console.WriteLine($"Error during bulk update: {ex.Message}");
            }
        }
    }

    // 5. TEST SCENARIO: Your tasks:
    // a) Implement all TODO methods with proper error handling
    // b) Create a sample inventory with at least 5 products
    // c) Demonstrate:
    //    - Adding products with validation
    //    - Finding products by brand (for electronics)
    //    - Applying discounts
    //    - Calculating total value before/after discount
    //    - Handling a mixed collection of different product types

    class Program
    {
        static void Main()
        {
            // Create product repository
            var repo = new ProductRepository<ElectronicProduct>();

            // Create sample products
            var laptop = new ElectronicProduct { Id = 1, Name = "Dell Laptop", Price = 800, Brand = "Dell", WarrantyMonths = 24 };
            var phone = new ElectronicProduct { Id = 2, Name = "iPhone 14", Price = 999, Brand = "Apple", WarrantyMonths = 12 };
            var tablet = new ElectronicProduct { Id = 3, Name = "iPad Pro", Price = 1200, Brand = "Apple", WarrantyMonths = 12 };
            var headphones = new ElectronicProduct { Id = 4, Name = "Sony Headphones", Price = 250, Brand = "Sony", WarrantyMonths = 12 };
            var monitor = new ElectronicProduct { Id = 5, Name = "LG Monitor", Price = 350, Brand = "LG", WarrantyMonths = 36 };

            // a) Add products with validation
            Console.WriteLine("=== Adding Products ===");
            repo.AddProduct(laptop);
            repo.AddProduct(phone);
            repo.AddProduct(tablet);
            repo.AddProduct(headphones);
            repo.AddProduct(monitor);

            // Try adding invalid product
            repo.AddProduct(new ElectronicProduct { Id = 1, Name = "Invalid", Price = 100 }); // Duplicate ID
            repo.AddProduct(new ElectronicProduct { Id = 6, Name = "", Price = 100 }); // Empty name

            // b) Find products by brand (Electronics)
            Console.WriteLine("\n=== Finding Apple Products ===");
            var appleProducts = repo.FindProducts(p => p.Brand == "Apple");
            foreach (var product in appleProducts)
            {
                Console.WriteLine($"- {product.Name}: ${product.Price}");
            }

            // Calculate total value before discount
            Console.WriteLine($"\n=== Total Inventory Value (Before Discount) ===");
            var totalBefore = repo.CalculateTotalValue();
            Console.WriteLine($"Total: ${totalBefore}");

            // c) Apply discounts to products
            Console.WriteLine("\n=== Applying 15% Discount ===");
            var discountedLaptop = new DiscountedProduct<ElectronicProduct>(laptop, 15);
            Console.WriteLine($"Laptop: {discountedLaptop}");

            // d) Process products (group by category, apply discounts to expensive items)
            Console.WriteLine("\n=== Processing All Products ===");
            var manager = new InventoryManager();
            var allProducts = new List<ElectronicProduct> { laptop, phone, tablet, headphones, monitor };
            manager.ProcessProducts(allProducts);

            // e) Bulk price update with delegate
            Console.WriteLine("\n=== Bulk Update Prices (Add 5% for inflation) ===");
            manager.UpdatePrices(allProducts, p => p.Price * 1.05m);
            foreach (var product in allProducts)
            {
                Console.WriteLine($"- {product.Name}: ${product.Price:F2}");
            }

            Console.WriteLine($"\n=== Total Inventory Value (After Updates) ===");
            var totalAfter = repo.CalculateTotalValue();
            Console.WriteLine($"Total: ${totalAfter:F2}");
        }
    }

}



