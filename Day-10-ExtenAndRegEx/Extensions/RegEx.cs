using System.Text.RegularExpressions;

namespace RegEx
{
    public class Program
    {
        static void Main(string[] agrs)
        {
            string input="Error: Timeout from API";
            string patter=@"timeout";
            var rx=new Regex
            (
                patter,RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(150)
            );
            System.Console.WriteLine(rx.IsMatch(input)?"Found":"Not Found");
    }
}
}