// CLASS EMPLOYEE

using System;

namespace ProjectManagementSystem;

// Abstract Employee class (which cannot be instantiated)

public abstract class Employee
{
    public int EmployeeId { get; set; } // Updating id to be an int
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Role { get; set; }

    // Creating the list for the tasks
    protected List<Task> Tasks { get; private set; }

    // Constructor, method called when an object is created

    public Employee(int employeeId, string firstname, string lastname, string role)
    {
        EmployeeId = employeeId;
        firstName = firstname;
        lastName = lastname;
        Role = role;
        Tasks = new List<Task>(); // Initialize the task list
    }

    // Protected AddTask method (only accesible to the sub classes, but will only be used by Manager)
    protected void AddTask(Task task)
    {
        Tasks.Add(task); // Ensure 'task' is of type Task
        Console.WriteLine($"Task '{task.Description}' added for {firstName}.");
    }



    // Abstract methods for class Employee showing on Class diagram
    public abstract void GenerateReport();
    public abstract void ExecuteRole();
}