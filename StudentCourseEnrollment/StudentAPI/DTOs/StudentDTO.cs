namespace StudentCourseEnrollment.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        // No navigation properties — no circular refs
    }
}

