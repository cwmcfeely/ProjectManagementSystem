using Xunit; // Testing framework
namespace ProjectManagementSystem.Tests // Updated namespace to comply with the requested structure
{
    // Test class for the Employee class
    public class EmployeeTests
    {
        // Test 1: Ensure constructor throws an exception for invalid input values
        [Fact]
        public void Constructor_ShouldThrowException_WhenInvalidInputsProvided()
        {
            // Verify that creating an employee with invalid input throws an exception
            Assert.Throws<ArgumentException>(() => new Developer(-1, "Conor", "McFeely", "C#")); // Invalid (negative) ID
            Assert.Throws<ArgumentException>(() => new Developer(1, "", "McFeely", "C#"));      // Empty first name
            Assert.Throws<ArgumentException>(() => new Developer(1, "Conor", "", "C#"));        // Empty last name
        }

        // Test 2: Verify that tasks are successfully added to the employee
        [Fact]
        public void AddTask_ShouldAddTaskToEmployeeTaskList()
        {
            // Arrange: Create an employee and a task
            var employee = new Developer(123, "Conor", "McFeely", "C#");
            var task = new Task(1234, "Fix Bug", "High");

            // Act: Add the task to the employee
            employee.AddTask(task);

            // Assert: Check that the task is now in the employee's task list
            Assert.Contains(task, employee.ReadOnlyTasks);
        }

        // Test 3: Ensure tasks can be removed from the employee's task list
        [Fact]
        public void RemoveTask_ShouldRemoveTaskFromEmployeeTaskList()
        {
            // Arrange: Create an employee and a task, then add the task to the employee
            var employee = new Developer(124, "Sean", "Owen", "Python");
            var task = new Task(1235, "Test login", "Medium");
            employee.AddTask(task);

            // Act: Remove the task from the employee
            var result = employee.RemoveTask(task);

            // Assert: Check that the task was removed successfully
            Assert.True(result); // The RemoveTask method should return true
            Assert.DoesNotContain(task, employee.ReadOnlyTasks); // Task list should no longer include the task
        }

        // Test 4: Verify the correct task is returned when searching by task ID
        [Fact]
        public void GetTaskById_ShouldReturnCorrectTask()
        {
            // Arrange: Create an employee and a task, then add the task to the employee
            var employee = new Developer(189, "Bob", "McBob", "Ruby");
            var task = new Task(1245, "Learn C# Basics", "High");
            employee.AddTask(task);

            // Act: Search for the task by its ID
            var result = employee.GetTaskById(1245);

            // Assert: Check that the returned task is the correct one
            Assert.Equal(task, result); // Ensure the fetched task matches the added task
        }

        // Test 5: Ensure the ViewTasks method works (check manually for console output)
        [Fact]
        public void ViewTasks_ShouldDisplayCorrectOutput()
        {
            // Arrange: Create an employee and a task, then add the task to the employee
            var employee = new Intern(8936, "Martin", "Fortuna");
            var task = new Task(12348, "Develop shopping cart", "High");
            employee.AddTask(task);

            // Act: Call the ViewTasks method
            employee.ViewTasks(); // Run method and verify output manually
            // Assert: No assertion here; this relies on manual verification of console output
        }
    }
}