class Program
{
    static void Main(string[] args)
    {
        Developer dev = new Developer(123, "Conor", "McFeely", "C#");

        dev.ExecuteRole();  // Output: Conor is writing code in C#.
        dev.GenerateReport();  // Output: Conor is generating a developer-specific report.


        Manager manager = new Manager(7689, "Zouboulia", "Fanuda");

        manager.ExecuteRole();

        Intern intern = new Intern(8936, "Martin", "Fortuna")


        intern.ExecuteRole();

        Task firstTask = new Task(1234, "Fix Bug", "High");
        Task secondTask = new Task(1235, "Learn Basic C#", "Medium");
        Task thirdTask = new Task(1245, "Learn C# Basics", "High");

        manager.AssignTask(dev, firstTask); //assign task to dev
        manager.UpdateStatus();//update task status as a manager
        manager.GenerateReport();


        intern.StartTask();
        intern.CompleteTask()
        intern.GenerateReport();
    }
}