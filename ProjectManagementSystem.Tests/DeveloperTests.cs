using Xunit;
using ProjectManagementSystem;

namespace ProjectManagementSystem.Tests
{
    public class DeveloperTests
    {
        [Fact]
        public void Constructor_ValidInput_CreatesInstance()
        {
            // Arrange & Act
            var developer = new Developer(1, "John", "Doe", "C#");

            // Assert
            Assert.Equal(1, developer.EmployeeId);
            Assert.Equal("John", developer.FirstName);
            Assert.Equal("Doe", developer.LastName);
            Assert.Equal("C#", developer.ProgrammingLanguage);
            Assert.Equal("Developer", developer.Role);
        }

        [Fact]
        public void Constructor_EmptyProgrammingLanguage_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new Developer(1, "John", "Doe", ""));
        }

        [Fact]
        public void Constructor_NullProgrammingLanguage_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new Developer(1, "John", "Doe", null));
        }

        [Fact]
        public void ViewTasks_WithNoTasks_DisplaysEmptyMessage()
        {
            // Arrange
            var developer = new Developer(1, "John", "Doe", "C#");
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            developer.ViewTasks();

            // Assert
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
