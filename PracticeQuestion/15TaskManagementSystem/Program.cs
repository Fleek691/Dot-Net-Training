using System;
using System.Linq;

namespace TaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            Console.WriteLine("=== Task Management System ===\n");

            // Test Case 1: Create projects
            Console.WriteLine("--- Creating Projects ---");
            manager.CreateProject("Website Redesign", "John Manager", new DateTime(2026, 1, 1), new DateTime(2026, 6, 30));
            manager.CreateProject("Mobile App Development", "Jane Director", new DateTime(2026, 2, 1), new DateTime(2026, 8, 31));
            manager.CreateProject("Database Migration", "Bob Lead", new DateTime(2026, 1, 15), new DateTime(2026, 4, 15));
            Console.WriteLine();

            // Test Case 2: Add tasks with priorities
            Console.WriteLine("--- Adding Tasks ---");
            manager.AddTask(1, "Design Homepage", "Create new homepage design", "High", new DateTime(2026, 2, 15), "Alice Designer");
            manager.AddTask(1, "Implement Navigation", "Code navigation menu", "Medium", new DateTime(2026, 2, 20), "Bob Developer");
            manager.AddTask(1, "Test Responsiveness", "Test on all devices", "Low", new DateTime(2026, 3, 1), "Charlie Tester");
            manager.AddTask(2, "Setup Project Structure", "Initialize mobile project", "High", new DateTime(2026, 2, 5), "David Developer");
            manager.AddTask(2, "Design UI Mockups", "Create app mockups", "High", new DateTime(2026, 2, 10), "Alice Designer");
            manager.AddTask(3, "Backup Current Database", "Create database backup", "High", new DateTime(2026, 1, 20), "Eve DBA");
            manager.AddTask(3, "Schema Migration", "Migrate database schema", "High", new DateTime(2026, 1, 10), "Eve DBA");
            Console.WriteLine();

            // Test Case 3: Group tasks by priority level
            Console.WriteLine("--- Grouping Tasks by Priority ---");
            var groupedTasks = manager.GroupTasksByPriority();
            foreach (var group in groupedTasks.OrderByDescending(g => g.Key == "High").ThenByDescending(g => g.Key == "Medium"))
            {
                Console.WriteLine($"\n{group.Key} Priority Tasks:");
                foreach (var task in group.Value)
                {
                    Console.WriteLine($"  - [{task.TaskId}] {task.Title} (Assigned to: {task.AssignedTo})");
                }
            }
            Console.WriteLine();

            // Test Case 4: Check overdue tasks
            Console.WriteLine("--- Checking Overdue Tasks ---");
            var overdueTasks = manager.GetOverdueTasks();
            if (overdueTasks.Count > 0)
            {
                Console.WriteLine($"Found {overdueTasks.Count} overdue task(s):");
                foreach (var task in overdueTasks)
                {
                    Console.WriteLine($"  - [{task.TaskId}] {task.Title} - Due: {task.DueDate:yyyy-MM-dd} (Assigned to: {task.AssignedTo})");
                }
            }
            else
            {
                Console.WriteLine("No overdue tasks found.");
            }
            Console.WriteLine();

            // Test Case 5: View tasks assigned to team members
            Console.WriteLine("--- Tasks Assigned to Alice Designer ---");
            var aliceTasks = manager.GetTasksByAssignee("Alice Designer");
            Console.WriteLine($"Alice has {aliceTasks.Count} task(s) assigned:");
            foreach (var task in aliceTasks)
            {
                Console.WriteLine($"  - [{task.TaskId}] {task.Title} - Priority: {task.Priority}, Due: {task.DueDate:yyyy-MM-dd}");
            }
            Console.WriteLine();

            Console.WriteLine("--- Tasks Assigned to Eve DBA ---");
            var eveTasks = manager.GetTasksByAssignee("Eve DBA");
            Console.WriteLine($"Eve has {eveTasks.Count} task(s) assigned:");
            foreach (var task in eveTasks)
            {
                Console.WriteLine($"  - [{task.TaskId}] {task.Title} - Priority: {task.Priority}, Due: {task.DueDate:yyyy-MM-dd}");
            }

            Console.WriteLine("\n=== End of Task Management System Demo ===");
        }
    }
}
