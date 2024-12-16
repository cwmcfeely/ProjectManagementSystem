namespace ProjectManagementSystem;

// Intern inherits from Employee class
public class Intern : Employee
{
    //Using employee class constructor
    public Intern(int employeeId, string FirstName, string LastName)
            : base(employeeId, FirstName, LastName, "Intern")
    {
        
    }

    // View own tasks method
    public override void ViewTasks()
    {
        Console.WriteLine($"Intern {FirstName} {LastName}'s Assigned Tasks:");

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

    // Generate task report based on roles. 
    public override void GenerateReport()
    {
        try
        {
            PersonalReport internReport = new PersonalReport("Intern");
            internReport.Generate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating report, error message: {ex.Message}");
        }
    }

    // Execute role
    public override void ExecuteRole()
    {
        Console.WriteLine($"\n {FirstName} is learning and assisting the team.");
    }

}