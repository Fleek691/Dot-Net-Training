public class ExceptionSequence
{
    public static void DemonstrateExceptionSequence()
    {
        try
        {
            Divide(10,0);
        }
        catch(DivideByZeroException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch(ArithmeticException ex)
        {
            System.Console.WriteLine("Caught arithmetic exception"+ex.Message);
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Caught parent exception");
        }
    }
    public static int Divide(int a,int b)
    {
        return a/b;
    }
}
    // public static void DemonstrateExceptionSequence()
    // {
    //     try
    //     {
    //         // Code that might throw an exception
    //         int divisor = 0;
    //         int result = 10 / divisor; // This will throw DivideByZeroException
    //     }
    //     catch (DivideByZeroException ex)
    //     {
    //         Console.WriteLine("Caught DivideByZeroException: " + ex.Message);
    //     }
    //     catch (ArithmeticException ex)
    //     {
    //         Console.WriteLine("Caught ArithmeticException: " + ex.Message);
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine("Caught general Exception: " + ex.Message);
    //     }
    //     finally
    //     {
    //         Console.WriteLine("Finally block executed.");
    //     }
    // }
