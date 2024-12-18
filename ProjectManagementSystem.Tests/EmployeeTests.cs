using Xunit;
using ProjectManagementSystem;
using PMTask = ProjectManagementSystem.Task;
using PMTaskStatus = ProjectManagementSystem.TaskStatus;

public class EmployeeTests
{
    private class TestEmployee : Employee
    {
        public TestEmployee(int id, string firstName, string lastName, string role)
            : base(id, firstName, lastName, role) { }

        public override void GenerateReport() { }
        public override void ExecuteRole() { }
    }

    [Fact]
    public void Constructor_ValidInput_CreatesEmployee()
    {
        // Arrange & Act
        var employee = new TestEmployee(1, "John", "Doe", "Developer");

        // Assert
        Assert.Equal(1, employee.EmployeeId);
        Assert.Equal("John", employee.FirstName);
        Assert.Equal("Doe", employee.LastName);
        Assert.Equal("Developer", employee.Role);
        Assert.Empty(employee.ReadOnlyTasks);
    }

    [Theory]
    [InlineData(0, "John", "Doe", "Developer")]
    [InlineData(1, "", "Doe", "Developer")]
    [InlineData(1, "John", "", "Developer")]
    [InlineData(1, "John", "Doe", "")]
    public void Constructor_InvalidInput_ThrowsArgumentException(int id, string firstName,
        string lastName, string role)
    {
        Assert.Throws<ArgumentException>(() =>
            new TestEmployee(id, firstName, lastName, role));
    }
}
