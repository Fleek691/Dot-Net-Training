namespace StudentCourseEnrollment.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits {get;set;}
        public int Duration {get;set;}
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}