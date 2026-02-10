using System;
using System.Collections.Generic;
using System.Linq;

public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        var students = _enrollments[course];

        if (students.Count >= course.MaxCapacity)
            return false;

        if (students.Contains(student))
            return false;

        var requiredSemesterProp = course.GetType().GetProperty("RequiredSemester");
        if (requiredSemesterProp != null)
        {
            int requiredSemester = (int)requiredSemesterProp.GetValue(course)!;
            if (student.Semester < requiredSemester)
                return false;
        }

        students.Add(student);
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.ContainsKey(course))
            return _enrollments[course].AsReadOnly();

        return new List<TStudent>().AsReadOnly();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(x => x.Value.Contains(student))
            .Select(x => x.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student).Sum(c => c.Credits);
    }

    public bool IsStudentEnrolled(TStudent student, TCourse course)
    {
        return _enrollments.ContainsKey(course) &&
               _enrollments[course].Contains(student);
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public int Semester { get; set; }
    public string? Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string? CourseCode { get; set; }
    public string? Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string? LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollment;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
    {
        _enrollment = enrollment;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException();

        if (!_enrollment.IsStudentEnrolled(student, course))
            throw new Exception();

        _grades[(student, course)] = grade;
    }

    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(x => x.Key.Item1.Equals(student))
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalWeighted = 0;
        int totalCredits = 0;

        foreach (var entry in studentGrades)
        {
            var course = entry.Key.Item2;
            totalWeighted += entry.Value * course.Credits;
            totalCredits += course.Credits;
        }

        return totalWeighted / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(x => x.Key.Item2.Equals(course))
            .ToList();

        if (!courseGrades.Any())
            return null;

        var top = courseGrades.OrderByDescending(x => x.Value).First();
        return (top.Key.Item1, top.Value);
    }
}

// 4. TEST SCENARIO
class Program2
{
    static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        var s1 = new EngineeringStudent { StudentId = 1, Name = "A", Semester = 5, Specialization = "AI" };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "B", Semester = 3, Specialization = "Core" };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "C", Semester = 6, Specialization = "Data" };

        var c1 = new LabCourse
        {
            CourseCode = "LAB101",
            Title = "Robotics Lab",
            MaxCapacity = 2,
            Credits = 4,
            LabEquipment = "Arm",
            RequiredSemester = 4
        };

        var c2 = new LabCourse
        {
            CourseCode = "LAB202",
            Title = "AI Lab",
            MaxCapacity = 2,
            Credits = 5,
            LabEquipment = "GPU",
            RequiredSemester = 5
        };

        enrollment.EnrollStudent(s1, c1);
        enrollment.EnrollStudent(s2, c1);
        enrollment.EnrollStudent(s3, c1);
        enrollment.EnrollStudent(s1, c2);

        gradebook.AddGrade(s1, c1, 85);
        gradebook.AddGrade(s3, c1, 92);
        gradebook.AddGrade(s1, c2, 88);

        Console.WriteLine(gradebook.CalculateGPA(s1));
        Console.WriteLine(gradebook.CalculateGPA(s3));

        var top = gradebook.GetTopStudent(c1);
        if (top != null)
            Console.WriteLine($"{top.Value.student.Name} {top.Value.grade}");
    }
}
