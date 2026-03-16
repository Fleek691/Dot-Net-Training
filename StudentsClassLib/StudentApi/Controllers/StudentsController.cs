using Microsoft.AspNetCore.Mvc;
using StudentApi.DTOs;
using StudentApi.Services;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentsController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = _service.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = _service.GetStudentByIdAsync(id);
        if (student == null)
            return NotFound(new { message = "Student not found" });

        var dto = new StudentDTO
        {
            StudentId = student.StudentId,
            FullName = student.FullName,
            Status = student.Status,
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
    {
        try
        {
            _service.AddStudentAsync(dto);
            return Ok(new { message = "Student created successfully" });
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UX_Students_Email") == true)
        {
            return BadRequest(new { message = $"A student with email '{dto.Email}' already exists." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the student.", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto dto)
    {
        try
        {
            var existingStudent = _service.GetStudentByIdAsync(id);
            if (existingStudent == null)
                return NotFound(new { message = "Student not found" });

            existingStudent.FullName = dto.FullName;
            existingStudent.Email = dto.Email;
            existingStudent.Phone = dto.Phone;

            _service.UpdateStudentAsync(existingStudent);
            return Ok(new { message = "Student updated successfully" });
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UX_Students_Email") == true)
        {
            return BadRequest(new { message = $"A student with email '{dto.Email}' already exists." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while updating the student.", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        try
        {
            var student = _service.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { message = "Student not found" });

            _service.DeleteStudentAsync(id);
            return Ok(new { message = "Student deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while deleting the student.", error = ex.Message });
        }
    }
}