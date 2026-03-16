using System.ComponentModel.DataAnnotations;

namespace StudentApi.DTOs
{
    public class CreateStudentDto
    {
        [Required, MinLength(2)]
        public string FullName { get; set; }
        [Required, MinLength(2)]
        public string Email { get; set; }   
        public string? Phone { get; set; }
    }
}