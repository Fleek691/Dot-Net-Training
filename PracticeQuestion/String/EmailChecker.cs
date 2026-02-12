public class EmailChecker
{
    public static void Main()
    {
        System.Console.WriteLine("Enter the gmail: ");
        string input=Console.ReadLine()!;
        bool isLower=input!.All(char.IsLower);
        if(!input.Contains("@") || !isLower)
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
        if (count > 1)
        {
        }
        string[] parts=input.Split("@");
        string filteredEMail=string.Empty;
        foreach(char ch in parts[0])
        {
            if (char.IsLetterOrDigit(ch))
            {
                filteredEMail+=ch;
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
        if (dotcount > 1)
        {
            Console.WriteLine("Invalid Email");
            return;
        }
        Console.WriteLine("Valid");
    }
}