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
                TimeSpan.FromMilliseconds(1)//The time written is the limit if cant run within this limit then we get error
            );
            System.Console.WriteLine(rx.IsMatch(input)?"Found":"Not Found");
            
    }
}
}
