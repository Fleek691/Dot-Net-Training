
class Controller
{
    static void Main()
    {
        // TODO:
        // Call Service method
        // Handle exception here
        try
        {
            Service.Process();
        }catch(Exception ex)
        {
            System.Console.WriteLine("Now in Controller "+ex.Message);
        }
    }
}

class Service
{
    public static void Process()
    {
        // TODO:
        // Call Repository method
        // Catch, log and rethrow exception
        try
        {
            Repository.GetData();

        }catch(Exception ex)
        {
            System.Console.WriteLine("Logging Exception from called method "+ex.Message);
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        throw new FormatException("Exception in Repo");
    }
}