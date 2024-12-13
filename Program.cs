namespace ProjectManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating new employees
            Developer dev = new Developer(123, "Conor", "McFeely", "C#");
            Developer dev2 = new Developer(124, "Sean", "Owen", "Python");
            Developer dev3 = new Developer(189, "Bob", "McBob", "Ruby");
            Intern intern = new Intern(8936, "Martin", "Fortuna");
            QAEngineer qAEngineer = new QAEngineer(102, "Jothika", "Tamilarasan");
            Manager manager = new Manager(7689, "Zouboulia", "Fanuda");


            //Creating projects
            var project1 = manager.CreateProject(7868, "PROJECT 1");
            var project2 = manager.CreateProject(0987, "PROJECT 2");


            //Creating tasks
            Task firstTask = new Task(1234, "Fix Bug", "High");
            Task secondTask = new Task(1235, "Test login", "Medium");
            Task thirdTask = new Task(1245, "Learn C# Basics", "High");
            Task fourthTask = new Task(12348, "Develop shopping cart", "High");


            manager.ExecuteRole();

            //Assign tasks to projects
            manager.AssignTaskToProject(firstTask, project1);
            manager.AssignTaskToProject(secondTask, project1);
            manager.AssignTaskToProject(thirdTask, project2);

            //View the projects
            manager.ViewProjects();

            //Update project status:
            manager.UpdateProjectStatus();
            manager.ViewProjects(); //view projects again to see status change

            //Assigning tasks to employees
            manager.AssignTask(dev, firstTask);
            manager.AssignTask(qAEngineer, secondTask);
            manager.AssignTask(intern, thirdTask);
            manager.AssignTask(dev2, fourthTask);

            //Generate task by employee report
            manager.GenerateReport();

            fourthTask.DisplayTaskDetails();
            firstTask.GetActionHistory();

            //Tasks//

            //Developers

            //Generate developer task report
            dev.GenerateReport();
            //View tasks assigned to self
            dev.ViewTasks();
            // Execute role
            dev.ExecuteRole();
            //Update task status 
            dev.UpdateStatus();

            //Interns

            //Generate intern task report
            intern.GenerateReport();
            //View tasks assigned to self
            intern.ViewTasks();
            // Execute role
            intern.ExecuteRole();
            //Update task status 
            intern.UpdateStatus();

            // QA Engineers

            //Generate qa engineer task report
            qAEngineer.GenerateReport();
            //View tasks assigned to self
            qAEngineer.ViewTasks();
            // Execute role
            qAEngineer.ExecuteRole();

            TestCase testCase1 = qAEngineer.CreateTestCase(1, "Verify user login functionality with valid and invalid credentials", "Success", secondTask);
            testCase1.UpdateActualResult("Failure");
            if (testCase1.Status == "Fail")
            {
                Defect defect1 = qAEngineer.ReportDefect(101, "Login fails for valid credentials", testCase1);
            }

            //Update task status 
            qAEngineer.UpdateStatus();

            //dev2.RemoveTask(fourthTask);

            // Task details 
            fourthTask.DisplayTaskDetails();
            firstTask.GetActionHistory();
            firstTask.ClearActionHistory();


            //Manager update task status
            manager.UpdateStatus();//update task status as a manager (adding to the end as there is user input required)
            manager.GenerateReport(); //generate report for all employee

        }
    }
}