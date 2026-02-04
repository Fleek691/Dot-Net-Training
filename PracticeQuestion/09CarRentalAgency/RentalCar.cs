namespace CarRentalAgency
{
    public class RentalCar
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; } // Sedan/SUV/Van
        public bool IsAvailable { get; set; }
        public double DailyRate { get; set; }
        public RentalCar(string license,string make,string model,string type,double rate)
        {
            LicensePlate=license;
            Make=make;
            Model=model;
            CarType=type;
            IsAvailable=true;
            DailyRate=rate;
        }
    }
}