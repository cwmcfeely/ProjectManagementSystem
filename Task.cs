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

    // Constructor which is used to add initial values to the attributes

    public Task(int id, string description, string priority)
    {
        ID = id;
        Description = description;
        Priority = priority;
        Status = TaskStatus.ToDo; // Default status of a ticket is ToDo
    }
}