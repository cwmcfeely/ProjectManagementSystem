namespace ProjectManagementSystem
{
    public class Developer : Employee // Inherit from Employee abstract class
    {
        // Property specific to Developer, 
        public string ProgrammingLanguage { get; private set; }

        // Constructor that calls the base class constructor and initializes programmingLanguage
        public Developer(int employeeId, string FirstName, string LastName, string programmingLanguage) : base(employeeId, FirstName, LastName, "Developer")
        {
            // Error handling for programming language
            if (string.IsNullOrWhiteSpace(programmingLanguage))
            {
                throw new ArgumentException("Programming language cannot be null or empty.", nameof(programmingLanguage));
            }

            ProgrammingLanguage = programmingLanguage;
        }

        // Developer implementation of View tasks, giving developer the option to filter by tasked assigned to developer
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

        // Implementation of abstract method GenerateReport
        public override void GenerateReport()
        {
            Console.WriteLine($"Developer Report for {FirstName} {LastName}:");

            if (!Tasks.Any())
            {
                Console.WriteLine("No tasks assigned.");
                return;
            }

            foreach (var task in Tasks)
            {
                task.DisplayTaskDetails(); // Using Task's method to display details
            }
        }

        // Implementation of abstract method ExecuteRole
        public override void ExecuteRole()
        {
            Console.WriteLine($"{FirstName} is writing code in {ProgrammingLanguage}.");
        }
    }
}