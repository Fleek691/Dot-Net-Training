// In class FitnessClass:
// - string ClassName
// - string Instructor
// - DateTime Schedule
// - int MaxParticipants
// - List<string> RegisteredMembers
public class FitnessClass
{
    public string ClassName{get;set;}
    public string Instructor{get;set;}
    public DateTime Schedule{get;set;}
    public int MaxParticipants{get;set;}
    public List<string> RegisteredMembers{get;set;}
    public FitnessClass(string className,string instructor,DateTime schedule,int maxParticipants)
    {
        ClassName=className;
        Instructor=instructor;
        Schedule=schedule;
        MaxParticipants=maxParticipants;
        RegisteredMembers=new List<string>();
    }
}