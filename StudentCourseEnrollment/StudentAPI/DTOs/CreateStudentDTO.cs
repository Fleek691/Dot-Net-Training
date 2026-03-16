using System.ComponentModel.DataAnnotations;

namespace StudentCourseEnrollment.DTOs
{
    public class CreateStudentDTO
    {

        [Required]
        public string Name { get; set; }
        [EmailAddress]

        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
