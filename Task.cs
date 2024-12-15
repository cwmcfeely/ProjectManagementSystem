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
public class Task : ITrackable
{

    private List<string> actionHistory = new List<string>();

    public int ID { get; private set; } // get returns the value (of the ID property in this case)
    public string Description { get; private set; }
    public TaskStatus Status { get; set; } // Status of the task enum
    public string Priority { get; set; }

    public Project Project { get; set; } //adding this to assign tasks to projects by referencing a project property here
    public Employee StartedBy { get; private set; } // Tracks the employee who started the task
    public string StartedByRole { get; private set; } // Tracks the role of the employee
    // Constructor which is used to add initial values to the attributes
    public Task(int id, string description, string priority)
    {
        if (id <= 0) // Make sure the ID is a positive number
        {
            throw new ArgumentException("Task ID must be greater than zero.");
        }
        if (string.IsNullOrWhiteSpace(description)) // Check that the description is not empty or null
        {
            throw new ArgumentException("Task description cannot be null or empty.");
        }
        if (string.IsNullOrWhiteSpace(priority)) // Ensure priority is provided
        {
            throw new ArgumentException("Task priority cannot be null or empty.");
        }

        ID = id;
        Description = description;
        Priority = priority;
        Status = TaskStatus.ToDo; // Default status of a ticket is ToDo
        LogAction($"Task created: {ID} - '{description}'.");
    }

    // ITrackable Implementation to track all task history
    public void LogAction(string actionDescription)
    {
        if (string.IsNullOrWhiteSpace(actionDescription)) // Ensure the action description is valid
        {
            Console.WriteLine("Action description cannot be empty or null.");
            return;
        }
        string logEntry = $"{DateTime.Now}: {actionDescription}";
        actionHistory.Add(logEntry);
        Console.WriteLine($"[LOG] {logEntry}");
    }

    // ITrackable Implementation to retrieve log history
    public List<string> GetActionHistory()
    {
        if (actionHistory == null || actionHistory.Count == 0) // Verify if there are no logged actions
        {
            Console.WriteLine("No actions have been logged yet.");
            return new List<string>();
        }
        // Return a copy to maintain original log safety
        return new List<string>(actionHistory);
    }

    // ITrackable Implementation to clear all log history
    public void ClearActionHistory()
    {
        if (actionHistory == null || actionHistory.Count == 0) // Check if the log is already empty
        {
            Console.WriteLine("Action history is already empty.");
            return;
        }
        actionHistory.Clear();
        Console.WriteLine("Action history cleared.");
    }


    // Method created by Martin, to indicate when a task has been started
    public void StartAssignedTask(Employee employee)
    {
        if (employee == null) // Verify that an employee is provided
        {
            Console.WriteLine("A valid employee is required to start the task.");
            return;
        }

        if (Status == TaskStatus.ToDo)
        {
            Status = TaskStatus.InProgress;
            StartedBy = employee;
            StartedByRole = employee.Role;
            LogAction($"Task '{Description}' is now In Progress. Started by: {employee.FirstName} {employee.LastName} ({employee.Role})");
            Console.WriteLine($"Task '{Description}' is now In Progress. Started by: {employee.FirstName} {employee.LastName} ({employee.Role})");
        }
        else
        {
            LogAction($"Task '{Description}' cannot be started as it is already {Status}.");
            Console.WriteLine($"Task '{Description}' cannot be started as it is already {Status}.");
        }
    }

    // Method created by Martin, to indicate when a task has been completed
    public void CompleteAssignedTask(Employee employee)
    {
        if (employee == null) // Ensure a valid employee is provided
        {
            Console.WriteLine("A valid employee is required to complete the task.");
            return;
        }

        if (Status == TaskStatus.InProgress)
        {
            Status = TaskStatus.Completed;
            LogAction($"Task '{Description}' is now Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})");
            Console.WriteLine($"Task '{Description}' is now Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})");
        }
        else if (Status == TaskStatus.ToDo)
        {
            LogAction($"Task '{Description}' cannot be completed as it has not started yet.\n");
            Console.WriteLine($"Task '{Description}' cannot be completed as it has not started yet.\n");
        }
        else
        {
            LogAction($"Task '{Description}' is already Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})\n");
            Console.WriteLine($"Task '{Description}' is already Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})\n");
        }
    }

    // Method to display task details on using .DisplayDetails() it should be called by anyone
    public void DisplayTaskDetails()
    {
        if (string.IsNullOrWhiteSpace(Description)) // Verify that the description is not missing
        {
            Console.WriteLine("Cannot display task details. Description is missing.");
            return;
        }
        // Check if a project is assigned to the task, if not add no project assigned
        string projectName = Project != null ? Project.Name : "No project assigned";
        Console.WriteLine($"Task ID: {ID}, Description: {Description}, Priority: {Priority}, Status: {Status}, Project: {projectName}");
    }
}