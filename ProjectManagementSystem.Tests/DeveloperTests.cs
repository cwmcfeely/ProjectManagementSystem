using Xunit;
using ProjectManagementSystem;

namespace ProjectManagementSystem.Tests
{
    public class DeveloperTests
    {
        [Fact] // Attribute to mark this method as a test
        public void Constructor_ValidInput_CreatesInstance()
        {
            // Arrange and act, creates a new developer instance with valid inputs
            var developer = new Developer(1, "John", "Doe", "C#");

            // verify that the developer object is created with the correct properties
            Assert.Equal(1, developer.EmployeeId);
            Assert.Equal("John", developer.FirstName);
            Assert.Equal("Doe", developer.LastName);
            Assert.Equal("C#", developer.ProgrammingLanguage);
            Assert.Equal("Developer", developer.Role);
        }

        [Fact]
        public void Constructor_EmptyProgrammingLanguage_ThrowsArgumentException()
        {
            // Verify crreating a developet with an empty programmy language throws an exception
            Assert.Throws<ArgumentException>(() =>
                new Developer(1, "John", "Doe", ""));
        }

        [Fact]
        public void Constructor_NullProgrammingLanguage_ThrowsArgumentException()
        {
            // Verify crreating a developet with an null programmy language throws an exception
            Assert.Throws<ArgumentException>(() =>
                new Developer(1, "John", "Doe", null));
        }

        [Fact]
        public void ViewTasks_WithNoTasks_DisplaysEmptyMessage()
        {
            // Create a Developer and set up console output capture
            var developer = new Developer(1, "John", "Doe", "C#");
            var output = new StringWriter();
            Console.SetOut(output);

            // Call view tasks method
            developer.ViewTasks();

            // Veify the correct message is displayed
            Assert.Contains("No tasks assigned to this developer", output.ToString());
        }

        [Fact]
        public void ExecuteRole_DisplaysCorrectMessage()
        {
            // Arrange
            var developer = new Developer(1, "John", "Doe", "C#");
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            developer.ExecuteRole();

            // Assert
            Assert.Contains("John is writing code in C#", output.ToString());
        }
    }
}
