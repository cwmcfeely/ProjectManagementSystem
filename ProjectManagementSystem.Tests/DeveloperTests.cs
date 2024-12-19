using Xunit;
using ProjectManagementSystem;

namespace ProjectManagementSystem.Tests
{
    public class DeveloperTests
    {
        [Fact]
        public void Constructor_ValidInput_CreatesInstance()
        {
            var developer = new Developer(1, "John", "Doe", "C#");

            Assert.Equal(1, developer.EmployeeId);
            Assert.Equal("John", developer.FirstName);
            Assert.Equal("Doe", developer.LastName);
            Assert.Equal("C#", developer.ProgrammingLanguage);
            Assert.Equal("Developer", developer.Role);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_EmptyProgrammingLanguage_ThrowsArgumentException(string language)
        {
            Assert.Throws<ArgumentException>(() =>
                new Developer(1, "John", "Doe", language));
        }

        [Fact]
        public void Constructor_NullProgrammingLanguage_ThrowsArgumentException()
        {
            string? nullLanguage = null;
            Assert.Throws<ArgumentException>(() =>
                new Developer(1, "John", "Doe", nullLanguage));
        }

        [Fact]
        public void ViewTasks_WithNoTasks_DisplaysEmptyMessage()
        {
            var developer = new Developer(1, "John", "Doe", "C#");
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            developer.ViewTasks();

            var output = consoleOutput.ToString();
            Assert.Contains("Developer John Doe's Assigned Tasks:", output);
            Assert.Contains("No tasks assigned to this developer.", output);
        }

        [Fact]
        public void ExecuteRole_DisplaysCorrectMessage()
        {
            var developer = new Developer(1, "John", "Doe", "C#");
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            developer.ExecuteRole();

            Assert.Contains($"\nJohn is writing code in C#", consoleOutput.ToString());
        }
    }
}
