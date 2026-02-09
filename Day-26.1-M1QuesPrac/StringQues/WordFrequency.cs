public class WordFrequency
{
    public static void Main()
    {
        System.Console.WriteLine("Enter the sentence: ");
        string input=Console.ReadLine()!;
        string[] parts=input.Split(" ");
        Dictionary<string,int> wordCount=new Dictionary<string,int>();
        for(int i = 0; i < parts.Length; i++)
        {
            int count=0;
            
            for(int j = 0; j < parts.Length; j++)
            {
                if (parts[i].Equals(parts[j],StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
            wordCount[parts[i].ToLower()]=count;
        }
        System.Console.WriteLine("Word count");
        foreach(var item in wordCount)
        {
            System.Console.WriteLine($"{item.Key} = {item.Value}");
        }
    }
}