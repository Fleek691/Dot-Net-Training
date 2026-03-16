namespace StudentMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Status { get; set; }
        public DateOnly JoinDate { get; set; }
    }
}
