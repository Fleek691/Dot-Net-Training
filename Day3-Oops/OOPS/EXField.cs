using System;
namespace Fields
{
    public class Field
    {
        private int  id;//using get and set you can validate and make fields
        
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(value>0)
                {
                    System.Console.WriteLine("I am greater than Zero");
                    id=value;
                }
                else
                {
                    
                     id=0;
                     throw new InvalidOperationException("Id must be greater than 0");
                }
            }
        }
        public string DisplayEmpDetails()
        {
            return $"Employee Id is {id}";
        }
    }
}