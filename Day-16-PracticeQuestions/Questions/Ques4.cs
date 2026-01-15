

using System.Collections;

public class MeditationCentre
{
    public int MemberId{get;set;}
    public int Age{get;set;}
    public double Weight{get;set;}
    public double Height{get;set;}
    public string Goal{get;set;}
    public double BMI{get;set;}
}
public class Ques4
{
    public static ArrayList memberList=new ArrayList();
    public static void Main(string[] args)
    {
       

    // Hard-coded members (only 2 as you asked)
    AddYogaMember(1, 25, 70, 1.70, "weight loss");
    AddYogaMember(2, 30, 60, 1.65, "weight gain");

    Console.Write("Enter Member Id: ");
    int memberId = int.Parse(Console.ReadLine());

    double bmi = CalculateBMI(memberId);

    if (bmi == 0)
    {
        Console.WriteLine($"MemberId {memberId} is not present");
        return;
    }

    Console.WriteLine("BMI: " + bmi);

    int fee =CalculateYogaFee(memberId);

    if (fee == -1)
        Console.WriteLine($"MemberId {memberId} is not present");
    else
        Console.WriteLine("Yoga Fee: " + fee);
    }
    public static void AddYogaMember(int memberId,int age,double weight,double height,string goal)
    {
        memberList.Add(new MeditationCentre
        {
           MemberId=memberId,Age=age,Weight=weight,Height=height,Goal=goal 
        });
    }
    public static double CalculateBMI(int memberId)
    {
        foreach(var item in memberList)
        {
            MeditationCentre member=(MeditationCentre)item;
            if (member.MemberId == memberId)
            {
                double bmi=member.Weight/(member.Height*member.Height);
                bmi=Math.Floor(bmi*100)/100;
                member.BMI=bmi;
                return member.BMI;
            }
        }
        return 0;
    }

    public static int CalculateYogaFee(int memberId)
    {
        int res=0;
        foreach(var item in memberList)
        {
            
            MeditationCentre member=(MeditationCentre)item;
            if (member.MemberId == memberId)
            {
                if (member.BMI == 0)
            {
                double bmi = member.Weight / (member.Height * member.Height);
                member.BMI = Math.Floor(bmi * 100) / 100;   // 2 decimal places
            }
                if(member.Goal.Trim().ToLower()=="weight gain")
                {
                    res=2500;
                    return res;
                }
                else
                {
                    if(member.Goal.ToLower()=="weight loss" && member.BMI>=25 && member.BMI < 30)
                    {
                        return res= 2000;
                    }
                    else if (member.Goal.ToLower()=="weight loss" && member.BMI>=30 && member.BMI < 35)
                    {
                        return res= 2500;
                    }else if(member.Goal.ToLower()=="weight loss" && member.BMI >= 35)
                    {
                        return res=3000;
                    }
                }
            }
        }
        return res=-1;
    }
}