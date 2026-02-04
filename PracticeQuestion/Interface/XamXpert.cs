public interface IExam
{
    public double CalculateScore();
    public static string evaluateResult(double percentage)
    {
        string result="";
        if(percentage>=85)result="Merit";
        else if(percentage>=60 && percentage<85)result="Pass";
        else result="Fail";
        return result;
    }
}
public class OnlineTest: IExam
{
    public string? studentName{get;set;}
    public int totalQuesttions{get;set;}
    public int correctAnswers{get;set;}
    public int wrongAnswers{get;set;}
    public string? questionType{get;set;}
    

    public double CalculateScore()
    {
        double marksForQues=0;
        
        if (questionType == "MCQ")
        {
            marksForQues=2;
        }
        if (questionType == "Coding")
        {
            marksForQues=5;
        };
        double totalmarks=(correctAnswers*marksForQues)-(wrongAnswers*(marksForQues*0.10));
        double percentage=(totalmarks/(totalQuesttions*marksForQues))*100;
        return percentage;
    }
}
public class UserInterface
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the following details: ");
        OnlineTest details=new OnlineTest();
        System.Console.WriteLine("Student Name");
        details.studentName=Console.ReadLine();
        System.Console.WriteLine("Question type (MCQ or Coding");
        details.questionType=Console.ReadLine();
        System.Console.WriteLine("Total number of questions");
        details.totalQuesttions=int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Number of correct answers");
        details.correctAnswers=int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Number of wrong answers");
        details.wrongAnswers=int.Parse(Console.ReadLine()!);
        var result=details.CalculateScore();
        var percentage=IExam.evaluateResult(result);
        System.Console.WriteLine(percentage);
        System.Console.WriteLine($"{details.questionType} Test: {details.studentName}, Total Score: {result}, Result: {percentage} ");
    }
}