using System.ComponentModel.DataAnnotations;

namespace SimpleMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be greater than 2 characters")]
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
