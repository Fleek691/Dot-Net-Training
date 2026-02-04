using System;

namespace TaskManagementSystem
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // High/Medium/Low
        public string Status { get; set; } // ToDo/InProgress/Completed
        public DateTime DueDate { get; set; }
        public string AssignedTo { get; set; }
    }
}
