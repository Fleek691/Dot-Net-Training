using GenericsClass;

namespace GenericsClass
{
    public  class PreActFun
    {
        
        public Predicate <int> isEven=number=>number%2==0;
        
        public Action<string> logger = message =>
        {
            Console.WriteLine($"[LOG]: {message} at{DateTime.Now}");
        };
        public static Action<string> NewMethod()
        {
            return message =>
            {
                Console.WriteLine($"{message} at {DateTime.Now}");
            };
        }

        public static Action<string> GoodMorning()
        {
            return message =>
            {
                Console.WriteLine("Good Morning ");
            };
        }

        public static Action<string> GoodDay()
        {
            return message =>
            {
                Console.WriteLine("Good Day ");
            };
        }

        public static Action<string> Method2()
        {
            return message =>
            {
                Console.WriteLine("Welcome to Programming");
            };
        }
        
        public Func<int,int,string> multiplyResult = (x, y) =>
        {
            return $"{x} times {y} is {x*y}";
        };
        
    
    }
}


public class Usage
    {
        public static void Main()
        {
            
            
            
            PreActFun a=new PreActFun();
            bool check =a.isEven(10);
            System.Console.WriteLine(check);
            a.logger("Application Started");
            Action<string> logger = PreActFun.NewMethod();

            if (DateTime.Now.Hour < 12)
            {
                logger = PreActFun.GoodMorning();
            }
            else
            {
                logger = PreActFun.GoodDay();
            }

            logger("Application Started");

            // Change behavior again
            logger = PreActFun.Method2();
            logger("Welcome Message");

            string resultText=a.multiplyResult(4,5);
            System.Console.WriteLine(resultText);
        }
    }













