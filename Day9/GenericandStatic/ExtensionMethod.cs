public static class ExtendedStaticClass//refer to static class
{
    public static void RollNoType(this int RollNo)
    {
        System.Console.WriteLine( RollNo.GetType());
    }
}