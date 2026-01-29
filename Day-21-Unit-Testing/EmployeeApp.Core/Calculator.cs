namespace EmployeeApp.Core
{
    public class Calculator
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
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return (double)a / b;
        }

        public int Modulus(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot perform modulus with zero");
            }
            return a % b;
        }
    }
}
