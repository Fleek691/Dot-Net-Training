public class EstimateDetails
{
    public float ConstructionArea{get;set;}
    public float SiteArea{get;set;}
}
public class Ques7
{
    public static void Main(string[] args)
    {
        try
        {
            EstimateDetails area=ValidateConstructionEstimate(2000,2001);
            if (area != null)
            {
                System.Console.WriteLine("Approved");
            }
        }
        catch(ConstrucionEstimateException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    public static EstimateDetails ValidateConstructionEstimate(float constructionArea,float siteArea)
    {
        EstimateDetails area;
        if (constructionArea <= siteArea)
        {
            area=new EstimateDetails
        {
            ConstructionArea=constructionArea,
            SiteArea=siteArea,
        };

        }
        else
        {
            throw new ConstrucionEstimateException();
        }
        
        return area;
    }
}
public class ConstrucionEstimateException : Exception
{
    public override string Message => "Sorry your Construction Estimate is not approved";
}