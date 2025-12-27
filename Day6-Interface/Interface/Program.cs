using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Hod hod = new Hod(1, "Dr. Sharma", "CSE");
        ExamSchedulerService service = new ExamSchedulerService(hod);

        // Semesters
        Semester sem5 = new Semester(5, "2024-25");
        Semester sem6 = new Semester(6, "2024-25");

        List<Semester> semesters = new List<Semester> { sem5, sem6 };

        // Subjects
        Dictionary<int, List<Subject>> subjectsBySem = new Dictionary<int, List<Subject>>
        {
            { 5, new List<Subject>
                {
                    new Subject(101, "OOPS"),
                    new Subject(102, "DBMS"),
                    new Subject(103, "CN")
                }
            },
            { 6, new List<Subject>
                {
                    new Subject(201, "OS"),
                    new Subject(202, "SE"),
                    new Subject(203, "AI")
                }
            }
        };

        // Examiners
        List<Examiner> examiners = new List<Examiner>
        {
            new Examiner(11, "Prof. Verma", "CSE", "OOPS"),
            new Examiner(12, "Prof. Mehta", "CSE", "DBMS"),
            new Examiner(13, "Prof. Rao", "CSE", "CN")
        };

        // Students input
        List<Student> students = new List<Student>();

        Console.Write("Enter number of students: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Semester (5 or 6): ");
            int semNo = int.Parse(Console.ReadLine());

            Semester sem = semNo == 5 ? sem5 : sem6;
            students.Add(new Student(id, name, sem));
        }

        Console.WriteLine("\n--- EXAM SCHEDULING ---\n");

        foreach (Semester sem in semesters)
        {
            Console.WriteLine($"Semester {sem.SemId}");

            foreach (Subject sub in subjectsBySem[sem.SemId])
            {
                Exam exam = service.ScheduleExam(sub, sem);

                Examiner examiner =
                    examiners.Find(e => e.Specialization == sub.SubName)
                    ?? examiners[0];

                ExamAssignment assignment =
                    service.AssignExaminer(exam, examiner);

                Console.WriteLine(
                    $"Subject: {sub.SubName} | Examiner: {assignment.Examiner.EmpName}"
                );
            }

            Console.WriteLine();
        }

        Console.WriteLine("--- STUDENT LIST ---");

        foreach (Student s in students)
        {
            Console.WriteLine($"{s.Name} → Semester {s.Semester.SemId}");
        }
    }
}
