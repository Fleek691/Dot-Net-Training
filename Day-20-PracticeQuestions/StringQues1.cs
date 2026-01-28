

public class Ques1
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the sentence: ");
        string input=Console.ReadLine()!;
        if (IsAlpha(input))
        {
            string res=WordWand(input);
            System.Console.WriteLine(res);
        }
        else
        {
            System.Console.WriteLine("Invalid Sentence");
        }
    }
    public static string WordWand(string input)
    {
        string result="";
        string[] parts=input.Split(" ");
        if ((parts.Length) % 2 == 0)
        {
            int i=0;
            int j=parts.Length-1;
            while (i < j)
            {
                var temp=parts[i];
                parts[i]=parts[j];
                parts[j]=temp;
                i++;
                j--;
            }
            for(int k = 0; k < parts.Length; k++)
            {
                result+=parts[k]+" ";
            }
        }
        else
        {
            for(int i = 0; i < parts.Length; i++)
            {
                string temp=new string(parts[i].Reverse().ToArray());
                result+=temp+" ";
            }
        }
        
        return  result;
    }
    public static bool IsAlpha(string input)
    {

        string[] parts=input.Split(" ");
        for(int i = 0; i < parts.Length; i++)
        {
            foreach(char c in parts[i])
        {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
                
        }
        
        }

        return true;
    }
}
