public class Program
{
    public static void Main(string[] args){
        //WeekDays today = WeekDays.Wednesday;
        //Console.WriteLine("Today is: " + today);

        //int enumValue = (int)WeekDays.Friday;
        //ProductCategory category = ProductCategory.Electronics;
        //Console.WriteLine("Selected category: " + category + " with value " + (int)category);

        // int numValuePara = 0;
        // string variableForDay = GetWeekDay(WeekDays.Thursday, ref numValuePara);
        // Console.WriteLine(variableForDay);
        // Console.WriteLine(numValuePara);
        // System.Console.WriteLine(ProductCategory.Electronics);


        #region SubSem
        // Subject[,] SemSub=new Subject[3,6];
        // foreach(Semester sem in Enum.GetValues(typeof(Semester)))
        // {
        //     foreach(Subject sub in Enum.GetValues(typeof(Subject)))
        //     {
        //         SemSub[(int)sem,(int)sub]=sub;
        //     }
        // }

        // System.Console.WriteLine(SemSub[1,4]);
        #endregion

        #region Callback
        // OrderService order=new OrderService();
        // order.PlaceOrder("Order 1",SendEmail);
        // order.PlaceOrder("Order 1",SendSms);

        #endregion

        #region Exception
        try
        {
            int result=Divide(10,0);
            System.Console.WriteLine("Result: "+result);
        }
        catch(AppCustomeException ex)
        {
            System.Console.WriteLine("Error "+ex.Message);
        }

        // Demonstrating Exception Sequence
        Console.WriteLine("\nDemonstrating Exception Sequence:");
        ExceptionSequence.DemonstrateExceptionSequence();
        #endregion
    }



    private static int Divide(int a,int b)
    {
        try
        {
            return a/b;
        }
        catch
        {
            throw new AppCustomeException();
        }
    }
        
        
        }

        #region CalbbackMethods
        // static void SendEmail(string msg) => Console.WriteLine("EMAIL: " + msg);
        // static void SendSms(string msg) => Console.WriteLine("SMS:   " + msg);
        #endregion

        // public static string GetWeekDay(WeekDays weekDays, ref int  numValue)
        // {
        //      numValue = (int)weekDays;
        //     return weekDays.ToString();
        // }

        // public static String MenuByDay(WeekDays day)
        // {
        //     switch(day)
        //     {
        //         case WeekDays.Monday:
        //             return "Pasta";
        //         case WeekDays.Tuesday:
        //             return "Tacos";
        //         case WeekDays.Wednesday:
        //             return "Chicken Curry";
        //         case WeekDays.Thursday:
        //             return "Pizza";
        //         case WeekDays.Friday:
        //             return "Fish and Chips";
        //         case WeekDays.Staurday:
        //             return "Burgers";
        //         case WeekDays.Sunday:
        //             return "Roast Dinner";
        //         default:
        //             return "Unknown Day";
        //     }
        
    
