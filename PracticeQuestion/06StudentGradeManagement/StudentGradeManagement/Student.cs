public class Student
{
    public int StudentId{get;set;}
    public string Name{get;set;}
    public string GradeLevel{get;set;}
    public Dictionary<string,double>Subjects{get;set;}
    public Student(int id,string name,string grade){
        StudentId=id;
        Name=name;
        GradeLevel=grade;
        Subjects=new Dictionary<string, double>();
    }
}