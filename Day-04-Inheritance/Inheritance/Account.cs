public class Account
{
    public string Name{get;set;}
    public int id{get;set;}
    public string GetAccountDetails()
    {
        return $"I am Base Account. My id is {id}";
    }

    
}
public class SalesAccount : Account
{
    public string GetSalesAccountDetails(){
    String info=String.Empty;
    info +=base.GetAccountDetails();
    info +=$"I am Derived class. My Account id is {id}";
    return info;
}
}
public class PurchaseAccount:SalesAccount
{
    public string  GetPurchaseAccountDetails(){
    string pinfo=String.Empty;
    pinfo+=base.GetSalesAccountDetails();
    pinfo+=$"I am Derived class of Sales. My Account id is {id}";
    return pinfo;
}
}