public class Ques2
{
    public static void Main()
    {
        List<int> scans=new();
        System.Console.WriteLine("Enter the number of scans: ");
        int n=int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter scan ids: ");
        for(int i = 0; i < n; i++)
        {
            scans.Add(int.Parse(Console.ReadLine()!));
        }
        HashSet<int> nonDupli=new HashSet<int>();
        foreach(var item in scans)
        {
            nonDupli.Add(item);
        }
        foreach(var item in nonDupli)
        {
            System.Console.Write(item + " ");
        }
    }
}