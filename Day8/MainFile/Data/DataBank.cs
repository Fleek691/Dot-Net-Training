using System.Collections.Generic;
using System.Data.Common;
using StudentSessionApp.Model;

namespace StudentSessionApp.Data;

public class DataBank
{
    public static List<Student> Students = new List<Student>();
    public static List<StudentSession> StudentSessions = new List<StudentSession>();

    public static List<StudentsandSession> StudentandSession=new List<StudentsandSession>();


    static DataBank()
    {
        Students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice" },
            new Student { Id = 2, Name = "Bob" },
            new Student { Id = 3, Name = "Charlie" }
        };
        StudentSessions=new List<StudentSession>{
            new StudentSession{Id=1,Name="Session 1"},
            new StudentSession{Id=2,Name="Session 2"},
            new StudentSession{Id=3,Name="Session 3"}
        };

        
    }

    public static List<Student> GetStudents()
    {
        return Students;
    }

    
    public static List<StudentSession> GetStudentSessions(){
            return StudentSessions;
        }
}
