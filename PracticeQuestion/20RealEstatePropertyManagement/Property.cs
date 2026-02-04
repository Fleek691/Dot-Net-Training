namespace RealEstatePropertyManagement
{
    public class Property
    {
        public string PropertyId { get; set; }
        public string Address { get; set; }
        public string PropertyType { get; set; } // Apartment/House/Villa
        public int Bedrooms { get; set; }
        public double AreaSqFt { get; set; }
        public double Price { get; set; }
        public string Status { get; set; } // Available/Sold/Rented
        public string Owner { get; set; }
    }
}
