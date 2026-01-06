
    public delegate int DelegateAddFunctionName  (int a, int b);
    public class ExampleOfDelegate
    {
        public int a;
        public int b;

        public void DelegateEx1()
        {
            DelegateAddFunctionName delegateVarable = new DelegateAddFunctionName(AddMethod3);
            System.Console.WriteLine(delegateVarable(1, 2));
        }

        private int AddMethod3(int a, int b)
        {
            return a + b +40;
        }


        private int AddMethod2(int a, int b)
        {
            return a + b + 10;
        }
    }
