using System;
using System.Collections;
namespace BigBoys
{
public class BigBoy : IDisposable
{
    public ArrayList Names { get; set; }

    public BigBoy()
    {
        Console.WriteLine("BigBoy created");
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing BigBoy");

        if (Names != null)
        {
            Names.Clear();   // release references
            Names = null;
        }

        // If there were unmanaged resources, they would be freed here
    }
        ~BigBoy()
        {
            Names=null;
        }
}
}