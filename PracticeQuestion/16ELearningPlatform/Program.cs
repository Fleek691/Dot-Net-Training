using System;
using System.Collections.Generic;
using System.Linq;

namespace ELearningPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            LearningManager manager = new LearningManager();

            Console.WriteLine("=== E-Learning Platform ===\n");

            // Test Case 1: Create courses with modules
            Console.WriteLine("--- Creating Courses ---");
            manager.AddCourse("CS101", "Introduction to Programming", "Dr. John Smith", 12, 299.99,
                new List<string> { "Module1: Basics", "Module2: Control Structures", "Module3: Functions", "Module4: OOP" });
            manager.AddCourse("CS201", "Data Structures", "Dr. John Smith", 16, 399.99,
                new List<string> { "Module1: Arrays", "Module2: Linked Lists", "Module3: Trees", "Module4: Graphs" });
            manager.AddCourse("WEB101", "Web Development", "Prof. Jane Doe", 10, 249.99,
                new List<string> { "Module1: HTML", "Module2: CSS", "Module3: JavaScript" });
            manager.AddCourse("DB101", "Database Design", "Dr. Bob Wilson", 14, 349.99,
                new List<string> { "Module1: SQL Basics", "Module2: Normalization", "Module3: Indexing", "Module4: Transactions" });
            Console.WriteLine();

            // Test Case 2: Enroll students
            Console.WriteLine("--- Enrolling Students ---");
            manager.EnrollStudent("STU001", "CS101");
            manager.EnrollStudent("STU002", "CS101");
            manager.EnrollStudent("STU003", "CS101");
            manager.EnrollStudent("STU001", "WEB101");
            manager.EnrollStudent("STU004", "CS201");
            manager.EnrollStudent("STU002", "DB101");
            Console.WriteLine();

            // Test Case 3: Track learning progress
            Console.WriteLine("--- Tracking Progress ---");
            manager.UpdateProgress("STU001", "CS101", "Module1: Basics", 95);
            manager.UpdateProgress("STU001", "CS101", "Module2: Control Structures", 88);
            manager.UpdateProgress("STU001", "CS101", "Module3: Functions", 92);
            manager.UpdateProgress("STU001", "CS101", "Module4: OOP", 90);

            manager.UpdateProgress("STU002", "CS101", "Module1: Basics", 85);
            manager.UpdateProgress("STU002", "CS101", "Module2: Control Structures", 90);
            manager.UpdateProgress("STU002", "CS101", "Module3: Functions", 87);

            manager.UpdateProgress("STU003", "CS101", "Module1: Basics", 78);
            manager.UpdateProgress("STU003", "CS101", "Module2: Control Structures", 82);

            manager.UpdateProgress("STU001", "WEB101", "Module1: HTML", 96);
            manager.UpdateProgress("STU001", "WEB101", "Module2: CSS", 94);
            manager.UpdateProgress("STU001", "WEB101", "Module3: JavaScript", 92);
            Console.WriteLine();

            // Test Case 4: Group courses by instructor
            Console.WriteLine("--- Grouping Courses by Instructor ---");
            var groupedCourses = manager.GroupCoursesByInstructor();
            foreach (var group in groupedCourses)
            {
                Console.WriteLine($"\nInstructor: {group.Key}");
                foreach (var course in group.Value)
                {
                    Console.WriteLine($"  - {course.CourseName} ({course.CourseCode}) - {course.DurationWeeks} weeks - ${course.Price}");
                }
            }
            Console.WriteLine();

            // Test Case 5: Identify top performers
            Console.WriteLine("--- Top Performing Students in CS101 ---");
            var topStudents = manager.GetTopPerformingStudents("CS101", 3);
            for (int i = 0; i < topStudents.Count; i++)
            {
                var student = topStudents[i];
                Console.WriteLine($"{i + 1}. Student {student.StudentId} - Progress: {student.ProgressPercentage:F2}%");
            }
            Console.WriteLine();

            Console.WriteLine("--- Top Performing Students in WEB101 ---");
            var topWebStudents = manager.GetTopPerformingStudents("WEB101", 3);
            for (int i = 0; i < topWebStudents.Count; i++)
            {
                var student = topWebStudents[i];
                Console.WriteLine($"{i + 1}. Student {student.StudentId} - Progress: {student.ProgressPercentage:F2}%");
            }

            Console.WriteLine("\n=== End of E-Learning Platform Demo ===");
        }
    }
}
