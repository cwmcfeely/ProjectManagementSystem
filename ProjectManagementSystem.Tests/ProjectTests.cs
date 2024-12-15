using Xunit;

namespace ProjectManagementSystem.ProjectManagementSystem.Tests;

public class ProjectTests
{
    //tests that a task gets assigned to a project
    [Fact]
    public void AddTask_ValidTask_AddsTaskToProject()
    {
        // Arrange
        var project = new Project(1234, "PROJECT 1h");
        var task = new Task(8765, "Fix all the bugs", "High");

        // Act
        project.AddTask(task);

        // Assert
        Assert.Contains(task, project.Tasks);
        Assert.Equal("Fix all the bugs", project.Tasks[0].Description);
        Assert.Equal("High", project.Tasks[0].Priority);
    }
    
    //testing update project status function - updates project status successfully
    [Fact]
    public void UpdateStatus_ValidStatus_UpdatesProjectStatus()
    {
        // Arrange
        var project = new Project(1111, "Project Management System");

        // Act
        project.UpdateStatus(TaskStatus.InProgress);

        // Assert
        Assert.Equal(TaskStatus.InProgress, project.Status);
    }
}