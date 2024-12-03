using System.Xml;

namespace ProjectManagementSystem;


class Program
{
    static void Main(string[] args)
    {
        Developer dev = new Developer(123, "Conor", "McFeely","C#");
        
        dev.ExecuteRole();  // Output: Conor is writing code in C#.
        dev.GenerateReport();  // Output: Conor is generating a developer-specific report.


        Manager manager = new Manager(7689, "Zouboulia", "Fanuda");
        
        manager.ExecuteRole();
        
        Task firstTask = new Task(1234, "Fix Bug", "High");
        manager.AssignTask(dev, firstTask); //assign task to dev
        manager.UpdateTaskStatus(dev, 1234);
        
        manager.GenerateReport();
    }
} 