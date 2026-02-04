using System.Collections.Generic;

namespace ELearningPlatform
{
    public class Course
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int DurationWeeks { get; set; }
        public double Price { get; set; }
        public List<string> Modules { get; set; }
    }
}
