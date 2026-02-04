
class DatabaseConnection
{
    private static bool isConnected = false;

    static void Main()
    {
        try
        {
            // 1. Open connection
            OpenConnection();
            System.Console.WriteLine("Connection opened successfully.");

            // 2. Simulate operation failure
            System.Console.WriteLine("Performing database operation...");
            throw new InvalidOperationException("Database operation failed!");
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // 3. Ensure connection is closed properly
            CloseConnection();
            System.Console.WriteLine("Connection closed.");
        }
    }

    static void OpenConnection()
    {
        isConnected = true;
    }

    static void CloseConnection()
    {
        if (isConnected)
        {
            isConnected = false;
        }
    }
}