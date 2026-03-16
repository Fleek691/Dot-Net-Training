using System.ComponentModel.DataAnnotations;

namespace StudentMVC.Models
{
    public class CreateStudentViewModel
    {
        [Required]
        [StringLength(120)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(180)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(30)]
        public string? Phone { get; set; }
    }
}
