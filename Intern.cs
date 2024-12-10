namespace ProjectManagementSystem;

// Intern inherits from Employee class
public class Intern : Employee
{
    //Using employee class constructor
    public Intern(int employeeId, string firstName, string lastName)
            : base(employeeId, firstName, lastName, "Intern")
    {

    }

    public override void ViewTasks()
{
    Console.WriteLine($"Intern {firstName} {lastName}'s Assigned Tasks:");

    // Filter tasks assigned to this Intern
    var internTasks = Tasks.Where(t => t != null).ToList();

    if (!internTasks.Any())
    {
        Console.WriteLine("No tasks assigned to this Intern.");
        return;
    }

    foreach (var task in internTasks)
    {
        Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
    }
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

}