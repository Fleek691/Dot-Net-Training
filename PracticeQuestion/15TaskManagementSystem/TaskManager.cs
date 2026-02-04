using System;
using System.Collections.Generic;

namespace TaskManagementSystem
{
    public class TaskManager
    {
        public void CreateProject(string name, string manager, DateTime start, DateTime end)
        {
        }

        public void AddTask(int projectId, string title, string description, string priority, DateTime dueDate, string assignee)
        {
        }

        public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
        {
            return null;
        }

        public List<TaskItem> GetOverdueTasks()
        {
            return null;
        }

        public List<TaskItem> GetTasksByAssignee(string assigneeName)
        {
            return null;
        }
    }
}
