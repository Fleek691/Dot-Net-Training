using System.ComponentModel.DataAnnotations;

namespace StudentCourseEnrollment.DTOs
{
    public class CreateCourseDto
    {
        [Required,MaxLength(100)]
        
        public string Name { get; set; }
        [Required]
        public int Credits {get;set;}
    }
}