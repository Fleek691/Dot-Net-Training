using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagementSystem
{
    public class TaskManager
    {
        private List<Project> projects = new List<Project>();
        private int nextTaskId = 1;

        public void CreateProject(string name, string manager, DateTime start, DateTime end)
        {
            int projectId = projects.Count + 1;
            var project = new Project
            {
                ProjectId = projectId,
                ProjectName = name,
                ProjectManager = manager,
                StartDate = start,
                EndDate = end,
                Tasks = new List<TaskItem>()
            };
            projects.Add(project);
            Console.WriteLine($"Project '{name}' created successfully with ID: {projectId}");
        }

        public void AddTask(int projectId, string title, string description, string priority, DateTime dueDate, string assignee)
        {
            var project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project == null)
            {
                Console.WriteLine("Project not found!");
                return;
            }

            var task = new TaskItem
            {
                TaskId = nextTaskId++,
                Title = title,
                Description = description,
                Priority = priority,
                Status = "ToDo",
                DueDate = dueDate,
                AssignedTo = assignee
            };

            project.Tasks.Add(task);
            Console.WriteLine($"Task '{title}' added to project '{project.ProjectName}' with ID: {task.TaskId}");
        }

        public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
        {
            var allTasks = projects.SelectMany(p => p.Tasks);
            return allTasks.GroupBy(t => t.Priority)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<TaskItem> GetOverdueTasks()
        {
            var currentDate = DateTime.Now;
            return projects.SelectMany(p => p.Tasks)
                          .Where(t => t.DueDate < currentDate && t.Status != "Completed")
                          .ToList();
        }

        public List<TaskItem> GetTasksByAssignee(string assigneeName)
        {
            return projects.SelectMany(p => p.Tasks)
                          .Where(t => t.AssignedTo == assigneeName)
                          .ToList();
        }

        public List<Project> GetAllProjects()
        {
            return projects;
        }
    }
}
