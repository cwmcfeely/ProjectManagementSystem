// CLASS EMPLOYEE

using System;

namespace ProjectManagementSystem;

// Abstract Employee class (which cannot be instantiated)

public abstract class Employee
{

    //creating a list to store employees (this is for Manager specific mathod to generate report)
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
        if (employeeId <= 0) // Check if the employee ID is valid (greater than zero)
            throw new ArgumentException("Employee ID must be greater than zero.");

        if (string.IsNullOrWhiteSpace(firstname)) // Make sure the first name is not empty
            throw new ArgumentException("First name cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(lastname)) // Make sure the last name is not empty
            throw new ArgumentException("Last name cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(role)) // Make sure the role is provided
            throw new ArgumentException("Role cannot be null or empty.");

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

    // Method by Conor so Employees and derivaties of employees can view tasks
    public virtual void ViewTasks()
    {
        if (Tasks == null || Tasks.Count == 0) // Check if there are no tasks assigned
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

    // Protected AddTask method (only accesible to the sub classes, but will only be used by Manager)
    protected internal void AddTask(Task task)
    {
        if (task == null) // Check if the task provided is not null
        {
            Console.WriteLine("Cannot add a null task.");
            return;
        }

        Tasks.Add(task); // Add the task to the list
        Console.WriteLine($"Task '{task.Description}' added for {FirstName}.");
    }

    // Method created by Zoubilia to find Task by ID
    public Task GetTaskById(int taskId)
    {
        if (taskId <= 0) // Check if the task ID is valid (greater than zero)
        {
            Console.WriteLine("Task ID must be greater than zero.");
            return null;
        }

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

        if (!int.TryParse(Console.ReadLine(), out int taskId)) // Validate the task ID input
        {
            Console.WriteLine("Invalid task ID. Please enter a valid number.");
            return;
        }

        Console.WriteLine("Select a status for the task:");
        Console.WriteLine("1. To Do");
        Console.WriteLine("2. In Progress");
        Console.WriteLine("3. Completed");

        string input = Console.ReadLine(); // Get user input for task status
        TaskStatus selectedStatus; // Variable to store the selected task status

        // Handle user input for task status
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
            task.Status = selectedStatus; // Update the task status
            Console.WriteLine($"Task '{task.Description}' status updated to {selectedStatus}.");
        }
        else
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
        }

    }

    public bool RemoveTask(Task task)
    {
        if (task == null) // Check if the task provided is not null
        {
            Console.WriteLine("Cannot remove a null task.");
            return false;
        }

        if (Tasks.Remove(task)) // Remove the task from the list
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