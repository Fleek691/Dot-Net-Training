public class EmailCleaner
{
    public static void Main()
    {
        System.Console.WriteLine("Enter email: ");
        string email=Console.ReadLine()!;
        email=new string(email.Where(e=>!char.IsWhiteSpace(e)).ToArray());
        email=email.ToLower();
        if (email.EndsWith("gmail.com"))
        {
            email=email.Replace("gmail.com","company.com");
        }
        System.Console.WriteLine("Cleaned email: "+email);
        
    }
}