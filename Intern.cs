namespace ProjectManagementSystem;

// Intern inherits from Employee class
public class Intern : Employee
{
    //Using employee class constructor
    public Intern(int employeeId, string firstName, string lastName)
            : base(employeeId, firstName, lastName, "Intern")
    {

    }

    // Iterating through tasks to print task report
    public override void GenerateReport()
    {
        Console.WriteLine($"Intern Report for {firstName} {lastName}:");

        Console.WriteLine("Tasks:");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
        }
    }

    // Execute role
    public override void ExecuteRole()
    {
        Console.WriteLine($"{firstName} is learning and assisting the team.");
    }

    public void StartTask(Task task)
    {
        if (task != null)
        {
            task.Status = TaskStatus.InProgress;
            Console.WriteLine($"{firstName} started task: {task.Description}");
        }
    }

    public void CompleteTask(Task task)
    {
        if (task != null)
        {
            task.Status = TaskStatus.Completed;
            Console.WriteLine($"{firstName} completed task: {task.Description}");
        }
    }

}