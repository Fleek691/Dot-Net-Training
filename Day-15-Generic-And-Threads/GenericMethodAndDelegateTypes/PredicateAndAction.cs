namespace GenericsClass
{
    public  class PredicateAndAction
    {
        /// <summary>
        /// Predicate function
        /// </summary>
        public Predicate <int> isEven=number=>number%2==0;
        /// <summary>
        /// Action Delegate
        /// </summary>
        public Action<string> logger = message =>
        {
            Console.WriteLine($"[LOG]: {message} at{DateTime.Now}");
        };
        public static Action<string> NewMethod()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
            };
        }

        public static Action<string> GoodMorning()
        {
            return message =>
            {
                Console.WriteLine("Good Morning 🌅");
            };
        }

        public static Action<string> GoodDay()
        {
            return message =>
            {
                Console.WriteLine("Good Day ☀️");
            };
        }

        public static Action<string> Method2()
        {
            return message =>
            {
                Console.WriteLine("Welcome to Programming");
            };
        }
        /// <summary>
        /// Func Delegate
        /// </summary>
        public Func<int,int,string> multiplyResult = (x, y) =>
        {
            return $"{x} times {y} is {x*y}";
        };
        
    
    }
}













