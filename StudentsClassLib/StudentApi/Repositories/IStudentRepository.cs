using StudentsClassLib.Models;

namespace StudentApi.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudentsAsync();
        Student GetStudentByIdAsync(int id);
        void AddStudentAsync(Student student);
        void UpdateStudentAsync(Student student);
        void DeleteStudentAsync(int id);
    }
}
