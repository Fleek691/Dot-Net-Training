namespace StudentCourseEnrollment.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime EnrollmentDate{get;set;}
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}