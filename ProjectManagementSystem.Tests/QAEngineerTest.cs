using Xunit;
using ProjectManagementSystem;

namespace ProjectManagementSystem.ProjectManagementSystem.Tests
{
    public class QAEngineerTest
    {
        [Fact]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Act
            var qaEngineer = new QAEngineer(123, "John", "Doe");

            // Assert
            Assert.Equal(123, qaEngineer.EmployeeId);
            Assert.Equal("John", qaEngineer.FirstName);
            Assert.Equal("Doe", qaEngineer.LastName);
        }

        [Fact]
        public void ViewTasks_NoTasksAssigned_DisplaysNoTasksMessage()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var consoleOutput = new StringWriter();

            Console.SetOut(consoleOutput);

            // Act
            qaEngineer.ViewTasks();

            // Assert
            var output = consoleOutput.ToString();
            Assert.Contains("No tasks assigned to this QA Engineer.", output);

        }

        [Fact]
        public void CreateTestCase_InvalidTestCaseID_ShouldLogErrorAndReturnNull_()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");
            int invalidTestCaseID = 0; // Invalid TestCase ID
            string description = "Test invalid login functionality";
            string expectedResult = "Error message displayed";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.CreateTestCase(invalidTestCaseID, description, expectedResult, Task);

            // Assert
            Assert.Null(result); // Verify that the method returns null
            var output = consoleOutput.ToString();
            Assert.Contains("Error: TestCase ID must be greater than 0.", output); // Verify console output

        }

        [Fact]
        public void CreateTestCase_InvalidDescription_ShouldLogErrorAndReturnNull()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");// Create a mock or dummy Task object
            int testCaseID = 1; // Valid TestCase ID
            string invalidDescription = "   "; // Invalid description (whitespace)
            string expectedResult = "Expected Outcome";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.CreateTestCase(testCaseID, invalidDescription, expectedResult, Task);

            // Assert
            Assert.Null(result); // The method should return null
            Assert.Contains("Error: Description cannot be empty.", consoleOutput.ToString()); // Verify the error message

        }

        [Fact]
        public void CreateTestCase_InvalidExpectedResult_ShouldLogErrorAndReturnNull()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");// Create a mock or dummy Task object
            int testCaseID = 1; // Valid TestCase ID
            string description = "Verify login functionality"; // Valid description
            string invalidExpectedResult = "   "; // Invalid expected result (whitespace)
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.CreateTestCase(testCaseID, description, invalidExpectedResult, Task);

            // Assert
            Assert.Null(result); // The method should return null
            Assert.Contains("Error: Expected result cannot be empty.", consoleOutput.ToString()); // Verify the error message
        }

        [Fact]
        public void CreateTestCase_ValidInputs_ShouldLogCorrectMessage()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");// Create a mock or dummy Task object
            int testCaseID = 1; // Valid test case ID
            string description = "Verify login functionality";
            string expectedResult = "Login should succeed with valid credentials";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.CreateTestCase(testCaseID, description, expectedResult, Task);

            // Assert
            Assert.NotNull(result); // Ensure the method returns a valid TestCase object
            Assert.Equal(testCaseID, result.TestCaseID);
            Assert.Equal(description, result.Description);
            Assert.Equal(expectedResult, result.ExpectedResult);
            Assert.Equal(Task, result.RelatedTask);

            // Validate console output
            var expectedMessage = $"\nManager assigned taskID {Task.ID} for QA Engineer created TestCase {testCaseID}: {description}";
            Assert.Contains(expectedMessage, consoleOutput.ToString());

        }

        [Fact]
        public void ReportDefect_InvalidDefectID_ShouldLogErrorAndReturnNull()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");// Create a mock or dummy Task object
            var TestCase = new TestCase(1, "Verify user login functionality with valid and invalid credentials", "Success", Task);
            int defectID = -1; // Invalid defect ID
            string description = "Login button is unresponsive";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.ReportDefect(defectID, description, TestCase);

            // Assert
            Assert.Null(result); // Ensure the method returns null for invalid defectID
            var expectedMessage = "Error: Defect ID must be greater than 0.";
            Assert.Contains(expectedMessage, consoleOutput.ToString()); // Check if the correct error message is logged

        }

        [Fact]
        public void ReportDefect_EmptyDescription_ShouldLogErrorAndReturnNull()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");// Create a mock or dummy Task object
            var TestCase = new TestCase(1, "Verify user login functionality with valid and invalid credentials", "Success", Task);
            int defectID = 123; // Valid defect ID
            string description = ""; // Empty description to trigger validation
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.ReportDefect(defectID, description, TestCase);

            // Assert
            Assert.Null(result); // Ensure the method returns null for empty description
            var expectedMessage = "Error: Defect summary cannot be empty.";
            Assert.Contains(expectedMessage, consoleOutput.ToString()); // Check if the correct error message is logged
        }

        [Fact]
        public void ReportDefect_ValidInputs_ShouldLogCorrectMessage()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var Task = new Task(2, "Test login", "Medium");// Create a mock or dummy Task object
            var TestCase = new TestCase(1, "Verify user login functionality with valid and invalid credentials", "Success", Task);
            string description = "Verify login functionality";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput); // Redirect Console output

            // Act
            var result = qaEngineer.ReportDefect(1, description, TestCase);


            // Assert
            Assert.NotNull(result); // Ensure the method returns a valid TestCase object
            Assert.Equal(description, result.Description);
        }

        [Fact]
        public void ExecuteRole_DisplaysCorrectMessage()
        {
            // Arrange
            var qaEngineer = new QAEngineer(123, "John", "Doe");
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            qaEngineer.ExecuteRole();

            // Assert
            Assert.Contains("John is executing QA Engineer responsibilities: creating test cases and reporting defects.", output.ToString());
        }
    }
}

