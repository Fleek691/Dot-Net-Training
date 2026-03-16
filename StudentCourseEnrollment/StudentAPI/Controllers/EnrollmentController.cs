using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.DTOs;
using StudentCourseEnrollment.Models;
using StudentCourseEnrollment.Repositories;
namespace StudentCourseEnrollment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var enrollments = await _enrollmentRepository.GetEnrollmentsAsync();
            var dtos = enrollments.Select(e => new EnrollmentDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                EnrollmentDate = e.EnrollmentDate
            });
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
                return NotFound();
            var dto = new EnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = enrollment.EnrollmentDate
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            var student = await _studentRepository.GetStudentByIdAsync(createEnrollmentDto.StudentId);
            if (student == null)
                return BadRequest("Student not found.");

            var course = await _courseRepository.GetCOurseByIdAsync(createEnrollmentDto.CourseId);
            if (course == null)
                return BadRequest("Course not found.");

            var enrollment = new Enrollment
            {
                StudentId = createEnrollmentDto.StudentId,
                CourseId = createEnrollmentDto.CourseId,
                EnrollmentDate = DateTime.UtcNow
            };

            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
            var dto = new EnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrollmentDate = enrollment.EnrollmentDate
            };
            return CreatedAtAction(nameof(GetEnrollmentById), new { id = enrollment.Id }, dto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var existingEnrollment = await _enrollmentRepository.GetEnrollmentByIdAsync(id);
            if (existingEnrollment == null)
                return NotFound();
            await _enrollmentRepository.DeleteEnrollmentAsync(id);
            return NoContent();
        }

    }
}