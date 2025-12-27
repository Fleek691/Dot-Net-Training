using System;

namespace ABC
{
    public class Visi
    {
        public int Id { get; set; }//8 byte using int64  
        public string Name { get; set; }//16 byte
        public string Requirement { get; set; }//16 byte
        public string LogHisory{get;set;}

        // Default constructor
        public Visi()
        {
            LogHisory+=$"Object created on{DateTime.Now.ToString()}   {Environment.NewLine}";
            
        }

        public Visi(int id) :this()
        {
            Id = id;
            LogHisory+=$"ID created on{DateTime.Now.ToString()}   {Environment.NewLine}";
        }

        public Visi(int id, string name):this(id)
        {
            // Id = id;
            if(name.ToLower().Contains("idiot"))
                throw new ArgumentException("You Idiot, Dont type like this");
            LogHisory+=$"Name created on{DateTime.Now.ToString()}   {Environment.NewLine}";

            Name = name;
        }

        public Visi(int id, string name, string requirement):this(id,name)
        {
            //No need for these as it gets initialized further as the previous constructor gets called and gets initialized
            // Id = id;
            // Name = name;
            LogHisory+=$"Requirement created on{DateTime.Now.ToString()}   {Environment.NewLine}";
            Requirement = requirement;
        }
    }
}
