namespace ProjectManagementSystem
{
    public class Developer : Employee // Inherit from Employee abstract class
    {
        // Property specific to Developer
        public string ProgrammingLanguage { get; set; }

        // Constructor that calls the base class constructor and initializes programmingLanguage
        public Developer(int employeeId, string firstname, string lastname, string programmingLanguage) : base(employeeId, firstname, lastname, "Developer")
        {
            ProgrammingLanguage = programmingLanguage;
        }
        // Implementation of abstract method GenerateReport
        public override void GenerateReport()
        {
            Console.WriteLine($"{firstName} is generating a developer-specific report.");
        }

        // Implementation of abstract method ExecuteRole
        public override void ExecuteRole()
        {
            Console.WriteLine($"{firstName} is writing code in {ProgrammingLanguage}.");
        }
    }
}