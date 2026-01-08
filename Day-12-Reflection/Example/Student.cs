namespace Example
{
    public class Student
{
    private int _id;
    public int Id
    {
        get=>_id;
        set=>_id=value;
    }
    public string? Name{get;set;}

    public void GetDetails()
    {
        System.Console.WriteLine($"ID is: {this._id},Name: {Name}");
    }
}
}