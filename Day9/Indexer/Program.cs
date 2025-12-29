
namespace IndexerExample
{
    public class Program
    {
        public static void Main(string[] args)
            {
                MyData a=new MyData();
                a[0]="C";//a[0] means first item of that particular object and so on..
                a[1]="C++";
                a[2]="C#";

                System.Console.WriteLine($"The first value of the indexer is {a[0]}");
                System.Console.WriteLine($"The second value of the indexer is {a[1]}");
                System.Console.WriteLine($"The third value of the indexer is {a[2]}");

            }
    }
}