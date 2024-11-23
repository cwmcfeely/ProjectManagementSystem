namespace ProjectManagementSystem;


class Program
{
    static void Main(string[] args)
    {
        Developer dev = new Developer("D001", "Conor McFeely","C#");
        
        dev.ExecuteRole();  // Output: Alice is writing code in C#.
        dev.GenerateReport();  // Output: Alice is generating a developer-specific report.
    }
}