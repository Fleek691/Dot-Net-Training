public class Membership
{
    public string? Tier{get;set;}
    public int DurationInMonths{get;set;}
    public double BasePricePerMonth{get;set;}
    public bool ValidateEnrollment()
    {
        if(Tier!="Basic" && Tier!="Premium" && Tier != "Elite")
        {
            throw new InvalidTierException("Error: Tier Not Recognized");
        }
        if (DurationInMonths <= 0)
        {
            throw new Exception("Duration cannot be negative or zero");
        }
        return true;
    }
    public double CalculateBill()
    {
        double total=DurationInMonths*BasePricePerMonth;
        if (Tier == "Basic")
        {
            total=total-(total*2/100);
        }
        else if (Tier == "Premium")
        {
            total=total-(total*7/100);
        }
        else if (Tier == "Elite")
        {
            total=total-(total*12/100);
        }
        return total;
    }
}