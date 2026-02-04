using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            // TODO:
            // Handle final exception
            System.Console.WriteLine("Second Catch: " + ex.GetType().Name);
            System.Console.WriteLine("Error Message: " + ex.Message);
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception ex)
        {
            // TODO:
            System.Console.WriteLine("First Catch: " + ex.GetType().Name);
            throw; // Rethrow while preserving stack trace
        }
    }
}