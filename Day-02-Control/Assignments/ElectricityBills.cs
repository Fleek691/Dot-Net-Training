using System;
 public class ElectricityBill
{
    /// <summary>
    /// Function to Calculat Electricity bill
    /// </summary>
    public static void BillValue()
    {
        Console.WriteLine("Enter the meter value in units: ");
        double unit=Convert.ToDouble(Console.ReadLine());
        double amount=0;
        if (unit < 200)
        {
            amount=unit*1.20;
        }else if(200<=unit && unit <= 400)
        {
            double bill=unit*1.50;
            amount=(bill*(15/100))+bill;
        }
        else if(400<unit && unit <= 600)
        {
            double bill=unit*1.80;
            amount=(bill*(15/100))+bill;
        }
        else
        {
            double bill=unit*2.00;
            amount=(bill*(15/100))+bill;
        }
        Console.WriteLine($"The Electricity Bill is: {amount}"); 
    }
}