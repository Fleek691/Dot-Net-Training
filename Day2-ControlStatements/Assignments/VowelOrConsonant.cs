using System;
public class VowelOrConsonant
{
    public static void CheckAlphabet()
    {
        Console.WriteLine("Enter the Alphabet: ");

        string? chare=Console.ReadLine();
        if (string.IsNullOrEmpty((chare)))
        {
            return;
        }
        char ch=chare[0];
        switch (char.ToLower(ch))
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                Console.WriteLine($"{ch} is a Vowel.");
                break;

            default:
                if (char.IsLetter(ch))
                {
                    Console.WriteLine($"{ch} is a Consonant.");
                }
                else
                {
                    Console.WriteLine("Enter a valid Alphabet.");
                }
                break;
        }

    }
}