public class Program
{
    public static void Main(string[] args)
    {
        Visitor a=new Visitor();
        a.IEat();
        a.IEatNon();

        IvegEater vegEat=new Visitor();
        vegEat.getTaste();
        INonvegEater nonvegEat=new Visitor();
        nonvegEat.getTaste();
    }
}