public class StudentManager
{
    // In class SchoolManager:
    private SortedDictionary<int, Student> studentsList = new SortedDictionary<int, Student>();
    private int id = 1;
    public void AddStudent(string name, string gradeLevel)
    {
        studentsList.Add(id, new Student(id, name, gradeLevel));
        id++;
    }
    // Auto-generate StudentId

    public void AddGrade(int studentId, string subject, double grade)
    {
        studentsList[studentId].Subjects[subject] = grade;
    }
    // Adds grade for student (0-100 scale)

    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        var result = studentsList.Values.GroupBy(e => e.GradeLevel).ToDictionary(g => g.Key, g => g.ToList());
        return new SortedDictionary<string, List<Student>>(result);
    }
    // Groups students by grade level

    public double CalculateStudentAverage(int studentId)
    {
        return studentsList[studentId].Subjects.Values.Average();
    }
    // Returns student's average grade

    public Dictionary<string, double> CalculateSubjectAverages()
    {
        var res = studentsList.Values
            .SelectMany(s => s.Subjects)
            .GroupBy(s => s.Key)
            .ToDictionary(g => g.Key, g => g.Average(s => s.Value));
        return res;
    }
    // Returns average grade per subject across all students

    public List<Student> GetTopPerformers(int count)
    {
        return studentsList.Values
            .OrderByDescending(s => s.Subjects.Values.DefaultIfEmpty(0).Average())
            .Take(count)
            .ToList();
    }
    // Returns top N students by average grade

}