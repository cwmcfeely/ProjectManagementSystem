using Xunit;

namespace ProjectManagementSystem.ProjectManagementSystem.Tests;

public class ManagerTests
{
    
    [Fact]
    public void AssignTask_ValidTask_AssignsTaskToEmployee()
    {
        // Arrange
        var manager = new Manager(1, "Alice", "Smith");
        var employee = new Developer(123, "Dave", "G","JavaScript");
        var task = new Task(101, "Implement Feature X", "High");

        // Act
        manager.AssignTask(employee, task);

        // Assert
        Assert.Contains(task, employee.ReadOnlyTasks);
        Assert.Equal(101, task.ID);
        Assert.Equal("Implement Feature X", task.Description);
        Assert.Equal("High", task.Priority);
        Assert.Equal(TaskStatus.ToDo, task.Status); // Default status
    }
}