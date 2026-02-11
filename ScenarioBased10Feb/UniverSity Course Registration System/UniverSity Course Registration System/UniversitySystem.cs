using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string>? prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            if (AvailableCourses.ContainsKey(code)) throw new ArgumentException();
            Course course = new Course(code, name, credits, maxCapacity = 50, prerequisites) { };
            // 2. Create Course object
            // 3. Add to AvailableCourses
            AvailableCourses.Add(code, course);
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string>? completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            if (Students.ContainsKey(name)) throw new ArgumentException();
            // 2. Create Student object
            Student student = new Student(id, name, major, maxCredits = 18, completedCourses) { };
            // 3. Add to Students dictionary
            Students.Add(id, student);
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            if (!AvailableCourses.ContainsKey(courseCode) && !Students.ContainsKey(studentId)) return false;
            Students[studentId].AddCourse(AvailableCourses[courseCode]);
            // 2. Call student.AddCourse(course)
            System.Console.WriteLine("Registered Succesfully");
            // 3. Display meaningful messages
            return true;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            if (!Students.ContainsKey(studentId)) return false;
            Students[studentId].DropCourse(AvailableCourses[courseCode].ToString()!);
            // 2. Call student.DropCourse(courseCode)
            return true;
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            if (AvailableCourses.Count == 0)
            {
                System.Console.WriteLine("No Courses");
                return;
            }
            foreach (var course in AvailableCourses.Values)
            {
                System.Console.WriteLine($"{course.CourseCode}, {course.CourseName}, {course.Credits}, {course.GetEnrollmentInfo()}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            if (!Students.ContainsKey(studentId))
            {
                System.Console.WriteLine("Student doesnt exist");
                return;
            }
            Students[studentId].DisplaySchedule();
            // Call student.DisplaySchedule()

        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            // Count total course registrations across all students
            int totalRegistrations = Students.Values.Sum(s => s.RegisteredCourses.Count);

            // Calculate average: total registrations divided by number of courses
            double avgEnrollment = totalCourses > 0 ? (double)totalRegistrations / totalCourses : 0;

            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Total Courses: {totalCourses}");
            Console.WriteLine($"Average Enrollment per Course: {avgEnrollment:F2}");
        }
    }
}
