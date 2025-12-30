namespace BigBoys{
public class Program
{
    public static void Main(string[] args)
    {
        BigBoy bigBoy=new BigBoy();
        try
        {
            bigBoy.Names=new System.Collections.ArrayList();
            for(int i = 0; i < 10; i++)
            {
                bigBoy.Names.Add(i.ToString());
            }
        }
        catch(Exception ex)
        {
            throw;
        }
        finally
        {
            bigBoy.Dispose();
        }
    }
}
}