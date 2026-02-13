using Microsoft.VisualBasic;

namespace String
{
    // Password Generator class
    public class Program
    {
        // Main entry point
        public static void Main(string[] args)
        {
            // Prompt user for username
            System.Console.WriteLine("Enter the UserName: ");
            string UserName = Console.ReadLine()!;
            string result = "";

            // Validate username and generate password if valid
            if (validateUserName(UserName))
            {
                result = PasswordGenerator(UserName);
            }
            else
            {
                System.Console.WriteLine($"{UserName} is an invalid Username");
            }

            // Display result
            System.Console.WriteLine(result);

        }
        // Generate password from username
        public static string PasswordGenerator(string name)
        {
            string password = "TECH_";
            int sum = 0;

            // Sum ASCII values of first 4 characters
            name.ToLower();
            for (int i = 0; i < 4; i++)
            {
                sum += (int)name[i];
            }

            // Append sum to password
            password += sum.ToString();

            // Append last 2 digits
            password += int.Parse(name.Substring(name.Length - 2));
            return password;

        }
        // Validate username format
        public static bool validateUserName(string name)
        {
            // Check length is 8
            if (name.Length != 8)
            {
                return false;
            }
            // Check first 4 characters are uppercase
            for (int i = 0; i < 4; i++)
            {
                if (!char.IsUpper(name[i])) return false;
            }

            // Check 5th character is '@'
            if (name[4] != '@')
            {
                return false;
            }

            // Check last 3 characters are between 110-115
            int.TryParse(name.Substring(name.Length - 3), out int courseId);
            if (courseId > 115 || courseId < 101)
            {
                return false;
            }
            return true;
        }
    }
}