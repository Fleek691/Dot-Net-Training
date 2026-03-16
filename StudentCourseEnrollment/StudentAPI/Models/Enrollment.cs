namespace StudentCourseEnrollment.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Students Student { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}