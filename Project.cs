namespace ProjectManagementSystem;

public class Project : ITrackable
{
    //private list to store the action history for this project
    private List<string> actionHistory = new List<string>();

    public int ProjectID { get; private set; }
    public string Name { get; private set; }
    public string Status { get; private set; } = "To Do"; // Default status
    public List<Task> Tasks { get; set; }

    //constructor to initialize a project with ID and name
    public Project(int projectId, string name)
    {
        ProjectID = projectId;
        Name = name;
        Tasks = new List<Task>(); //initialise an empty list of tasks when a project is created
        LogAction($"Project '{name}' created with ID: {projectId}");
    }

    //method to add a task to the project
    public void AddTask(Task task)
    {
        Tasks.Add(task); //Add the task to the list of tasks for the project
        Console.WriteLine($"Task '{task.Description}' added to project '{Name}'");
    }

    //Method to update the status of the project
    public void UpdateStatus(Project project, string newStatus)
    {
        //Check if the project passed as parameter is null
        if (project == null)
        {
            Console.WriteLine("Project cannot be null.");
            return;
        }

        // Validate allowed statuses
        var allowedStatuses = new List<string> { "To Do", "In Progress", "Completed" };
        if (!allowedStatuses.Contains(newStatus))
        {
            Console.WriteLine($"Status: '{newStatus}' is not valid. Please select: 'To Do', 'In Progress', 'Completed'");
            return;
        }

        //update status
        Status = newStatus;
        LogAction($"Status updated to '{newStatus}'");
        Console.WriteLine($"Project '{Name}' status updated to: {newStatus}");
    }

    //Method to display all project details (incl. tasks)
    public void DisplayDetails()
    {
        Console.WriteLine($"Project: {Name}, ID:{ProjectID} Status: {Status}");
        Console.WriteLine("Tasks:");
        //loop through all tasks in list of tasks and print each task in the project
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