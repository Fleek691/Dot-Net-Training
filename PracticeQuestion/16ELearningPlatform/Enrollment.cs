using System;

namespace ELearningPlatform
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double ProgressPercentage { get; set; }
    }
}
