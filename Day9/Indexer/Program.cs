
namespace IndexerExample
{
    public class Program
    {
        public static void Main(string[] args)
            {
                // MyData a=new MyData();
                // a[0]="C";//a[0] means first item of that particular object and so on..
                // a[1]="C++";
                // a[2]="C#";

                // System.Console.WriteLine($"The first value of the indexer is {a[0]}");
                // System.Console.WriteLine($"The second value of the indexer is {a[1]}");
                // System.Console.WriteLine($"The third value of the indexer is {a[2]}");

                Student s1=new Student();
                s1.RollNo=1;
                s1.Name="Avishek";
                s1.Address="Punjab";
                s1[0]="Mahabharat";
                s1[1]="Ramayan";

                System.Console.WriteLine($"The name of the student is {s1.Name}");
                System.Console.WriteLine($"The Roll No of the student is {s1.RollNo}");
                System.Console.WriteLine($"The Address of the student is {s1.Address}");
                System.Console.WriteLine($"The first book of the student is {s1[0]}");
                System.Console.WriteLine($"The second book of the student is {s1[1]}");

            }
    }
}