using System;
using System.Collections.Generic;

namespace ELearningPlatform
{
    public class StudentProgress
    {
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public Dictionary<string, double> ModuleScores { get; set; } // Module->Score
        public DateTime LastAccessed { get; set; }
    }
}
