namespace ProjectManagementSystem
{
    public class Developer : Employee // Inherit from Employee abstract class
    {
        // Property specific to Developer
        public string ProgrammingLanguage { get; set; }

        // Constructor that calls the base class constructor and initializes programmingLanguage
        public Developer(int id, string name, string programmingLanguage) : base(id, name)
        {
            ProgrammingLanguage = programmingLanguage;
        }
    }
}