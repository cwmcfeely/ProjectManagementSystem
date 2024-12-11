using ProjectManagementSystem;

public class PersonalReport : Report
{
    private string Role { get; set; }

    public PersonalReport(string role)
    {
        Role = role ?? throw new ArgumentNullException(nameof(role));
    }

    public override void Generate()
    {
        Console.WriteLine($"\nPersonal Report for {Role}s:");
        Console.WriteLine($"Generated on: {GeneratedDate}");

        // Filter employees by role
        var employeeRoles = new List<Employee>();
        foreach (var employee in Employee.GetAllEmployees())
        {
            if (employee.Role == Role)
            {
                employeeRoles.Add(employee);
            }
        }

        if (employeeRoles.Count == 0)
        {
            Console.WriteLine($"No {Role} employees found.");
            return;
        }


        foreach (var employee in employeeRoles)
        {
            Console.WriteLine($"\nEmployee: {employee.FirstName} {employee.LastName}");

            if (employee.Tasks.Count == 0)
            {
                Console.WriteLine("  No tasks assigned.");
                continue;
            }

            Console.WriteLine("Tasks:");
            foreach (var task in employee.Tasks)
            {
                Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}, Priority: {task.Priority}");
            }
        }
    }
}