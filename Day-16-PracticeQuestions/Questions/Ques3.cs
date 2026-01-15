
public class Ques3{
    public static List<int> NumberList=new List<int>();

    public static void Main(string[] args)
    {
        System.Console.Write("Enter number of marks: ");
        int marks=int.Parse(Console.ReadLine());
        for(int i = 1; i <= marks; i++)
        {
            int num=int.Parse(Console.ReadLine());
            AddNumber(num);
        }
        double gpa=GetGPAScored();
        if (gpa != -1)
        {
            System.Console.WriteLine(gpa);
            char? grade=GetGradeScored(gpa);
        if (grade == null)
        {
            System.Console.WriteLine("Invalid GPA");
        }
        else
        {
            System.Console.WriteLine(grade);
        }
        }
        else
        {
            System.Console.WriteLine("No Numbers Available");
        }
        


    }
    public static void AddNumber(int numbers)
    {
        NumberList.Add(numbers);
    }

    public static double GetGPAScored()
    {
        double gpa=0;
        double res=0;
        foreach(var num in NumberList)
        {
            gpa+=num*3;
        }
        
        if (NumberList.Count== 0)
        {
            return -1;
        }
        else
        {
            res=gpa/(NumberList.Count*3);
            return res;
        }
    }

    public static char? GetGradeScored(double gpa)
    {
        if (gpa < 5 || gpa > 10)
        {
            return null; 
        }else if (gpa==10)
        {
            return 'S';
        }else if (gpa>=9 && gpa<10)
        {
            return 'A';
        }else if (gpa>=8 && gpa<9)
        {
            return 'B';
        }else if (gpa>=7 && gpa<8)
        {
            return 'C';
        }else if (gpa>=6 && gpa<7)
        {
            return 'D';
        }else if (gpa>=5 && gpa<6)
        {
            return 'E';
        }
        return null;
         
      
        
    }
}
