namespace ProjectManagementSystem;
public class TestCase
{
    public int TestCaseID { get; set; }
    public string Description { get; set; }
    public string Status { get; private set; }
    public string ExpectedResult { get; set; }
    public string ActualResult { get; private set; }
    public Task RelatedTask { get; set; } // Connects TestCase to Task

    public TestCase(int testCaseID, string description, string expectedResult, Task relatedTask)
    {
        if (testCaseID <= 0)
        {
            Console.WriteLine("Error: TestCase ID must be greater than 0.");
        }
        else if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Error: Description cannot be null or empty.");
        }
        else if (string.IsNullOrWhiteSpace(expectedResult))
        {
            Console.WriteLine("Error: Expected result cannot be null or empty.");
        }
        else
        {
            TestCaseID = testCaseID;
            Description = description;
            ExpectedResult = expectedResult;
            Status = "Pending";
            RelatedTask = relatedTask;
        }
    }

    // Method to update the actual result and determine status
    public void UpdateActualResult(string actualResult)
    {
        ActualResult = actualResult;
        Status = (ActualResult == ExpectedResult) ? "Pass" : "Fail";
    }

    // Method to display test case details
    public void DisplayTestCaseDetails()
    {
        Console.WriteLine($"TestCase {TestCaseID}: {Description}");
        Console.WriteLine(
            $"TaskId :{RelatedTask.ID} Expected: {ExpectedResult}, Actual: {ActualResult}, Status: {Status}"
        );
    }
}

