public interface IPrint
{
    public void Print()//WOrksin dotnet 10 but should not use
    {
        System.Console.WriteLine("Parent interface");
    }
    
}

public class Child : IPrint
{
    public void Print()
    {
        System.Console.WriteLine("Interface child");
    }
}