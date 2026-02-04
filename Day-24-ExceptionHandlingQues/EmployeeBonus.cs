using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus=1000;
        
        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                int ratio = bonus / salaries[i];
                System.Console.WriteLine($"Employee {i + 1}: ratio = {ratio}");
            }
            catch (DivideByZeroException ex)
            {
                System.Console.WriteLine($"Employee {i + 1}: {ex.Message}");
                continue;
            }
        }
        
        // TODO:
        // 1. Loop through salaries
        // 2. Divide bonus by salary
        // 3. Handle DivideByZeroException
        // 4. Continue processing remaining employees
    }
}