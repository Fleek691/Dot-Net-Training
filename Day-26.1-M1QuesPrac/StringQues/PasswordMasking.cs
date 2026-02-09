using System.Text;

public class PassWOrdMAsking
{
    public static void Main()
    {
        System.Console.Write("Enter password: ");
        string password=Console.ReadLine()!;
        if (password.Length < 3)
        {
            System.Console.WriteLine(password);
            return;
        }
        string maskedpass="";
        maskedpass+=password[0];
        for(int i = 1; i < password.Length-1; i++)
        {
           maskedpass+="*";
        }
        maskedpass+=password[password.Length-1];
        System.Console.WriteLine("Masked password: "+maskedpass);
    }
}