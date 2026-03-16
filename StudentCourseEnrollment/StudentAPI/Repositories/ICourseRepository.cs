using StudentCourseEnrollment.Models;
namespace StudentCourseEnrollment.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Courses>> GetAllCoursesAsync();
        Task<Courses?>GetCOurseByIdAsync(int id);
        Task AddCourseAsync(Courses course);
        Task UpdateCourseAsync(Courses course);
        Task DeleteCourseAsync(int id);
        
    }
}