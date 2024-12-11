namespace ProjectManagementSystem
{
    public class Developer : Employee // Inherit from Employee abstract class
    {
        // Property specific to Developer
        public string ProgrammingLanguage { get; set; }

        // Constructor that calls the base class constructor and initializes programmingLanguage
        public Developer(int employeeId, string FirstName, string LastName, string programmingLanguage) : base(employeeId, FirstName, LastName, "Developer")
        {
            ProgrammingLanguage = programmingLanguage;
        }
        // Implementation of abstract method GenerateReport
        public override void GenerateReport()
        {
            Console.WriteLine($"{FirstName} is generating a developer-specific report.");
        }

        public override void ViewTasks()
{
    Console.WriteLine($"Developer {FirstName} {LastName}'s Assigned Tasks:");

    // Filter tasks assigned to this developer
    var developerTasks = Tasks.Where(t => t != null).ToList();

    if (!developerTasks.Any())
    {
        Console.WriteLine("No tasks assigned to this developer.");
        return;
    }

    foreach (var task in developerTasks)
    {
        Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
    }
}

        // Implementation of abstract method ExecuteRole
        public override void ExecuteRole()
        {
            Console.WriteLine($"{FirstName} is writing code in {ProgrammingLanguage}.");
        }
    }
}