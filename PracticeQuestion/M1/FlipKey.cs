using System.Text;

public class FlipKey
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine()!;
        string result = CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine($"The generated key is - {result}");
        }
    }

    // Validates input and processes it: filters odd ASCII chars, reverses, and capitalizes even positions
    public static string CleanseAndInvert(string input)
    {
        string result = "";

        // Validate: minimum 6 characters, only letters
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return result;
        }

        foreach (char c in input)
        {
            if (!char.IsLetter(c))
            {
                return result;
            }
        }

        input = input.ToLower();

        // Filter characters with odd ASCII values
        string filtered = "";
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
            {
                filtered += c;
            }
        }

        // Reverse and capitalize characters at even positions
        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);

        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
            {
                arr[i] = char.ToUpper(arr[i]);
            }
        }

        result = new string(arr);
        return result;
    }
}