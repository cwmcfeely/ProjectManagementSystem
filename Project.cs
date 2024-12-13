namespace ProjectManagementSystem;

public class Project : ITrackable
{
    private List<string> actionHistory = new List<string>();

    public int ProjectID { get; private set; }
    public string Name { get; private set; }
    public TaskStatus Status { get; set; } = TaskStatus.ToDo; // Default status
    public List<Task> Tasks { get; set; }

    public Project(int projectId, string name)
    {
        ProjectID = projectId;
        Name = name;
        Tasks = new List<Task>();
        LogAction($"Project '{name}' created with ID: {projectId}");
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
        Console.WriteLine($"Project: {Name}, ID:{ProjectID} Status: {Status}");
        Console.WriteLine("Tasks:");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
        }
    }

    public void LogAction(string actionDescription)
    {
        string logEntry = $"{DateTime.Now}: {actionDescription}";
        actionHistory.Add(logEntry);
        Console.WriteLine($"[LOG] {logEntry}");
    }

    public List<string> GetActionHistory()
    {
        Console.WriteLine(""); //Styling console output
        return new List<string>(actionHistory); // Return a copy to preserve encapsulation
    }

    public void ClearActionHistory()
    {
        actionHistory.Clear();
        Console.WriteLine("\nAction history cleared.");
    }
}