public partial class YoungProfessional
{
    // Using properties from first partial
    public void InitializeProfile(int personalId, int rNo, string name)
    {
        PersonalId = personalId;   // private set → allowed (same class)
        RNo = rNo;
        Name = name;
    }

    // Using DateOfBirth set through method
    public void UpdateDOB(string dob)
    {
        SetDateOfBirth(dob); // calling method from first partial
    }

    // Using everything together
    public void PrintDetails()
    {
        Console.WriteLine("Personal Id: " + PersonalId);
        Console.WriteLine("Roll No: " + RNo);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("DOB: " + DateOfBirth);
    }
}
