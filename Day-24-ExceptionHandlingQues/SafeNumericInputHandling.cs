using System;

class InputHandler
{
    static void Main()
    {
        int number;
        bool valid = false;

        while (!valid)
        {
            try
            {
                Console.WriteLine("Enter a number:");
                number = int.Parse(Console.ReadLine()!);

                // If parsing succeeds
                Console.WriteLine("Valid number entered: " + number);
                valid = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too large or too small.");
            }
        }
    }
}
