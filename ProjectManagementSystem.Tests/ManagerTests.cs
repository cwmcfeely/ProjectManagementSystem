using Xunit;

namespace ProjectManagementSystem.ProjectManagementSystem.Tests;

public class ManagerTests
{
    //Assigns the task to the correct employee
    // [Fact]
    // public void AssignTask_ValidTask_AssignsTaskToEmployee()
    // {
    //     // Arrange
    //     var manager = new Manager(1, "Alice", "Smith");
    //     var employee = new Developer(123, "Dave", "G","JavaScript");
    //     var task = new Task(101, "Implement Feature X", "High");
    //
    //     // Act
    //     manager.AssignTask(employee, task);
    //
    //     // Assert
    //     Assert.Contains(task, employee.ReadOnlyTasks);
    //     Assert.Equal(101, task.ID);
    //     Assert.Equal("Implement Feature X", task.Description);
    //     Assert.Equal("High", task.Priority);
    //     Assert.Equal(TaskStatus.ToDo, task.Status);
    // }
    
    //If employee is null, the method throws an error. This test will fail as t he method to assign tasks doesn't 
    //currently throw an exception if the employee is empty
    // [Fact]
    // public void AssignTask_InvalidEmployee_ThrowsException()
    // {
    //     // Arrange
    //     var manager = new Manager(1, "Marie", "F");
    //     var task = new Task(101, "Design the system architecture", "V High");
    //
    //     // Act & Assert
    //     Assert.Throws<ArgumentNullException>(() => manager.AssignTask(null, task));
    // }
    
    //creating a project with the correct project details 
    // [Fact]
    // public void CreateProject_ValidProject_ReturnsCorrectProject()
    // {
    //     // Arrange
    //     var manager = new Manager(1, "John", "Doe");
    //
    //     // Act
    //     var project = manager.CreateProject(1234, "PROJECT 1");
    //
    //     // Assert
    //     Assert.NotNull(project);
    //     Assert.Equal(1234, project.ProjectID);
    //     Assert.Equal("PROJECT 1", project.Name);
    // }
    
    //Testing that a task gets assigned to a specific project
    // [Fact]
    // public void AssignTaskToProject_ValidTaskAndProject_AssignsTaskSuccessfully()
    // {
    //     // Arrange
    //     var manager = new Manager(6, "John", "Doe");
    //     var project = manager.CreateProject(1234, "PROJECT 1");
    //     var task = new Task(0987, "Fix some bugs", "High");
    //
    //     // Act
    //     manager.AssignTaskToProject(task, project);
    //
    //     // Assert
    //     Assert.Contains(task, project.Tasks);
    //     Assert.Equal(project, task.Project);
    // }
    
}