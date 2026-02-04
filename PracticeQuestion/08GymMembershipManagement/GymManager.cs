public class GymManager
{
    private Dictionary<int,Member>memberList=new ();
    private List<FitnessClass> classes=new List<FitnessClass>();
    private int id=1;
    public void AddMember(string name, string membershipType, int months)
    {
        memberList.Add(id,new Member(id,name,membershipType,months));
        id++;
    }
    // Creates membership with expiry date

    public void AddClass(string className, string instructor,DateTime schedule, int maxParticipants)
    {
        classes.Add(new FitnessClass(className,instructor,schedule,maxParticipants));
    }

    public bool RegisterForClass(int memberId, string className)
    {
        if (!memberList.ContainsKey(memberId))
        return false;

        var member = memberList[memberId];

        if (member.ExpiryDate < DateTime.Now)
            return false;

        var fitnessClass = classes.FirstOrDefault(c => c.ClassName == className);

        if (fitnessClass == null)
            return false;

        if (fitnessClass.RegisteredMembers.Count >= fitnessClass.MaxParticipants)
            return false;

        if (fitnessClass.RegisteredMembers.Contains(member.Name))
            return false;

        fitnessClass.RegisteredMembers.Add(member.Name);
        return true;

    }
    // Registers member if class has space

    public Dictionary<string, List<Member>> GroupMembersByMembershipType()
    {
        var res=memberList.Values.GroupBy(e=>e.MembershipType).ToDictionary(g=>g.Key,g=>g.ToList());
        return res;
    }
    // Groups members by their plan

    public List<FitnessClass> GetUpcomingClasses()
    {
        var res=classes.Where(e=>e.Schedule>=DateTime.Now && e.Schedule<=DateTime.Now.AddDays(7)).ToList();
        return res;
    }
    // Returns classes scheduled for next 7 days
}