using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.ProjectManagementSystem.Tests
{
    // Test for the PersonalReport class
    public class PersonalReportTests
    {
        ////Testing constructor
        //[Fact]
        //public void GivenPersonalReportData_WhenConstructorCalled_ShouldSetPropertiesCorrectly()
        //{
        //    // Arrange and act: create a personal report and give it a role
        //    var personalReport = new PersonalReport("Developer");

        //    // Assert: Check that generated date is set correctly
        //    Assert.True(personalReport.GeneratedDate <= DateTime.Now);
        //}

        //// Testing invalid role in constructor
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void GivenInvalidRole_WhenConstructorCalled_ShouldThrowArgumentException(string invalidRole)
        //{
        //    // Assert: Check that constructor throws argument exception for invalid roles
        //    Assert.Throws<ArgumentException>(() => new PersonalReport(invalidRole));
        //}

        //// Testing console output for Generate method with no employees
        //[Fact]
        //public void GivenNoEmployeesWithRole_WhenGenerateCalled_ShouldOutputNoEmployeesMessage()
        //{
        //    // Arrange: create a personal report for a role with no employees
        //    var personalReport = new PersonalReport("Intern");

        //    // Get console output
        //    using (var stringWriter = new StringWriter())
        //    {
        //        Console.SetOut(stringWriter);

        //        // Act: call the generate method
        //        personalReport.Generate();

        //        // Assert: Check that correct message is output
        //        string output = stringWriter.ToString().Trim();
        //        Assert.Contains("No Intern employees found.", output);
        //    }
        //}
    }
}
