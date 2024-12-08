namespace ProjectManagementSystem;

public class Project
{
    public int ProjectID { get; set; }
    public string Name { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.ToDo; // Default status
    public List<Task> Tasks { get; set; }

    public Project(int projectId, string name)
    {
        ProjectID = projectId;
        Name = name;
        Tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
        Console.WriteLine($"Task '{task.Description}' added to project '{Name}'");
    }

    public void UpdateStatus(TaskStatus status)
    {
        Status = status;
        Console.WriteLine($"Project '{Name}' status updated to: {status}");
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Project: {Name}, Status: {Status}");
        Console.WriteLine("Tasks:");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
        }
    }
}