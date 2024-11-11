using System;

namespace ProjectManagementSystem;
 
public abstract class Employee
{
    public int EmployeeId;
    public string name;
    public string role;
 
    public Employee(int id, string name)
    {
        EmployeeId = id;
        name = name;
    }
}
 
public class Task
{
    public int TaskID;
    public string Description;
 
    public Task(int id, string description)
    {
        TaskID = id;
        Description = description;
    }
}