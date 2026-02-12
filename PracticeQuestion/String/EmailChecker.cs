public class EmailChecker
{
    public static void Main()
    {
        System.Console.WriteLine("Enter the gmail: ");
        string input=Console.ReadLine()!;
        bool isLower=input!.Where(char.IsLetter).All(char.IsLower);
        if( !isLower)
        {
            System.Console.WriteLine("Invalid EMail");
            return;
        }
        int count=0;
        foreach(char ch in input)
        {
            if (ch == '@')
            {
                count++;
            }
        }
        if (count != 1)
        {
            Console.WriteLine("Invalid");
            return;
        }
        string[] parts=input.Split("@");
        foreach(char ch in parts[0])
        {
            if (char.IsLetterOrDigit(ch))
            {
                continue;
            }
            else
            {
                Console.WriteLine("Invalid");
                return;
            }
        }
        if(!parts[1].ToString().Contains(".")){Console.WriteLine("Invalid Input");
        return;}
        int dotcount=0;
        foreach(char ch in parts[1])
        {
            if (ch == '.')
            {
                dotcount++;
            }
        }
        if (dotcount != 1)
        {
            Console.WriteLine("Invalid Email");
            return;
        }
        Console.WriteLine("Valid");
    }
}