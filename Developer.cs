namespace ProjectManagementSystem
{
    public class Developer : Employee // Inherit from Employee abstract class
    {
        // Property specific to Developer
        public string ProgrammingLanguage { get; set; }

        // Constructor that calls the base class constructor and initializes programmingLanguage
        public Developer(string employeeId, string name, string programmingLanguage) : base(employeeId, name, "Developer")
        {
            ProgrammingLanguage = programmingLanguage;
        }

        // Implementation of abstract method GenerateReport
        public override void GenerateReport()
        {
            Console.WriteLine($"{Name} is generating a developer-specific report.");
        }

        // Implementation of abstract method ExecuteRole
        public override void ExecuteRole()
        {
            Console.WriteLine($"{Name} is writing code in {ProgrammingLanguage}.");
        }
    }
}