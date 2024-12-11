using System.Linq.Expressions;

namespace ProjectManagementSystem
{
    public class Developer : Employee // Inherit from Employee abstract class
    {
        // Property specific to Developer
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
        // Implementation of abstract method GenerateReport
        public override void GenerateReport()
        {
            PersonalReport devReport = new PersonalReport("Developer");
            devReport.Generate();
        }

        // Developer implementation of View tasks, giving developer the option to filter by tasked assigned to developer
        public override void ViewTasks()
        {
            try
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
                Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while viewing tasks: {ex.Message}");
            }
        }

        // Implementation of abstract method ExecuteRole
        public override void ExecuteRole()
        {
            Console.WriteLine($"{FirstName} is writing code in {ProgrammingLanguage}.");
        }
    }
}