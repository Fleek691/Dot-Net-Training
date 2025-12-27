using CommonLib;

public class ScienceLogin : LoginAbs
{
    public override void Login(string UserName, string Password)
    {
        System.Console.WriteLine($"{UserName} {Password}");
    }
    public override void Logout()
    {
        System.Console.WriteLine("Logout");
    }

    
}