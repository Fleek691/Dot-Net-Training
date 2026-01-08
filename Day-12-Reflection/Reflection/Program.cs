using System.Reflection;
using Example;
public class Program
{
    public static void Main(string[] args)
    {
        // Student r=new Student();
        // var props=r.GetType().GetProperties(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Public).ToList();
        // foreach(var prop in props)
        // {
        //     System.Console.WriteLine(prop);
        // }

        Assembly am=Assembly.LoadFrom("C:\\Users\avish\\Desktop\\Dot-Net-Training\\Day-11-Serialization\\Serialization\bin\\Debug\net10.0\\Serialization.dll");
        Type t=am.GetType();
        object obj=Activator.CreateInstance(t);
        var props=t.GetProperties();
        foreach(var prop in props)
        {
            System.Console.WriteLine(prop);
        }
    }
}