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
            
            //Creating tasks
            Task firstTask = new Task(1, "Fix Bug", "High");
            Task secondTask = new Task(2, "Test login", "Medium");
            Task thirdTask = new Task(3, "Learn C# Basics", "High");
            Task fourthTask = new Task(4, "Develop shopping cart", "High"); 
            Task task = new Task(5, "Task to be completed", "High");
            
            //Managers//
            
            //Creating projects
            var project1 = manager.CreateProject(12, "PROJECT 1");
            var project2 = manager.CreateProject(13, "PROJECT 2");

            //Assign tasks to projects. FourthTask will not be assigned to a project
            manager.AssignTaskToProject(firstTask, project1);
            manager.AssignTaskToProject(secondTask, project1);
            manager.AssignTaskToProject(thirdTask, project2);

            //Assigning tasks to employees
            manager.AssignTask(dev, firstTask);
            manager.AssignTask(qAEngineer, secondTask);
            manager.AssignTask(intern, thirdTask);
            manager.AssignTask(dev2, fourthTask);
            manager.AssignTask(qAEngineer, task);
            
            //generate report for all employee
            manager.GenerateReport(); 

            //Tasks//
            
            //display task details and task logs/action history
            fourthTask.DisplayTaskDetails();
            firstTask.GetActionHistory();
            

            //Developers//

            //Generate developer task report
            dev.GenerateReport();
            //View tasks assigned to self
            dev.ViewTasks();
            // Execute role
            dev.ExecuteRole();

            //Interns//

            //Generate intern task report
            intern.GenerateReport();
            //View tasks assigned to self
            intern.ViewTasks();
            // Execute role
            intern.ExecuteRole();

            //QA Engineers//

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

            //dev2.RemoveTask(fourthTask);

            // Task details //
            fourthTask.DisplayTaskDetails();
            firstTask.GetActionHistory();
            firstTask.ClearActionHistory();
            
            //update task status in program - this matters for completing task method below
            manager.UpdateStatus(5, TaskStatus.InProgress);
            
            //Complete tasks
            task.CompleteAssignedTask(dev);
            
            //user input methods//
            
            //Update project status:
            manager.UpdateProjectStatus();
            manager.ViewProjects(); //view projects again to see status change
            
            //Update task status with console
            qAEngineer.UpdateStatus();

        }
    }
}