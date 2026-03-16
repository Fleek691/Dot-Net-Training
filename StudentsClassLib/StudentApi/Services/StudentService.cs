using StudentApi.Repositories;
using StudentApi.Services;
using StudentApi.DTOs;
using StudentsClassLib.Models;

namespace StudentSClassLib.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public List<StudentDTO> GetAllStudentsAsync()
        {
            var students=_repository.GetAllStudentsAsync();
            var result=students.Select(s=>new StudentDTO
            {
                StudentId=s.StudentId,
                FullName=s.FullName,
                Status=s.Status
            }).ToList();
            return result;
        }

        public Student GetStudentByIdAsync(int id)
        {
            return  _repository.GetStudentByIdAsync(id);
        }

        public void AddStudentAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Status = "Active",
                JoinDate = DateOnly.FromDateTime(DateTime.Now),
                CreatedAt = DateTime.Now
            };
            _repository.AddStudentAsync(student);
        }

        public void UpdateStudentAsync(Student student)
        {
             _repository.UpdateStudentAsync(student);
        }

        public void DeleteStudentAsync(int id)
        {
             _repository.DeleteStudentAsync(id);
        }
    }
}