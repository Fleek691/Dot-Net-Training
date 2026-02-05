using System;
using System.Collections.Generic;
using System.Linq;

namespace ELearningPlatform
{
    public class LearningManager
    {
        private List<Course> courses = new List<Course>();
        private List<Enrollment> enrollments = new List<Enrollment>();
        private List<StudentProgress> progressRecords = new List<StudentProgress>();
        private int nextEnrollmentId = 1;

        public void AddCourse(string code, string name, string instructor, int weeks, double price, List<string> modules)
        {
            var course = new Course
            {
                CourseCode = code,
                CourseName = name,
                Instructor = instructor,
                DurationWeeks = weeks,
                Price = price,
                Modules = modules
            };
            courses.Add(course);
            Console.WriteLine($"Course '{name}' added successfully with code: {code}");
        }

        public bool EnrollStudent(string studentId, string courseCode)
        {
            var course = courses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return false;
            }

            if (enrollments.Any(e => e.StudentId == studentId && e.CourseCode == courseCode))
            {
                Console.WriteLine("Student already enrolled in this course!");
                return false;
            }

            var enrollment = new Enrollment
            {
                EnrollmentId = nextEnrollmentId++,
                StudentId = studentId,
                CourseCode = courseCode,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0
            };

            enrollments.Add(enrollment);

            var progress = new StudentProgress
            {
                StudentId = studentId,
                CourseCode = courseCode,
                ModuleScores = new Dictionary<string, double>(),
                LastAccessed = DateTime.Now
            };
            progressRecords.Add(progress);

            Console.WriteLine($"Student {studentId} enrolled in course {courseCode}");
            return true;
        }

        public bool UpdateProgress(string studentId, string courseCode, string module, double score)
        {
            var progress = progressRecords.FirstOrDefault(p => p.StudentId == studentId && p.CourseCode == courseCode);
            if (progress == null)
            {
                Console.WriteLine("Enrollment not found!");
                return false;
            }

            progress.ModuleScores[module] = score;
            progress.LastAccessed = DateTime.Now;

            var course = courses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course != null)
            {
                double progressPercentage = (progress.ModuleScores.Count / (double)course.Modules.Count) * 100;
                var enrollment = enrollments.FirstOrDefault(e => e.StudentId == studentId && e.CourseCode == courseCode);
                if (enrollment != null)
                {
                    enrollment.ProgressPercentage = progressPercentage;
                }
            }

            Console.WriteLine($"Progress updated for student {studentId} in module {module}: {score}%");
            return true;
        }

        public Dictionary<string, List<Course>> GroupCoursesByInstructor()
        {
            return courses.GroupBy(c => c.Instructor)
                         .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
        {
            return enrollments.Where(e => e.CourseCode == courseCode)
                             .OrderByDescending(e => e.ProgressPercentage)
                             .Take(count)
                             .ToList();
        }

        public List<Course> GetAllCourses()
        {
            return courses;
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return enrollments;
        }

        public List<StudentProgress> GetAllProgress()
        {
            return progressRecords;
        }
    }
}
