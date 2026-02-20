// using System.Text.RegularExpressions;

// public class Programw
// {
//     static void Main(string[] agrs)
//     {
//         // string input="Error: Timeout from API";
//         // string patter=@"timeout";
//         // var rx=new Regex
//         // (
//         //     patter,RegexOptions.IgnoreCase,
//         //     TimeSpan.FromMilliseconds(1)//The time written is the limit if cant run within this limit then we get error
//         // );
//         // System.Console.WriteLine(rx.IsMatch(input)?"Found":"Not Found");
//         // Minimum 8 characters
//         // ✔ At least 1 uppercase letter
//         // ✔ At least 1 lowercase letter
//         // ✔ At least 1 digit
//         // ✔ At least 1 special character from: @#$%^&+=!
//         // ✔ No spaces allowed

//         // Valid Examples:
//         // Strong@123
//         // Hello#2024
//         // MyPass!9
//         System.Console.WriteLine("Input");
//         string input=Console.ReadLine()!;
//         bool isValid=Regex.IsMatch(input,"(?=.*[0-9])");
//         if (isValid)
//         {
//             System.Console.WriteLine("valid");
//         }
//         else
//         {
//             System.Console.WriteLine("invalid");
//         }
//     }
// }
using System.Text.RegularExpressions;

public class Programw
{
    public static void Main()
    {
        string inputs = "28-14)-54";

        var matches=Regex.IsMatch(inputs,@"^[0-9]{2}-.{3}-[0-9]{2}$");
        System.Console.WriteLine(matches);

    }
}
