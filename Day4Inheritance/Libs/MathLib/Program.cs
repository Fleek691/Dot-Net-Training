namespace MathLib;

public class Maths
{
    public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");

            return (double)a / b;
        }

        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public int Square(int number)
        {
            return number * number;
        }

}
