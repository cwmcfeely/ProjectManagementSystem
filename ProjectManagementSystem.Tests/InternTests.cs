using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagementSystem.ProjectManagementSystem.Tests
{
    // Test for the Intern class
    public class InternTests
    {
        //Testing constructor
        [Fact]
        public void GivenInternData_WhenConstructorCalled_ShouldSetPropertiesCorrectly()
        {
            // Arrange and act: create an intern and give it parameters
            var intern = new Intern(100, "John", "Doe");

            // Assert: Check that intern properties are set correctly. 
            Assert.Equal(100, intern.EmployeeId);
            Assert.Equal("John", intern.FirstName);
            Assert.Equal("Doe", intern.LastName);
            Assert.Equal("Intern", intern.Role);
        }

        // Testing console output for the ExecuteRole method
        [Fact]
        public void GivenInternData_WhenExecuteRoleCalled_ShouldOutputAssistanceMessage()
        {
            // Arrange and act: create an intern and give it parameters
            var intern = new Intern(100, "John", "Doe");

            // Get console output
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                // Act: call the execute method on the intern
                intern.ExecuteRole();

                // Assert: Check that intern name is correctly passed to console output
                string output = stringWriter.ToString().Trim();
                Assert.Contains("\n John is learning and assisting the team", output);
            }
        }
    }
}
