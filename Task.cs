// CLASS TASK 

// Attributes will be based on Class diagram

using System;

namespace ProjectManagementSystem;

// incorporating enum, a special class that represents a group of unchangeable variables

public enum TaskStatus
{
    ToDo,
    InProgress,
    Completed
}
public class Task
{
    public int ID { get; set; } // get returns the value (of the ID property in this case)
    public string Description { get; set; }
    public TaskStatus Status { get; set; } // Status of the task enum
    public string Priority { get; set; }
    
    public Project Project { get; set; } //adding this to assign tasks to projects by referencing a project property here
    public Employee StartedBy { get; private set; } // Tracks the employee who started the task
    public string StartedByRole { get; private set; } // Tracks the role of the employee
    // Constructor which is used to add initial values to the attributes
    public Task(int id, string description, string priority)
    {
        ID = id;
        Description = description;
        Priority = priority;
        Status = TaskStatus.ToDo; // Default status of a ticket is ToDo
    }

    // Method created by Martin, to indicate when a task has been started
    public void StartAssignedTask(Employee employee)
    {
        if (Status == TaskStatus.ToDo)
        {
            Status = TaskStatus.InProgress;
            StartedBy = employee;
            StartedByRole = employee.Role;
            Console.WriteLine($"Task '{Description}' is now In Progress. Started by: {employee.firstName} {employee.lastName} ({employee.Role})");
        }
        else
        {
            Console.WriteLine($"Task '{Description}' cannot be started as it is already {Status}.");
        }
    }

    // Method created by Martin, to indicate when a task has been completed
    public void CompleteAssignedTask(Employee employee)
    {
        if (Status == TaskStatus.InProgress)
        {
            Status = TaskStatus.Completed;
            Console.WriteLine($"Task '{Description}' is now Completed by: {employee.firstName} {employee.lastName} ({employee.Role})");
        }
        else if (Status == TaskStatus.ToDo)
        {
            Console.WriteLine($"Task '{Description}' cannot be completed as it has not started yet.");
        }
        else
        {
            Console.WriteLine($"Task '{Description}' is already Completed by: {employee.firstName} {employee.lastName} ({employee.Role})");
        }
    }
}