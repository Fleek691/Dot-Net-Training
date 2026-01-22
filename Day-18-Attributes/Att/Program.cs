public class Att
{
    [Obsolete("Use the Add method this is old")]
    public static  int OldAdd(int a,int b)
    {
        return a+b;
    }
    public static  int Add(int a,int b)
    {
        return a+b;
    }

    public static void Main(string[] args)
    {
        System.Console.WriteLine(OldAdd(1,2));
        System.Console.WriteLine(Add(2,3));
    }
}