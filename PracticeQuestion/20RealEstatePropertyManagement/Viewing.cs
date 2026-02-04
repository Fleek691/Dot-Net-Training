using System;

namespace RealEstatePropertyManagement
{
    public class Viewing
    {
        public int ViewingId { get; set; }
        public string PropertyId { get; set; }
        public int ClientId { get; set; }
        public DateTime ViewingDate { get; set; }
        public string Feedback { get; set; }
    }
}
