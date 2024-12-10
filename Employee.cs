// CLASS EMPLOYEE

using System;

namespace ProjectManagementSystem;

// Abstract Employee class (which cannot be instantiated)

public abstract class Employee
{
    
    //creating a list to store employees (this is for Manager specific mathod to generate report)
    private static List<Employee> AllEmployees = new List<Employee>();
    
    public int EmployeeId { get; set; } // Updating id to be an int
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Role { get; set; }

    // Creating the list for the tasks
    protected internal List<Task> Tasks { get; private set; }

    // Constructor, method called when an object is created

    public Employee(int employeeId, string firstname, string lastname, string role)
    {
        EmployeeId = employeeId;
        firstName = firstname;
        lastName = lastname;
        Role = role;
        Tasks = new List<Task>(); // Initialize the task list
        
        //add new employee to employee list automatically
        AllEmployees.Add(this);
    }
    
    //since list of employees is private but manager needs to access it for reports, creating public method that returns the private list (encapsulation)
    public static List<Employee> GetAllEmployees()
    {
        return AllEmployees;
    }

    // Method by Conor so Employees and derivaties of employees can view tasks
    public virtual void ViewTasks()
{
    if (Tasks.Count == 0)
    {
        Console.WriteLine($"No tasks assigned to {firstName} {lastName}.");
        return;
    }

    Console.WriteLine($"Tasks assigned to {firstName} {lastName}:");
    foreach (var task in Tasks)
    {
        Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
    }
}

    // Protected AddTask method (only accesible to the sub classes, but will only be used by Manager)
    protected void AddTask(Task task)
    {
        Tasks.Add(task); // Ensure 'task' is of type Task
        Console.WriteLine($"Task '{task.Description}' added for {firstName}.");
    }
    
    // Method created by Zoubilia to find Task by ID
    public Task GetTaskById(int taskId)
    {
        //search task by ID
        foreach (var employee in Employee.GetAllEmployees()) //iterate through all employees
        {
            var task = employee.Tasks.FirstOrDefault(t => t.ID == taskId); //search each employee's tasks
            if (task != null)
            {
                return task; //if found, return task
            }
        }
        return null; 
    }

    // Method created by Zoubilia to update task status
    public void UpdateStatus()
    {
        Console.WriteLine("Enter the task ID to update:");
        
        //read user input (task ID), parse it as an integer and store it in the taskId variable
        int taskId = int.Parse(Console.ReadLine());

        Console.WriteLine("Select a status for the task:");
        Console.WriteLine("1. To Do");
        Console.WriteLine("2. In Progress");
        Console.WriteLine("3. Completed");

        string input = Console.ReadLine(); //read user input for task status selection and store in variable
        TaskStatus selectedStatus; //declare a variable to store the selected task status (of type TaskStatus)

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
                Console.WriteLine("Invalid input");
                return;
        }
        
        //fetch the task by ID
        var task = GetTaskById(taskId);

        if (task != null)
        {
            task.Status = selectedStatus; //if task is found, update its status to selected status
            Console.WriteLine($"Task '{task.Description}' status updated to {selectedStatus}.");
        }
        else
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
        }
        
    }

    // Abstract methods for class Employee showing on Class diagram
    public abstract void GenerateReport();
    public abstract void ExecuteRole();
}