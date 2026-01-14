namespace Generics
{
    public class Student
    {
        
        public string? Name {get;set;}
    }
    public class UGStudent : Student
    {
        public int HighSchoolMarks {get;set;}
    }
    public class PGStudent : Student
    {
        public int UGMarks {get;set;}
    }
    public class MyGlobalType<T> where T : Student
    {
        public string GetDataType(T t)
        {
            
            return typeof(T).ToString();
        }
        public void Add(T t)
        {
            
        }
    }
    public class MyGlobalType2<T,K>
    {
        public K? MyProperty { get; set; }
        public void MyGlobalFunction(T t,K k)
        {
        
        }
    }
} 