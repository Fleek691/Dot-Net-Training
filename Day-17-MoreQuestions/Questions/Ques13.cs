using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Price { get; set; }
}

public class CarManagement
{
    // TODO: return most expensive car
    public static Car MostExpensiveCar(List<Car> cars)
    {
        // write your LINQ here
        var mos=cars.OrderByDescending(c=>c.Price).First();
        return mos;
        
    }

    // TODO: return cheapest car
    public static Car CheapestCar(List<Car> cars)
    {
        // write your LINQ here
        var leastExp=cars.OrderBy(c=>c.Price).First();
        return leastExp;
    }

    // TODO: return average price (rounded)
    public static int AveragePriceOfCars(List<Car> cars)
    {
        // write your LINQ here
        var avgPrice=Math.Round(cars.Average(c=>c.Price));
        return (int)avgPrice;
    }

    // TODO: return most expensive car of each brand
    public static Dictionary<string, Car> MostExpensiveModelForEachBrand(List<Car> cars)
    {
        // write your LINQ here
        var MostExpModel=cars.GroupBy(c=>c.Brand).ToDictionary(g=>g.Key,g=>g.OrderByDescending(x=>x.Price).First());
        return MostExpModel;
    }
}

class Ques13
{
    static void Main()
    {
        List<Car> cars = new List<Car>()
        {
            new Car { Brand = "BMW", Model = "X5", Price = 7000000 },
            new Car { Brand = "BMW", Model = "X1", Price = 4500000 },
            new Car { Brand = "Audi", Model = "A6", Price = 6000000 },
            new Car { Brand = "Audi", Model = "Q7", Price = 8000000 },
            new Car { Brand = "Tata", Model = "Nexon", Price = 1200000 },
            new Car { Brand = "Tata", Model = "Harrier", Price = 1800000 }
        };

        var expensive = CarManagement.MostExpensiveCar(cars);
        Console.WriteLine($"Most expensive: {expensive.Brand} {expensive.Model} {expensive.Price}");

        var cheap = CarManagement.CheapestCar(cars);
        Console.WriteLine($"Cheapest: {cheap.Brand} {cheap.Model} {cheap.Price}");

        var avg = CarManagement.AveragePriceOfCars(cars);
        Console.WriteLine($"Average price: {avg}");

        var byBrand = CarManagement.MostExpensiveModelForEachBrand(cars);
        Console.WriteLine("Most expensive car by brand:");
        foreach (var item in byBrand)
        {
            Console.WriteLine($"{item.Key} -> {item.Value.Model} ({item.Value.Price})");
        }
    }
}
