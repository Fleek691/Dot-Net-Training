public class User
{
    public string? Name{get;set;}
    public string? Password{get;set;}
    public string ConfirmPassword{get;set;}
}
public class Ques6
{
    public static void Main(string[] args)
    {
        try
        {
            User user=ValidationPassword("Avishek","1234","1234");
            if (user != null)
            {
                System.Console.WriteLine("Registered Successfully");
            }
        }catch(PasswordMisMatchException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    public static User ValidationPassword(string name,string password,string confirmpassword)
    {
        if (password != confirmpassword)
        {
            throw new PasswordMisMatchException();
        }
        User user=new User
        {
            Name=name,
            Password=password,
            ConfirmPassword=confirmpassword
        };
        return user;

    }
}
public class PasswordMisMatchException : Exception
{
    public override string Message =>"Password entered do not match.";
}