using System.Security.AccessControl;

public static class GeneralUse
{
    public static int RollNo;

    static GeneralUse()
    {
        RollNo=1;
    }
    public static int GetRno()
    {
        return RollNo;
    }
}