using System;
using MathLib;
using ScienceLib;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create objects from libraries
            Maths math = new Maths();
            Sciences science = new Sciences();

            // Math library usage
            Console.WriteLine("=== Math Library Demo ===");
            Console.WriteLine($"Add: 10 + 5 = {math.Add(10, 5)}");
            Console.WriteLine($"Subtract: 10 - 5 = {math.Subtract(10, 5)}");
            Console.WriteLine($"Multiply: 10 * 5 = {math.Multiply(10, 5)}");
            Console.WriteLine($"Divide: 10 / 5 = {math.Divide(10, 5)}");
            Console.WriteLine($"Is 10 even? {math.IsEven(10)}");
            Console.WriteLine($"Square of 6 = {math.Square(6)}");

            Console.WriteLine();

            // Science library usage
            Console.WriteLine("=== Science Library Demo ===");
            Console.WriteLine($"Speed (Distance 100, Time 10): {science.CalculateSpeed(100, 10)} m/s");
            Console.WriteLine($"Density (Mass 50, Volume 10): {science.CalculateDensity(50, 10)}");
            Console.WriteLine($"Is water boiling at 90°C? {science.IsWaterBoiling(90)}");
            Console.WriteLine($"Is water boiling at 100°C? {science.IsWaterBoiling(100)}");
            Console.WriteLine($"Life stage for age 20: {science.LifeStage(20)}");

            Console.WriteLine();
            Console.WriteLine("Demo completed successfully.");
        }
    }
}
