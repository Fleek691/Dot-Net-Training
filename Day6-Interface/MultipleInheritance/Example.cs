public interface IvegEater
{
    public void IEat();
    public void getTaste();
}
public interface INonvegEater
{
    public void IEatNon();
    public void getTaste();

}



// public class VegEater:IvegEater

// {
//     public void IEat()
//     {
//         System.Console.WriteLine("I eat veg");
//     }
// }
// public class NonVegEater:INonvegEater

// {
//     public void IEatNon()
//     {
//         System.Console.WriteLine("I eat Non Veg");
//     }
// }


    public class Visitor : IvegEater, INonvegEater
{
    public  void IEat()
    {
     System.Console.WriteLine("I eat veg");   
    }

    public void IEatNon()
    {
        Console.WriteLine("Visitor eats non-veg");
    }
    void IvegEater.getTaste()
    {
        System.Console.WriteLine("Veg tastes nice");
    }
    void INonvegEater.getTaste()
    {
        System.Console.WriteLine("Non veg tastes better");
    }
}

