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

public abstract class LoginAbs
{
    public abstract void Login(string UserName, string Password);
    public abstract void Logout();
}