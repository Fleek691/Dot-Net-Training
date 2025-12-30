namespace GarbageCollection{
public class Program
{
    static void Main(string[] args)
    {
        var list=new List<byte[]>();
        for(int i = 0; i < 20000; i++)
        {
            list.Add(new byte[1024]);
        }
        System.Console.WriteLine("Allocated.");
        System.Console.WriteLine("total memory: "+GC.GetTotalMemory(forceFullCollection: false));
        list.Clear();
        list=null;
        GC.Collect();
        System.Console.WriteLine("total memory: "+GC.GetTotalMemory(true));

    }
}
}