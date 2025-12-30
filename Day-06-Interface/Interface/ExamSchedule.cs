using System;
using System.Collections.Generic;

// ================= BASE CLASSES =================

public abstract class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public string DeptName { get; set; }

    protected Employee(int empId, string empName, string deptName)
    {
        EmpId = empId;
        EmpName = empName;
        DeptName = deptName;
    }
}

public abstract class Staff : Employee
{
    protected Staff(int id, string name, string dept)
        : base(id, name, dept) { }
}

// ================= ENTITIES =================

public class Hod : Staff
{
    public Hod(int id, string name, string dept)
        : base(id, name, dept) { }
}

public class Examiner : Staff
{
    public string Specialization;

    public Examiner(int id, string name, string dept, string specialization)
        : base(id, name, dept)
    {
        Specialization = specialization;
    }
}

public class Student
{
    public int StudentId;
    public string Name;
    public Semester Semester;

    public Student(int id, string name, Semester semester)
    {
        StudentId = id;
        Name = name;
        Semester = semester;
    }
}

public class Semester
{
    public int SemId;
    public string Year;

    public Semester(int semId, string year)
    {
        SemId = semId;
        Year = year;
    }
}

public class Subject
{
    public int SubId;
    public string SubName;

    public Subject(int id, string name)
    {
        SubId = id;
        SubName = name;
    }
}

public class Exam
{
    public Subject Subject;
    public Semester Semester;

    public Exam(Subject subject, Semester semester)
    {
        Subject = subject;
        Semester = semester;
    }
}

public class ExamAssignment
{
    public Exam Exam;
    public Examiner Examiner;
    public Hod AssignedBy;

    public ExamAssignment(Exam exam, Examiner examiner, Hod hod)
    {
        Exam = exam;
        Examiner = examiner;
        AssignedBy = hod;
    }
}

// ================= INTERFACES =================

public interface IExamScheduler
{
    Exam ScheduleExam(Subject subject, Semester semester);
}

public interface IExamAssigner
{
    ExamAssignment AssignExaminer(Exam exam, Examiner examiner);
}

// ================= BUSINESS LOGIC =================

public class ExamSchedulerService : IExamScheduler, IExamAssigner
{
    private Hod _hod;

    public ExamSchedulerService(Hod hod)
    {
        _hod = hod;
    }

    public Exam ScheduleExam(Subject subject, Semester semester)
    {
        return new Exam(subject, semester);
    }

    public ExamAssignment AssignExaminer(Exam exam, Examiner examiner)
    {
        return new ExamAssignment(exam, examiner, _hod);
    }
}
