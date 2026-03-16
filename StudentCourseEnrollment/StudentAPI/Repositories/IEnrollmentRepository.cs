using StudentCourseEnrollment.Models;
namespace StudentCourseEnrollment.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>>GetEnrollmentsAsync();
        Task<Enrollment?> GetEnrollmentByIdAsync(int id);
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task UpdateEnrollmentAsync(Enrollment enrollment);
        Task DeleteEnrollmentAsync(int id);
    }
}