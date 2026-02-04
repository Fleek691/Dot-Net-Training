// In class Member:
// - int MemberId
// - string Name
// - string MembershipType (Basic/Premium/Platinum)
// - DateTime JoinDate
// - DateTime ExpiryDate
public class Member
{
    public int MemberId{get;set;}
    public string Name{get;set;}
    public string MembershipType{get;set;}
    public DateTime JoinDate{get;set;}
    public DateTime ExpiryDate{get;set;}
    public Member(int id,string name,string type,int months)
    {
        MemberId=id;
        Name=name;
        MembershipType=type;
        JoinDate=DateTime.Now;
        ExpiryDate=JoinDate.AddMonths(months);
    }
}