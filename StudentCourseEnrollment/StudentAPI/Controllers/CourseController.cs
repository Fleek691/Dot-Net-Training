using Microsoft.AspNetCore.Mvc;
using StudentCourseEnrollment.Models;
using StudentCourseEnrollment.DTOs;
using StudentCourseEnrollment.Repositories;
namespace StudentCourseEnrollment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetCOurseByIdAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto createCourseDTO)
        {
            var newCourse = new Courses
            {
                Name = createCourseDTO.Name,
                Duration = 12, // Assuming Duration is a DateTime, adjust as needed
                Credits = createCourseDTO.Credits
            };
            await _courseRepository.AddCourseAsync(newCourse);
            return Ok(newCourse);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseDto courseDTO)
        {
            var existingCourse = await _courseRepository.GetCOurseByIdAsync(courseDTO.Id);
            if (existingCourse == null)
                return NotFound();
            existingCourse.Name = courseDTO.Name;
            existingCourse.Credits = courseDTO.Credits;
            await _courseRepository.UpdateCourseAsync(existingCourse);
            return Ok(existingCourse);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var existingCourse = await _courseRepository.GetCOurseByIdAsync(id);
            if (existingCourse == null)
                return NotFound();

            await _courseRepository.DeleteCourseAsync(existingCourse.Id);
            return NoContent();
        }
    }
}