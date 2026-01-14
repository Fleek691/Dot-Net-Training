
using GenericsClass;
namespace MyConsoleApp
{
    public class CallerClass
    {
        public static void Main()
        {
            #region Generic
            // MyGlobalType<UGStudent> myGlobalType = new MyGlobalType<UGStudent>();
            // UGStudent obj = new ();
            // string result = myGlobalType.GetDataType(obj);
            // System.Console.WriteLine(result);
            #endregion
            
            #region Predicate and Acion and Func
            PredicateAndAction a=new PredicateAndAction();
            bool check =a.isEven(10);
            System.Console.WriteLine(check);
            a.logger("Application Started");
            Action<string> logger = PredicateAndAction.NewMethod();

            if (DateTime.Now.Hour < 12)
            {
                logger = PredicateAndAction.GoodMorning();
            }
            else
            {
                logger = PredicateAndAction.GoodDay();
            }

            logger("Application Started");

            // Change behavior again
            logger = PredicateAndAction.Method2();
            logger("Welcome Message");

            string resultText=a.multiplyResult(4,5);
            System.Console.WriteLine(resultText);
            #endregion
        }
    }
}