namespace ProjectManagementSystem;

public class Manager : Employee, ITrackable //inherit from Employee abstract class and implement ITrackable interface
{
    
    //private List<Employee> _employees;
    
    
    //constructor for Manager that takes in name and ID
    //"base" keyword calls the constructor in the Employee class, initializing these properties
    public Manager(int employeeId, string firstName, string lastName) 
        : base(employeeId, firstName, lastName, "Manager")
    {
    }
    
    //create method that takes in an Employee and a Task so that a manager can assign a task to an employee
    public void AssignTask(Employee employee, Task task)
    {
        employee.AddTask(task); // Use the protected AddTask from Employee
        Console.WriteLine($"Task '{task.Description}' assigned to {employee.firstName}.");
        
        //verify if the task is actually assigned
        foreach (var t in employee.Tasks)
        {
            Console.WriteLine($"Assigned Task: {t.ID} - {t.Description} to {employee.firstName}.");
        }
    }
    
    //update task status (Manager can do this for any employee). takes params emplyee name and task if
    public void UpdateTaskStatus(Employee employee, int taskId)
    {
        //fetch and update task status from the employee's task list
        List<Task> tasks = employee.Tasks; 
        //using LINQ method to find task by id (this searches in the list of tasks to find if any of them mathes the condition which is ID ==taskID)
        Task task = tasks.FirstOrDefault(t => t.ID == taskId); 
        if (task != null)
        {
            Console.WriteLine("Select a status for the task:");
            Console.WriteLine("1. To Do");
            Console.WriteLine("2. In Progress");
            Console.WriteLine("3. Completed");

            string input = Console.ReadLine();
            TaskStatus selectedStatus;

            //handle user input for task status
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

            //update task status and notify
            task.Status = selectedStatus; //update task status
            Console.WriteLine($"Task '{task.Description}' status updated to {selectedStatus} for {employee.firstName}.");
        }
        else
        {
            Console.WriteLine($"Task with ID {taskId} not found for {employee.firstName}.");
        }
    }

    public void UpdateStatus()
    {
        throw new NotImplementedException();
    }
    
    public void UpdateStatus(TaskStatus selectedStatus)
    {
        //placeholder for method
        Console.WriteLine($"Project status updated to: {selectedStatus}");
    }

    public void ViewTasks()
    {

        Console.WriteLine($"Tasks assigned to you: ");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}, Priority: {task.Priority}");
        }
    }

    //Inherit from Employee class (Polymorphism, this method does something different for each employee)
    public override void GenerateReport()
    {
        Console.WriteLine("Manager is generating a report for all employees.");

        foreach (var employee in Employee.GetAllEmployees())
        {
            Console.WriteLine($"\nEmployee: {employee.firstName} {employee.lastName}");
            foreach (var task in employee.Tasks)
            {
                Console.WriteLine($"Task number: {task.ID}, Title: {task.Description}, Status: {task.Status}, Priority: {task.Priority}");
            }
        }
    }

    public override void ExecuteRole()
    {
        Console.WriteLine("Manager is performing manager role.");
    }

    //inherited from ITrackable
    public string ProjectStatus { get; set; } 
    
    public void GetTask()
    {
        throw new NotImplementedException();
    }

    public void GetTaskById()
    {
        //placeholder
        Console.WriteLine("Not yet implemented.");
    }

    public void UpdateProjectStatus()
    {
        throw new NotImplementedException();
    }

    public void CompleteTask()
    {
        throw new NotImplementedException();
    }
}