namespace ProjectManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new Developer(123, "Conor", "McFeely", "C#");
            Developer dev2 = new Developer(124, "Sean", "Owen", "Python");
            Intern intern = new Intern(8936, "Martin", "Fortuna");
            QAEngineer qAEngineer = new QAEngineer(102, "Jothika", "Tamilarasan");

            dev.ExecuteRole();  // Output: Conor is writing code in C#.
            dev.GenerateReport();  // Output: Conor is generating a developer-specific report.


            Manager manager = new Manager(7689, "Zouboulia", "Fanuda");

            manager.ExecuteRole();


            Task firstTask = new Task(1234, "Fix Bug", "High");
            Task secondTask = new Task(1235, "Test login", "Medium");
            Task thirdTask = new Task(1245, "Learn C# Basics", "High");
            Task fourthTask = new Task(12348, "Develop shopping cart", "High");

            manager.AssignTask(dev, firstTask); //assign task to dev
            manager.AssignTask(qAEngineer, secondTask);
            manager.AssignTask(intern, thirdTask);
            manager.AssignTask(dev2, fourthTask);
            manager.UpdateStatus();//update task status as a manager
            manager.GenerateReport();


            intern.StartTask(firstTask);
            intern.CompleteTask(firstTask);
            intern.GenerateReport();


            qAEngineer.ExecuteRole();
            TestCase testCase1 = qAEngineer.CreateTestCase(1, "Verify Login", "Success");
            TestCase testCase2 = qAEngineer.CreateTestCase(2, "Verify Logout", "Success");
            qAEngineer.GenerateReport();

            // Generate a report for all developers
            PersonalReport devReport = new PersonalReport("Developer");
            devReport.Generate();


            // Generate a report for all Interns
            PersonalReport internReport = new PersonalReport("Intern");
            internReport.Generate();

            // Generate a report for all QA Engineers
            PersonalReport qaReport = new PersonalReport("QA Engineer");
            qaReport.Generate();
        }
    }
}