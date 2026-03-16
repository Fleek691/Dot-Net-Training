using StudentsClassLib.Models;
using StudentApi.DTOs;
namespace StudentApi.Services
{
    public interface IStudentService
    {
        List<StudentDTO> GetAllStudentsAsync();
        Student GetStudentByIdAsync(int id);
        void AddStudentAsync(CreateStudentDto student);
        void UpdateStudentAsync(Student student);
        void DeleteStudentAsync(int id);
    }
}