public class Father
{
    public virtual string InterestOf()
    {
        return "I like Cricket";
    }
}
public class Son : Father
{
    public override string InterestOf()
    {
        return "Mobile Games";
    }
}

