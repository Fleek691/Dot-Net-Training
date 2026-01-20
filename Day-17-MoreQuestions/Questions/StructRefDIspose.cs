public ref struct TempBuffer
{
    public void Dispose()
    {
        Console.WriteLine("Dispose called!");
    }
}

public class StructRef
{
    public static void Main(string[] args)
    {
        UseBuffer();
    }
    
    public static void UseBuffer()
{
    using var buf = new TempBuffer();
    Console.WriteLine("Inside using block");
}

}