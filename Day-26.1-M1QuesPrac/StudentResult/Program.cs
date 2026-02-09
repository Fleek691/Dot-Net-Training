using System.Reflection;

public class Person
{
    public string Name{get;set;}
    public int Age{get;set;}
    public Person(string name,int age)
    {
        Name=name;
        Age=age;
    }
}
public class Student :Person
{
    public int ROllNo{get;set;}
    public int Marks{get;set;}
    public Student(string name,int age,int rollno,int marks) : base(name, age)
    {
        ROllNo=rollno;
        Marks=marks;
    }
}
public class Helper
{
    public static void Main()
    {
        Student st=new Student("Avishek",22,1,100);
        if (st.Marks < 35)
        {
            System.Console.WriteLine($"{st.Name} who's age is {st.Age} with roll no {st.ROllNo} has Failed with marks {st.Marks}");
        }
        else
        {
            System.Console.WriteLine($"{st.Name} who's age is {st.Age} with roll no {st.ROllNo} has Passed with marks {st.Marks}");
        }
    }
}