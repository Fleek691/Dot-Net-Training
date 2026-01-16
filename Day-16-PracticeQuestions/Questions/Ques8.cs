public class User1
{
    public string Name{get;set;}
    public string PhoneNumber{get;set;}
}
public class Ques8
{
    public static void Main(string[] args)
    {
        try
        {
            User1 user1=ValidatePhoneNumber("Avishek","779716280");
            if (user1 != null)
            {
                System.Console.WriteLine("Valid Phone Number");
            }
        }catch(InvalidPhoneNumberException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    public static User1 ValidatePhoneNumber(string name,string phoneNumber)
    {
        User1 user1;
        if (phoneNumber.Length == 10)
        {
            user1=new User1
            {
                Name=name,
                PhoneNumber=phoneNumber
            };
        }
        else
        {
            throw new InvalidPhoneNumberException();
        }
        return user1;
    }
}
public class InvalidPhoneNumberException : Exception
{
    public override string Message =>"Invalid phone number.";
}