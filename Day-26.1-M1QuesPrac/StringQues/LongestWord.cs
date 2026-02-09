public class LongestWord
{
    public static void Main()
    {
        System.Console.WriteLine("Enter the sentence: ");
        string input = Console.ReadLine()!;
        string[] parts = input.Split(" ");

        int max = int.MinValue;
        foreach (var part in parts)
        {
            string temp = "";
            foreach (var ch in part)
            {
                if (char.IsLetter(ch))
                {
                    temp += ch;

                }
            }
            if (temp.Length > max)
            {
                max = temp.Length;
            }
        }
        foreach (var part in parts)
        {
            string temp = "";
            foreach (var ch in part)
            {
                if (char.IsLetter(ch))
                {
                    temp += ch;

                }
            }
            if (temp.Length == max)
            {
                System.Console.WriteLine(part);
                return;
            }

        }
    }
}