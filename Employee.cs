// CLASS EMPLOYEE

using System;

namespace ProjectManagementSystem;

// incorporating enum, a special class that represents a group of unchangeable variables

public enum TaskStatus
{
    ToDo,
    InProgress,
    Completed
}

// Abstract Employee class (which cannot be instantiated)

public abstract class Employee
{
    public string EmployeeId { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }

    // Constructor, method called when an object is created

    public Employee(string employeeId, string name, string role)
    {
        EmployeeId = employeeId;
        Name = name;
        Role = role;
    }


    // Abstract methods for class Employee showing on Class diagram

    public abstract void GenerateReport();
    public abstract void ExecuteRole();
}