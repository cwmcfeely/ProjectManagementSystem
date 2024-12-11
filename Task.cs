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
        LogAction($"Task created: {ID} - '{description}'.");
    }

        // ITrackable Implementation to track all task history
        public void LogAction(string actionDescription)
        {
            string logEntry = $"{DateTime.Now}: {actionDescription}";
            actionHistory.Add(logEntry);
            Console.WriteLine($"[LOG] {logEntry}");
        }

        // ITrackable Implementation to retrieve log history
        public List<string> GetActionHistory()
        {
            // Return a copy to preserve encapsulation
            return new List<string>(actionHistory); 
        }

        // ITrackable Implementation to clear all log history
        public void ClearActionHistory()
        {
            actionHistory.Clear();
            Console.WriteLine("Action history cleared.");
        }


    // Method created by Martin, to indicate when a task has been started
    public void StartAssignedTask(Employee employee)
    {
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
        if (Status == TaskStatus.InProgress)
        {
            Status = TaskStatus.Completed;
            LogAction($"Task '{Description}' is now Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})");
            Console.WriteLine($"Task '{Description}' is now Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})");
        }
        else if (Status == TaskStatus.ToDo)
        {
            LogAction($"Task '{Description}' cannot be completed as it has not started yet.");
            Console.WriteLine($"Task '{Description}' cannot be completed as it has not started yet.");
        }
        else
        {
            LogAction($"Task '{Description}' is already Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})");
            Console.WriteLine($"Task '{Description}' is already Completed by: {employee.FirstName} {employee.LastName} ({employee.Role})");
        }
    }

    // Method to display task details on using .DisplayDetails() it should be called by anyone
    public void DisplayTaskDetails()
    {
        // checks if a project is asssigned to the task, if not add no project assigned
        string projectName = Project != null ? Project.Name : "No project assigned";
        Console.WriteLine($"Task ID: {ID}, Description: {Description}, Priority: {Priority}, Status: {Status}, Project: {projectName}");
    }

}