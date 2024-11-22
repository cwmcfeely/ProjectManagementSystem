// CLASS TASK 

// Attributes will be based on Class diagram

using System;

namespace ProjectManagementSystem;

public class Task
{
    public string ID { get; set; } // get returns the value (of the ID property in this case)
    public string Description { get; set; }
    public string Status { get; set; } // set assigns a value (to the Status property)
    public string Priority { get; set; }

    // Constructor which is used to add initial values to the attributes

    public Task(string id, string description, string status, string priority)
    {
        ID = id;
        Description = description;
        Status = status;
        Priority = priority;
    }
}