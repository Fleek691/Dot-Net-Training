using System;
namespace Add
{
    public class Addition
    {
        public int FirstNumber{get; set;}
        public int SecondNumber{get;set;}
        public int Sum{get;}

        private Addition()
        {
            
        }
        public Addition(int a,int b)
        {
            this.FirstNumber=a;
            this.SecondNumber=b;
            Sum=this.FirstNumber+this.SecondNumber;//get property can set values inside the constructer(only in constructor)
        }

    }
}