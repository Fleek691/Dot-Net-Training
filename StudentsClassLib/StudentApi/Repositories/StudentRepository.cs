using Microsoft.EntityFrameworkCore;
using StudentsClassLib.Models;

namespace StudentApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _context;
        public StudentRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        public void AddStudentAsync(Student student)
        {
            if (student == null || _context.Students.Contains(student))
            {
                Console.WriteLine("Invalid");
                return;
            }
            _context.Students.Add(student);
            _context.SaveChanges();  
        }

        public void DeleteStudentAsync(int id)
        {
                var student = _context.Students.FirstOrDefault(b => b.StudentId == id);
                if(student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
        }

        public List<Student> GetAllStudentsAsync()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentByIdAsync(int id)
        {
            return _context.Students.FirstOrDefault(b=>b.StudentId==id);
        }

        public void UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
        }
    }
}
