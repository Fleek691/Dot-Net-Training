using StudentMVC.Models;

namespace StudentMVC.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<HttpResponseMessage> CreateStudentAsync(CreateStudentViewModel model);
        Task<HttpResponseMessage> UpdateStudentAsync(int id, EditStudentViewModel model);
        Task<HttpResponseMessage> DeleteStudentAsync(int id);
    }
}
