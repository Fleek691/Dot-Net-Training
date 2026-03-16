namespace StudentApi.DTOs
{
    public class UpdateStudentDto
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
    }
}
