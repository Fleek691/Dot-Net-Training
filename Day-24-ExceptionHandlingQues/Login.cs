using System;

class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        string password = "12345678";
        bool loginSuccess = false;

        try
        {
            while (attempts < 3)
            {
                System.Console.WriteLine("Enter Password");
                string pass = Console.ReadLine()!;

                if (pass == password)
                {
                    System.Console.WriteLine("Login Successfull");
                    loginSuccess = true;
                    break;
                }
                else
                {
                    attempts++;
                    if (attempts < 3)
                    {
                        System.Console.WriteLine($"Incorrect password. Attempt {attempts} of 3.");
                    }
                }
            }

            if (attempts == 3 && !loginSuccess)
            {
                throw new LimitExceededException("Limit exceed for attempts");
            }
        }
        catch (LimitExceededException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            System.Console.WriteLine("Application terminating...");
        }

        // TODO:

        // 1. Allow only 3 login attempts
        // 2. Create and throw custom exception after limit
        // 3. Handle exception and terminate application
    }
}
public class LimitExceededException : Exception
{
    public LimitExceededException(string message) : base(message)
    {

    }
}
