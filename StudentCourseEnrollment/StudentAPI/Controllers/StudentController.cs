using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.Models;
using StudentCourseEnrollment.DTOs;
using StudentCourseEnrollment.Repositories;
namespace StudentCourseEnrollment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO createStudentDTO)
        {
            var newStudent = new Students
            {
                Name = createStudentDTO.Name,
                Email = createStudentDTO.Email,
                Phone = createStudentDTO.Phone,
                EnrollmentDate = DateTime.UtcNow
            };
            await _studentRepository.AddStudentAsync(newStudent);
            return Ok(newStudent);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentDTO studentDTO)
        {
            var existingStudent = await _studentRepository.GetStudentByIdAsync(studentDTO.Id);
            if (existingStudent == null)
                return NotFound();
            existingStudent.Name = studentDTO.Name;
            existingStudent.Email = studentDTO.Email;
            existingStudent.Phone = studentDTO.Phone;
            await _studentRepository.UpdateStudentAsync(existingStudent);
            return Ok(existingStudent);
        }   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existingStudent = await _studentRepository.GetStudentByIdAsync(id);
            if (existingStudent == null)
                return NotFound();
            await _studentRepository.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}