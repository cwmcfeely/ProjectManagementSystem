// CLASS EMPLOYEE

using System;

namespace ProjectManagementSystem;

// Abstract Employee class (which cannot be instantiated)

public abstract class Employee
{

    //creating a list to store employees (this is for Manager specific method to generate report)
    private static List<Employee> AllEmployees = new List<Employee>();

    public int EmployeeId { get; private set; } // Updating id to be an int
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }

    // Creating the list for the tasks
    protected internal List<Task> Tasks { get; private set; }

    // Constructor, method called when an object is created

    public Employee(int employeeId, string firstname, string lastname, string role)
    {
        EmployeeId = employeeId;
        FirstName = firstname;
        LastName = lastname;
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

    // Method by Conor so Employees and derivatives of employees can view tasks
    public virtual void ViewTasks()
    {
        if (Tasks.Count == 0)
        {
            Console.WriteLine($"No tasks assigned to {FirstName} {LastName}.");
            return;
        }

        Console.WriteLine($"Tasks assigned to {FirstName} {LastName}:");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"- Task ID: {task.ID}, Description: {task.Description}, Status: {task.Status}");
        }
    }

    // Protected AddTask method (only accessible to the sub classes, but will only be used by Manager)
    protected internal void AddTask(Task task)
    {
        Tasks.Add(task); // Ensure 'task' is of type Task
        Console.WriteLine($"Task '{task.Description}' added for {FirstName}.");
    }

    // Method created by Zouboulia to find Task by ID
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

    // Method created by Zouboulia to update task status
    public void UpdateStatus()
    {
        Console.WriteLine("\nEnter the task ID to update:");

        //read user input (task ID), parse it as an integer and store it in the taskId variable
        int taskId = int.Parse(Console.ReadLine());

        Console.WriteLine("\nSelect a status for the task:");
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
            Console.WriteLine($"Task '{task.Description}' status updated to {selectedStatus}.\n");
        }
        else
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
        }

    }

    public bool RemoveTask(Task task)
    {
        if (Tasks.Remove(task)) // Uses List<T>.Remove() to remove by reference
        {
            Console.WriteLine($"Task '{task.Description}' removed from {FirstName} {LastName}'s task list.");
            return true;
        }
        else
        {
            Console.WriteLine($"Task '{task.Description}' not found in {FirstName} {LastName}'s task list.");
            return false;
        }
    }

    // Abstract methods for class Employee showing on Class diagram
    public abstract void GenerateReport();
    public abstract void ExecuteRole();
}