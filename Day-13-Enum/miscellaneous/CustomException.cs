using System.Reflection.Metadata;

public class AppCustomeException : Exception
{
    // public override string Message => "Internal Exception"; this kills the original message
    public override string Message => HandleBase(base.Message);

    private static string HandleBase(string sysMessage)
    {
     Console.WriteLine(sysMessage);
     return "Internal Exception Occurred. Please contact Admin";   
    }
}