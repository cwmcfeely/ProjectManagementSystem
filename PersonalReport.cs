using ProjectManagementSystem;

public class PersonalReport
{
    private string Role { get; set; }
    public DateTime GeneratedDate { get; private set; }

    public PersonalReport(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
            throw new ArgumentException("Role cannot be null or empty.");

        Role = role;
        GeneratedDate = DateTime.Now;
    }

    public void Generate()
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

        try
        {
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
        catch (Exception ex)
        {
            Console.WriteLine($"Console.WriteLine($\"Error generating report, error message: {ex.Message}");
        }
    }
}