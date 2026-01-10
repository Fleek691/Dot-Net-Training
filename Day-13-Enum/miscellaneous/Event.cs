public class EventExample
{
    public delegate void Notify();  // delegate
        public static event Notify Reached500; // event
        public static void Main()
        {
            Reached500 += ValueReached500Plus;

            while (true)
            {
                Console.WriteLine("Enter a number (or 'exit' to quit): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;
                try
                {
                    Console.WriteLine("Enter value a Value ");
                    var num = int.Parse(Console.ReadLine());
                    if (num > 500)
                    {
                        Reached500();
                    }
                    num = 0;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                
                   
                
            }
        }

        private static void ValueReached500Plus()
        {
            Console.WriteLine("Yes Reached 500 or 500 plus please note");
        }
}