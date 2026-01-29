public class ExceptionClass
{
    public int ExceptionMethod(int i)
    {
        if (i == 1)
        {
            throw new DivideByZeroException("Divided by zero");
        }
        else if (i == 2)
        {
            throw new NullReferenceException("Null reference");
        }
        else if (i == 3)
        {
            throw new InvalidCastException("invalid cast");
        }
        else if(i==4)
        {
            throw new StackOverflowException("Stack overflow");
        }
        else
        {
            return 100;
        }
    }
}