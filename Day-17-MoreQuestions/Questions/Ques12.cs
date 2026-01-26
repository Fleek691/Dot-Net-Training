using System;
using System.Collections.Generic;
public abstract class Cars
{
    protected bool isSedan;
    protected string seats;
    public Cars(bool isSedan,string seats)
    {
        this.isSedan=isSedan;
        this.seats=seats;
    }
    public bool GetisSedan()
    {
        return this.isSedan;
    }
    public string getSeats()
    {
        return this.seats;
    }
    public abstract string GetMileage();
}
public class WagonR : Cars
{
    private int mileage;
    public WagonR(int mileage) : base(false,"4")
    {
        this.mileage=mileage;
    }
    public override string GetMileage()
    {
        return $"{mileage} kmpl";
    }
}
public class HondaCity : Cars
{
    private int mileage;

    public HondaCity(int mileage) : base(false,"4")
    {
        this.mileage=mileage;
    }
    public override string GetMileage()
    {
        return $"{mileage} kmpl";
    }
}
public class InnovaCrysta : Cars
{
    private int mileage;

    public InnovaCrysta(int mileage) : base(false,"6")
    {
        this.mileage=mileage;
    }
    public override string GetMileage()
    {
        return $"{mileage} kmpl";
    }
}
class Ques12
{
    static void Main()
    {
        int type = int.Parse(Console.ReadLine());   // 0,1,2
        int mileage = int.Parse(Console.ReadLine());

        Cars car;

        if (type == 0)
            car = new WagonR(mileage);
        else if (type == 1)
            car = new HondaCity(mileage);
        else
            car = new InnovaCrysta(mileage);

        Console.WriteLine("A car is" + (car.GetisSedan() ? " " : " not ") + "Sedan");
        Console.WriteLine("Seats: " + car.getSeats());
        Console.WriteLine("Mileage: " + car.GetMileage());
    }
}
