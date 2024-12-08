﻿namespace ProjectManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Developer dev = new Developer(123, "Conor", "McFeely", "C#");
            Developer dev2 = new Developer(124, "Sean", "Owen", "Python");
            Intern intern = new Intern(8936, "Martin", "Fortuna");
            QAEngineer qAEngineer = new QAEngineer(102, "Jothika", "Tamilarasan");
            Manager manager = new Manager(7689, "Zouboulia", "Fanuda");
            
            
            dev.ExecuteRole();  // Output: Conor is writing code in C#.
            dev.GenerateReport();  // Output: Conor is generating a developer-specific report.
            manager.ExecuteRole(); //manager executing manager task
            
            
            //create projects
            var project1 = manager.CreateProject(7868, "PROJECT 1");
            var project2 = manager.CreateProject(0987, "PROJECT 2");


            //create the tasks
            Task firstTask = new Task(1234, "Fix Bug", "High");
            Task secondTask = new Task(1235, "Test login", "Medium");
            Task thirdTask = new Task(1245, "Learn C# Basics", "High");
            Task fourthTask = new Task(12348, "Develop shopping cart", "High");
            
            //assign tasks to projects
            manager.AssignTaskToProject(firstTask, project1);
            manager.AssignTaskToProject(secondTask, project1);
            manager.AssignTaskToProject(thirdTask, project2);
            
            //view the projects
            //manager.ViewProjects();
            
            //update project status: 
            manager.UpdateProjectStatus();
            manager.ViewProjects(); //view projects again to see status change

            //assign tasks to employees
            manager.AssignTask(dev, firstTask); //assign task to dev
            manager.AssignTask(qAEngineer, secondTask);
            manager.AssignTask(intern, thirdTask);
            manager.AssignTask(dev2, fourthTask);


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
            
            //update task status
            manager.UpdateStatus();//update task status as a manager (adding to the end as there is user input required)
            manager.GenerateReport(); //generate report for all employees
        }
    }
}