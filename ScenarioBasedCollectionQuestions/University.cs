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

    // TODO: Enroll student with constraints
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        // Rules:
        // - Course not at capacity
        // - Student not already enrolled
        // - Student semester >= course prerequisite (if any)
        // - Return success/failure with reason

        // Initialize course if not exists
        if (!_enrollments.ContainsKey(course))
        {
            _enrollments[course] = new List<TStudent>();
        }

        // Rule 1: Course not at capacity
        if (_enrollments[course].Count >= course.MaxCapacity)
        {
            Console.WriteLine($"Cannot enroll: {course.Title} is at full capacity ({course.MaxCapacity} students)");
            return false;
        }

        // Rule 2: Student not already enrolled
        if (_enrollments[course].Contains(student))
        {
            Console.WriteLine($"Cannot enroll: {student.Name} is already enrolled in {course.Title}");
            return false;
        }

        // Rule 3: Student semester >= course prerequisite
        if (course is LabCourse labCourse)
        {
            if (student.Semester < labCourse.RequiredSemester)
            {
                Console.WriteLine($"Cannot enroll: {student.Name} is in semester {student.Semester}, but {course.Title} requires semester {labCourse.RequiredSemester}");
                return false;
            }
        }

        // All checks passed - enroll student
        _enrollments[course].Add(student);
        Console.WriteLine($"Success: {student.Name} enrolled in {course.Title}");
        return true;
    }

    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        return _enrollments
            .Where(e => e.Key.CourseCode == course.CourseCode)
            .SelectMany(e => e.Value)
            .ToList()
            .AsReadOnly();
    }

    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Contains(student))
            .Select(e => e.Key);
    }

    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        // Sum credits of all enrolled courses
        return _enrollments
            .Where(e => e.Value.Contains(student))
            .Sum(e => e.Key.Credits);
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public int Semester { get; set; }
    public string ?Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string? CourseCode { get; set; }
    public string? Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string? LabEquipment { get; set; }
    public int RequiredSemester { get; set; } // Prerequisite
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();

    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        // Grade must be between 0 and 100
        if (grade < 0 || grade > 100)
        {
            System.Console.WriteLine("Grade must be between 0 and 100");
            return;
        }
        // Student must be enrolled in course
        _grades[(student, course)] = grade;
    }

    // TODO: Calculate GPA for student
    public double? CalculateGPA(TStudent student)
    {
        // Weighted by course credits
        // Return null if no grades
        var studentGrades = _grades.Where(g => g.Key.Item1!.Equals(student)).ToList();

        if (studentGrades.Count == 0)
        {
            return null;
        }

        return studentGrades.Average(g => g.Value);
    }

    // TODO: Find top student in course
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        // Return student with highest grade

        // Return student with highest grade
        var course1s = _grades.Where(e => e.Key.Item2!.Equals(course)).ToList();
        if (course1s.Count == 0)
        {
            System.Console.WriteLine("no courses");
            return null;
        }
        var top = course1s.MaxBy(e => e.Value);
        return (top.Key.Item1, top.Value);
    }
}

// 4. TEST SCENARIO: Create a simulation
public class Program2
{
    public static void Main()
    {
        Console.WriteLine("=== University Enrollment System ===\n");

        // a) Create 3 EngineeringStudent instances
        var student1 = new EngineeringStudent { StudentId = 101, Name = "Alice", Semester = 3, Specialization = "CSE" };
        var student2 = new EngineeringStudent { StudentId = 102, Name = "Bob", Semester = 2, Specialization = "CSE" };
        var student3 = new EngineeringStudent { StudentId = 103, Name = "Charlie", Semester = 4, Specialization = "ECE" };

        // b) Create 2 LabCourse instances with prerequisites
        var course1 = new LabCourse
        {
            CourseCode = "CS301",
            Title = "Data Structures Lab",
            MaxCapacity = 2,
            Credits = 4,
            LabEquipment = "Computers",
            RequiredSemester = 2
        };

        var course2 = new LabCourse
        {
            CourseCode = "CS401",
            Title = "Advanced Algorithms Lab",
            MaxCapacity = 3,
            Credits = 4,
            LabEquipment = "High-end Workstations",
            RequiredSemester = 3
        };

        // c) Demonstrate enrollment system
        Console.WriteLine("--- Enrollment Tests ---");
        var enrollmentSystem = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        // Successful enrollment
        enrollmentSystem.EnrollStudent(student1, course1);
        enrollmentSystem.EnrollStudent(student3, course2);

        // Failed enrollment - capacity
        enrollmentSystem.EnrollStudent(student2, course1);
        enrollmentSystem.EnrollStudent(student1, course1); // Already enrolled
        Console.WriteLine();

        // Failed enrollment - prerequisite
        enrollmentSystem.EnrollStudent(student2, course2); // Bob is semester 2, needs 3
        Console.WriteLine();

        // Successful prerequisite
        enrollmentSystem.EnrollStudent(student2, course1); // Bob enrolls in CS301
        Console.WriteLine();

        // Get enrolled students
        Console.WriteLine("--- Enrolled Students ---");
        var cs301Students = enrollmentSystem.GetEnrolledStudents(course1);
        Console.WriteLine($"Students in {course1.Title}: {string.Join(", ", cs301Students.Select(s => s.Name))}");
        Console.WriteLine();

        // Get student courses
        Console.WriteLine("--- Student Courses ---");
        var alice_Courses = enrollmentSystem.GetStudentCourses(student1);
        Console.WriteLine($"Courses for Alice: {string.Join(", ", alice_Courses.Select(c => c.Title))}");
        Console.WriteLine();

        // Student workload
        Console.WriteLine("--- Student Workload ---");
        var aliceWorkload = enrollmentSystem.CalculateStudentWorkload(student1);
        Console.WriteLine($"Alice's total credits: {aliceWorkload}");
        var charlieWorkload = enrollmentSystem.CalculateStudentWorkload(student3);
        Console.WriteLine($"Charlie's total credits: {charlieWorkload}");
        Console.WriteLine();

        // Demonstrate GradeBook
        Console.WriteLine("--- Grade Assignment ---");
        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>();

        gradeBook.AddGrade(student1, course1, 85);
        gradeBook.AddGrade(student2, course1, 90);
        gradeBook.AddGrade(student3, course2, 88);
        Console.WriteLine("Grades added successfully");
        Console.WriteLine();

        // GPA Calculation
        Console.WriteLine("--- GPA Calculation ---");
        var aliceGPA = gradeBook.CalculateGPA(student1);
        Console.WriteLine($"Alice's GPA: {aliceGPA:F2}");
        var bobGPA = gradeBook.CalculateGPA(student2);
        Console.WriteLine($"Bob's GPA: {bobGPA:F2}");
        var charlieGPA = gradeBook.CalculateGPA(student3);
        Console.WriteLine($"Charlie's GPA: {charlieGPA:F2}");
        Console.WriteLine();

        // Top student per course
        Console.WriteLine("--- Top Student Per Course ---");
        var topInCS301 = gradeBook.GetTopStudent(course1);
        if (topInCS301.HasValue)
        {
            Console.WriteLine($"Top student in {course1.Title}: {topInCS301.Value.student.Name} with grade {topInCS301.Value.grade}");
        }

        var topInCS401 = gradeBook.GetTopStudent(course2);
        if (topInCS401.HasValue)
        {
            Console.WriteLine($"Top student in {course2.Title}: {topInCS401.Value.student.Name} with grade {topInCS401.Value.grade}");
        }
    }
}
