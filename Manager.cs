namespace ProjectManagementSystem;

public class Manager : Employee //inherit from Employee abstract class and implement ITrackable interface
{

    //constructor for Manager that takes in name and ID
    //"base" keyword calls the constructor in the Employee class, initializing these properties
    public Manager(int employeeId, string FirstName, string LastName)
        : base(employeeId, FirstName, LastName, "Manager")
    {
    }

    //create list to hold projects
    private List<Project> Projects { get; } = new List<Project>();

    //create method that takes in an Employee and a Task so that a manager can assign a task to an employee
    public void AssignTask(Employee employee, Task task)
    {
        employee.AddTask(task); // Use the protected AddTask from Employee

        //verify if the task is actually assigned
        foreach (var t in employee.Tasks)
        {
            Console.WriteLine($"Assigned Task: {t.ID} - {t.Description} to {employee.FirstName}.");
        }
    }

    //Inherit from Employee class (Polymorphism, this method does something different for each employee)
    public override void GenerateReport()
    {
        Console.WriteLine();//adding for readability
        Console.WriteLine("Manager is generating a report for all employees: ");

        //loop through all employees by calling the method from Employee class which is inherited
        foreach (var employee in Employee.GetAllEmployees())
        {
            Console.WriteLine($"\nEmployee: {employee.FirstName} {employee.FirstName}");
            //for each employee, loop through each of their tasks
            foreach (var task in employee.Tasks)
            {
                //check if the task is linked to a project, else display message
                string projectName = task.Project != null ? task.Project.Name : "No project assigned";
                Console.WriteLine($"Project name: {projectName}, Task number: {task.ID}, Title: {task.Description}, Status: {task.Status}, Priority: {task.Priority}");
            }
        }
    }

    public override void ExecuteRole()
    {
        Console.WriteLine("Manager is performing manager role");
    }

    public Project CreateProject(int projectId, string name)
    {
        //create new instance of project class
        var project = new Project(projectId, name);
        //add this project to the list of projects for this manager
        Projects.Add(project);
        Console.WriteLine($"Project '{name}' created successfully by manager");

        //return project we just created
        return project;
    }

    public void AssignTaskToProject(Task task, Project project)
    {
        //check if the project exists in the list of projects from this manager
        if (Projects.Contains(project))
        {
            //if project exists, add task to the p[roject
            project.AddTask(task);
            task.Project = project; //set the project property of the Task to this project
        }
        else
        {
            //if project not found display error message
            Console.WriteLine($"Project '{project.Name}' does not exist");
        }
    }

    public void UpdateProjectStatus()
    {
        Console.WriteLine("Enter the project ID to update:");

        //read input and parse it to integer
        int projectId = int.Parse(Console.ReadLine());


        //find project in the list of the manager:
        var project = Projects.FirstOrDefault(p => p.ProjectID == projectId);

        if (project == null) //check if the project exists
        {
            Console.WriteLine($"Project with ID {projectId} doesn't exist");
            return;
        }

        Console.WriteLine("Select a status for the project:");
        Console.WriteLine("1. To Do");
        Console.WriteLine("2. In Progress");
        Console.WriteLine("3. Completed");

        string input = Console.ReadLine(); //read user input
        TaskStatus selectedStatus; //declare var to store project status


        //handle user input
        switch (input)
        {
            case "1":
                selectedStatus = TaskStatus.ToDo;
                break;
            case "2":
                selectedStatus = TaskStatus.InProgress;
                break;
            case "3":
                selectedStatus = TaskStatus.Completed;
                break;
            default:
                Console.WriteLine("Invalid input. Status not updated.");
                return;
        }

        //update status of project by calling method in project class and pasisng it the status defined here by user
        project.UpdateStatus(selectedStatus);

    }

    public void ViewProjects()
    {
        Console.WriteLine();
        Console.WriteLine("Projects list:");
        //loop through the list of projects
        foreach (var project in Projects)
        {
            project.DisplayDetails(); //for each project in the list call method to display details
            Console.WriteLine();//adding space for readability
        }
    }

}