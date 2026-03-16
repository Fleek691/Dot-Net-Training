using StudentCourseEnrollment.Models;
namespace StudentCourseEnrollment.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Students student);
        Task UpdateStudentAsync(Students student);
        Task DeleteStudentAsync(int id);
    }
}