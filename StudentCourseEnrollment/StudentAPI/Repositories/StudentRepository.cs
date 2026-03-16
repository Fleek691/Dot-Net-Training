using StudentCourseEnrollment.Models;
using StudentCourseEnrollment.Data;
using Microsoft.EntityFrameworkCore;
namespace StudentCourseEnrollment.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Students student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return;
            }
            System.Console.WriteLine("Not Found");


        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Students?> GetStudentByIdAsync(int id)
        {

            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateStudentAsync(Students student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
