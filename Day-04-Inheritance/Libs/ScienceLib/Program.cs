namespace ScienceLib
{
    public class Sciences
    {
        // Physics: Speed = Distance / Time
        public double CalculateSpeed(double distance, double time)
        {
            if (time <= 0)
                throw new ArgumentException("Time must be greater than zero");

            return distance / time;
        }

        // Physics: Density = Mass / Volume
        public double CalculateDensity(double mass, double volume)
        {
            if (volume <= 0)
                throw new ArgumentException("Volume must be greater than zero");

            return mass / volume;
        }

        // Chemistry: Check if temperature (°C) is boiling point of water
        public bool IsWaterBoiling(double temperatureCelsius)
        {
            return temperatureCelsius >= 100;
        }

        // Biology: Simple age classification
        public string LifeStage(int age)
        {
            if (age < 0)
                return "Invalid age";

            if (age <= 12)
                return "Child";
            else if (age <= 19)
                return "Teenager";
            else
                return "Adult";
        }
    }
}
