using System.ComponentModel.DataAnnotations;

namespace StudentMVC.Models
{
    public class EditStudentViewModel
    {
        public int StudentId { get; set; }

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

        public string Status { get; set; }
        public DateOnly JoinDate { get; set; }
    }
}
